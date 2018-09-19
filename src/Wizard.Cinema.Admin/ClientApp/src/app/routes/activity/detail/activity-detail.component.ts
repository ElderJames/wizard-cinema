import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { _HttpClient } from '@delon/theme';

@Component({
  selector: 'app-activity-detail',
  templateUrl: './activity-detail.component.html',
})
export class ActivityDetailComponent implements OnInit {
  form: FormGroup;
  submitting = false;
  divisions: any[];
  activity = {
    activityId: null,
    divisionId: 0,
    name: '',
    description: '',
    address: '',
    price: '',
    beginTime: new Date(),
    finishTime: new Date(),
    registrationBeginTime: new Date(),
    registrationFinishTime: new Date(),
  };

  constructor(
    private fb: FormBuilder,
    private msg: NzMessageService,
    private route: ActivatedRoute,
    private router: Router,
    private http: _HttpClient,
  ) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      name: [null, [Validators.required]],
      divisionId: [null, [Validators.required]],
      address: [null, [Validators.required]],
      date: [null, [Validators.required]],
      description: [null, [Validators.required]],
      price: [null, [Validators.required]],
      registrationTime: [null, [Validators.required]],
    });

    this.getDivisions();

    this.route.params.subscribe((params: Params) => {
      const activityId = params['id'];
      console.log(activityId);
      if (!activityId)
        return;
      this.getActivity(activityId);
      this.activity.activityId = activityId;
    });
  }

  getActivity(id: number) {
    this.http.get('api/activity/' + id).subscribe((res: any) => {
      this.activity = res;
      console.log(res);
      for (const key in res) {
        const val = res[key];
        if (this.form.controls[key]) this.form.controls[key].setValue(val);
      }
      let dateArr = [];
      dateArr.push(res.beginTime);
      dateArr.push(res.finishTime);
      this.form.controls.date.setValue(dateArr);

      dateArr = [];
      dateArr.push(res.registrationBeginTime);
      dateArr.push(res.registrationFinishTime);
      this.form.controls.registrationTime.setValue(dateArr);
    });
  }

  getDivisions() {
    this.http.get('api/division', { PageSize: 1000 })
      .subscribe((res: any) => {
        this.divisions = res.records;
      })
  }

  loadMore() { }

  submit() {
    for (const i in this.form.controls) {
      this.form.controls[i].markAsDirty();
      this.form.controls[i].updateValueAndValidity();
      this.activity[i] = this.form.controls[i].value;
    }

    this.activity['beginTime'] = this.activity['date'][0];
    this.activity['finishTime'] = this.activity['date'][1];
    this.activity['registrationBeginTime'] = this.activity['registrationTime'][0];
    this.activity['registrationFinishTime'] = this.activity['registrationTime'][1];

    if (this.form.invalid) return;
    this.submitting = true;

    this.submitting = this.http.loading;
    this.http.post('api/activity', this.activity).subscribe((res: any) => {
      this.submitting = false;
      this.msg.success(`提交成功`);
      this.router.navigate(['activity']);
    });
  }
}
