import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { _HttpClient } from '@delon/theme';
import { CinermaService } from '../../../../services/cinema.service';
import { ActivityService } from '../../../../services/activity.service';


@Component({
  selector: 'session-edit',
  templateUrl: './session-edit.component.html',
})
export class SessionEditComponent implements OnInit {
  form: FormGroup;
  submitting = false;
  divisions: any[];
  selectCityId = 0;
  cinemas: any[];
  halls: any[];
  activities: any[];
  modeldata = {
    sessionId: null,
    activityId: 0,
    divisionId: 0,
    cinemaId: 0,
    hallId: 0,
    seatNos: []
  };

  constructor(
    private fb: FormBuilder,
    private msg: NzMessageService,
    private route: ActivatedRoute,
    private router: Router,
    private http: _HttpClient,
    private cd: ChangeDetectorRef,
    private cinemaSrv: CinermaService,
    private activitySrv: ActivityService
  ) {
  }

  async ngOnInit(): Promise<void> {
    this.form = this.fb.group({
      divisionId: [null, [Validators.required]],
      activityId: [null, [Validators.required]],
      cinemaId: [null, [Validators.required]],
      hall: [null, [Validators.required]]
    });

    this.divisions = await this.cinemaSrv.getDivisions(300);

    this.route.params.subscribe(async (params: Params) => {
      const sessionId = params['id'];

      if (!sessionId)
        return;

      this.modeldata.sessionId = sessionId;
      var session = await this.cinemaSrv.getSession(sessionId);
      this.modeldata = session;
      for (const key in session) {
        const val = session[key];
        if (this.form.controls[key]) this.form.controls[key].setValue(val);
      }

      var hallarr = [];
      hallarr.push(this.modeldata.cinemaId);
      hallarr.push(this.modeldata.hallId);
      this.form.controls['hall'].setValue(hallarr);

      let selected = this.divisions.find(x => x.divisionId == this.modeldata.divisionId);
      this.selectCityId = selected.cityId;
      if (this.modeldata.activityId) {
        var res = await this.activitySrv.getActivities(1000, 1, this.modeldata.divisionId);
        this.activities = res.records;
      }
      if (this.modeldata.hallId) {
        var hall = await this.cinemaSrv.getHall(this.modeldata.hallId);
        if (hall.seatJson) {
          var seatJson = JSON.parse(hall.seatJson);
          var seats = seatJson.sections[0].seats.flatMap((x) => {
            return x.columns.map(o => {
              return {
                rowId: x.rowId,
                columnId: o.columnId,
                seatNo: o.seatNo
              }
            })
          });
          this.selectedSeats = seats.filter(x => this.modeldata.seatNos.indexOf(x.seatNo) >= 0);
        }

        var cinemas = await this.cinemaSrv.getCinemas(this.selectCityId, 300);
        var halls = await this.getHalls(this.modeldata.cinemaId);
        cinemas.forEach(item => {
          item['children'] = halls.filter(x => x.cinemaId == item.cinemaId);
        })
        this.hallOptions = cinemas;
      }
    });
  }

  async onDivisionChanges(value: any) {
    if (!this.divisions)
      return;

    let selected = this.divisions.find(x => x.divisionId == value);
    if (!selected)
      return;

    this.selectCityId = selected.cityId;

    var res = await this.activitySrv.getActivities(1000, 1, value);
    this.activities = res.records;
  }

  onActivityChanges(value: any) {
    console.log(value);
  }
  submit() {
    var formData = {};
    for (const i in this.form.controls) {
      this.form.controls[i].markAsDirty();
      this.form.controls[i].updateValueAndValidity();
      formData[i] = this.form.controls[i].value;
    }

    formData["sessionId"] = this.modeldata.sessionId;
    formData["cinemaId"] = formData['hall'][0];
    formData["hallId"] = formData['hall'][1];
    formData["seatNos"] = this.selectedSeats.map(x => x.seatNo);

    // if (this.form.invalid) return;
    console.log("submitData", formData);

    this.submitting = this.http.loading;
    this.http.post('api/session', formData)
      .subscribe((res: any) => {
        this.submitting = false;
        this.msg.success(`提交成功`);
        this.router.navigate(['/cinema/sessions']);
      });
  }

  // selectedCinemaId = 0;
  // selectedHallId = 0;
  hallOptions: any[];

  public onHallSelectorChanges(values: any): void {
    console.log(values);
    this.modeldata.cinemaId = values[0];
    if (this.modeldata.hallId != values[1]) {
      this.modeldata.hallId = values[1];
      this.selectedSeats = [];
    }
  }

  async getHalls(cinemaId: number) {
    var halls = await this.cinemaSrv.getHalls(cinemaId);
    return halls.map(x => {
      return {
        cinemaId: cinemaId,
        value: x.hallId + '',
        label: x.name,
        isLeaf: true
      }
    })
  }

  /** load data async execute by `nzLoadData` method */
  loadHallData = async (node: any, index: number) => {
    console.log("node", node)
    if (index < 0) {
      node.children = await this.cinemaSrv.getCinemas(this.selectCityId, 300);
    }
    else if (index == 0) {
      var cinemaId = node.cinemaId;
      node.children = await this.getHalls(cinemaId);
    }
  }

  selectedSeats: any[] = [];
  openSelectWindow(values: any) {
    if (!window)
      return;

    var seatsParam = this.selectedSeats.map(x => `seatNos=${x.seatNo}`).join('&');
    var win = window.open("/SeatSelector?hallId=" + this.modeldata.hallId + "&" + seatsParam, "", 'width=1200,height=630,left=300,top=100,location=no');
    win.onload = () => {
      var okbtn = win.document.getElementById('ok');
      var selectSeats = win.document.getElementById('selected-seat');
      okbtn.addEventListener('click', () => {
        this.selectedSeats = [];
        var json = selectSeats.getAttribute("value");

        if (json)
          this.selectedSeats = JSON.parse(json);
      })
    }
    win.onunload = () => {
      this.cd.markForCheck();
      this.cd.detectChanges();
    }
  }
}
