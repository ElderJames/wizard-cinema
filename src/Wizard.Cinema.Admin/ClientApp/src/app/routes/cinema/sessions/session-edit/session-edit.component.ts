import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { _HttpClient } from '@delon/theme';

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
  modeldata = {
    sessionId: null,
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
    private cd: ChangeDetectorRef
  ) {
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      divisionId: [null, [Validators.required]],
      cinemaId: [null, [Validators.required]],
      hall: [null, [Validators.required]]
    });

    this.getDivisions();

    this.route.params.subscribe((params: Params) => {
      const sessionId = params['id'];
      console.log(sessionId);
      if (!sessionId)
        return;
      this.getSession(sessionId);
      this.modeldata.sessionId = sessionId;
    });
  }

  getSession(id: number) {
    this.http.get('api/session/' + id).subscribe((res: any) => {
      this.modeldata = res;
      console.log(res);
      for (const key in res) {
        const val = res[key];
        if (this.form.controls[key]) this.form.controls[key].setValue(val);
      }

      var hallarr = [];
      hallarr.push(this.modeldata.cinemaId);
      hallarr.push(this.modeldata.hallId);
      this.form.controls['hall'].setValue(hallarr);
    });
  }

  getDivisions() {
    this.http.get('api/division', { PageSize: 1000 })
      .subscribe((res: any) => {
        this.divisions = res.records;
      })
  }

  onDivisionChanges(value: any) {

    if (!this.divisions)
      return;

    let selected = this.divisions.find(x => x.divisionId == value);
    if (!selected)
      return;

    this.selectCityId = selected.cityId;
    console.log(this.selectCityId);
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
    console.log("submitting", formData);
    //this.submitting = true;

    this.submitting = this.http.loading;
    this.http.post('api/session', formData)
      .subscribe((res: any) => {
        this.submitting = false;
        this.msg.success(`提交成功`);
        this.router.navigate(['sessions']);
      });
  }

  selectedCinemaId: 0;
  selectedHallId: 0;

  public onChanges(values: any): void {
    this.modeldata.cinemaId = values[0];
    if (this.modeldata.hallId != values[1]) {
      this.modeldata.hallId = values[1];
      this.selectedSeats = [];
    }
  }

  /** load data async execute by `nzLoadData` method */
  public loadData = (node: any, index: number) => {
    console.log("index", index);
    return new Promise(resolve => {
      if (index < 0) { // if index less than 0 it is root node
        // if (this.selectCityId <= 0) {
        //   resolve();
        //   return;
        // }

        this.http.get('api/city/' + this.selectCityId + '/cinemas', { size: 300 })
          .subscribe((res: any) => {
            console.log("cinemas", res);
            node.children = res.records.map(x => {
              return {
                value: x.cinemaId + '',
                label: x.name,
                isLeaf: false
              };
            });
          }, null, () => resolve());
      }
      else if (index == 0) {
        console.log('get halls');
        this.selectedCinemaId = node.value;
        this.http.get("api/cinemas/" + this.selectedCinemaId + "/halls")
          .subscribe((res: any) => {
            console.log("halls", res);
            node.children = res.map(x => {
              return {
                value: x.hallId + '',
                label: x.name,
                isLeaf: true
              }
            })
          }, null, () => resolve());
      }
      else {
        resolve()
      }
      console.log("node", node);
    });
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
