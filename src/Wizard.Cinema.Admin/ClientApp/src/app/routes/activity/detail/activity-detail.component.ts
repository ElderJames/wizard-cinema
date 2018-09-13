import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { _HttpClient } from '@delon/theme';

@Component({
    selector: 'activity-detail',
    templateUrl: './activity-detail.component.html',
})
export class ActivityDetailComponent implements OnInit {

    form: FormGroup;
    submitting = false;
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
    }

    constructor(
        private fb: FormBuilder,
        private msg: NzMessageService,
        private route: ActivatedRoute,
        private http: _HttpClient
    ) { }

    ngOnInit(): void {


        this.route.params.subscribe((params: Params) => {
            let activityId = params['id'];
            console.log(activityId);

            this.getActivity(activityId);
            this.form = this.fb.group({
                name: ["ddd", [Validators.required]],
                date: [null, [Validators.required]],
                goal: [null, [Validators.required]],
                standard: [null, [Validators.required]],
                client: [null, []],
                invites: [null, []],
                weight: [null, []],
                public: [1, [Validators.min(1), Validators.max(3)]],
                publicUsers: [null, []],
            });
        });
    }

    getActivity(id: number) {
        this.http.get('api/activity/' + id)
            .subscribe((res: any) => {
                this.activity = res;
                console.log(res);
            })
    }

    submit() {
        for (const i in this.form.controls) {
            this.form.controls[i].markAsDirty();
            this.form.controls[i].updateValueAndValidity();
        }
        if (this.form.invalid) return;
        this.submitting = true;
        setTimeout(() => {
            this.submitting = false;
            this.msg.success(`提交成功`);
        }, 1000);
    }

}