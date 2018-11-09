import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { NzMessageService, NzModalService, NzModalComponent } from 'ng-zorro-antd';
import { _HttpClient } from '@delon/theme';
import { tap, map } from 'rxjs/operators';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { ActivityService } from "../../../services/activity.service";
import {
  SimpleTableComponent,
  SimpleTableColumn,
  SimpleTableData,
  XlsxService,
} from '@delon/abc';

@Component({
  selector: 'applicant-list',
  templateUrl: './applicant-list.component.html',
})
export class ApplicantListComponent implements OnInit {
  q: any = {
    pi: 1,
    ps: 10,
    sorter: '',
    status: null,
    statusList: [],
  };
  data: any[] = [];
  loading = false;
  status = [
    { index: 0, text: '关闭', value: false, type: 'default', checked: false },
    {
      index: 1,
      text: '运行中',
      value: false,
      type: 'processing',
      checked: false,
    },
    { index: 2, text: '已上线', value: false, type: 'success', checked: false },
    { index: 3, text: '异常', value: false, type: 'error', checked: false },
  ];
  @ViewChild('st') st: SimpleTableComponent;
  @ViewChild('modalContent') modal: TemplateRef<{}>;

  columns: SimpleTableColumn[] = [
    { title: '', index: 'key', type: 'checkbox' },
    { title: '巫师', index: 'wizardName' },
    { title: '姓名', index: 'realName' },
    { title: '活动', index: 'activity' },
    { title: '手机号', index: 'mobile' },
    { title: '分部', index: 'division' },
    { title: '报名时间', index: 'applyTime' },
    { title: '状态', index: 'status' },
    {
      title: '操作',
      buttons: [
        {
          text: '编辑',
          type: 'link',
          click: (item: any) => `/activity/detail/${item.activityId}`
          //click: (item: any) => this.update(item),//this.msg.success(`配置${item.no}`),
        },
        {
          text: '详情',
          click: (item: any) => this.msg.success(`订阅警报${item.no}`),
        },
      ],
    },
  ];
  selectedRows: SimpleTableData[] = [];
  description = '';
  totalCallNo = 0;
  expandForm = false;
  total = 0;

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
    private http: _HttpClient,
    public msg: NzMessageService,
    private route: ActivatedRoute,
    private modalSrv: NzModalService,
    private xlsx: XlsxService,
    private activitySrv: ActivityService
  ) { }

  async ngOnInit() {
    const activityId = await this.getId();
    if (!activityId)
      return;
    this.activity = await this.activitySrv.getDetail(activityId);
    await this.getData();
  }

  getId = async (): Promise<any> => {
    return new Promise((resolve, reject) => {
      this.route.params.subscribe(async (params: Params) => {
        resolve(params['id']);
      })
    });
  }

  async getData() {
    this.loading = true;
    this.q.statusList = this.status
      .filter(w => w.checked)
      .map(item => item.index);
    if (this.q.status !== null && this.q.status > -1)
      this.q.statusList.push(this.q.status);
    var res = await this.activitySrv.getApplicants(this.q.ps, this.q.pi, this.activity.activityId);
    this.total = res.totalCount;
    this.data = res.records;
  }

  async change(e) {
    this.q.pi = this.st.pi;
    await this.getData();
  }

  async upload(files) {
    if (files.length === 0)
      return;

    var formdata = new FormData();

    for (let file of files)
      formdata.append(file.name, file);

    await this.activitySrv.importApplicantsFromWeidian(this.activity.activityId, formdata);
    await this.getData();
  }
}