import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { NzMessageService, NzModalService, NzModalComponent } from 'ng-zorro-antd';
import { _HttpClient } from '@delon/theme';
import { tap, map } from 'rxjs/operators';
import {
  SimpleTableComponent,
  SimpleTableColumn,
  SimpleTableData,
} from '@delon/abc';

@Component({
  selector: 'activity-list',
  templateUrl: './activity-list.component.html',
})
export class ActivityListComponent implements OnInit {
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
    { title: '名称', index: 'name' },
    { title: '分部', index: 'division' },
    { title: '开始时间', index: 'beginTime' },
    { title: '结束时间', index: 'finishTime' },
    { title: '报名开始时间', index: 'registrationBeginTime' },
    { title: '报名截止时间', index: 'registrationFinishTime' },
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
  divisionData = [];

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
    private modalSrv: NzModalService,
  ) { }

  ngOnInit() {
    this.getData();
    this.getDivision();
  }

  getData() {
    this.loading = true;
    this.q.statusList = this.status
      .filter(w => w.checked)
      .map(item => item.index);
    if (this.q.status !== null && this.q.status > -1)
      this.q.statusList.push(this.q.status);
    this.http
      .get('api/activity',
        {
          PageNow: this.q.pi,
          PageSize: this.q.ps,
        }
      )
      .pipe(
        map((res: any) => res
          // list.records.map(i => {
          //   return i;
          //   // const statusItem = this.status[i.status];
          //   // i.statusText = statusItem.text;
          //   // i.statusType = statusItem.type;
          //   // return i;
          // }),
        ),
        tap(() => (this.loading = false)),
      )
      .subscribe(res => {
        this.total = res.totalCount;
        this.data = res.records;
      });
  }

  getDivision() {
    this.http.get('api/division', {
      PageNow: 1,
      PageSize: 1000,
    }).subscribe((res: any) => {
      console.log(res);
      this.divisionData = res.records;
    })
  }

  checkboxChange(list: SimpleTableData[]) {
    this.selectedRows = list;
    this.totalCallNo = this.selectedRows.reduce(
      (total, cv) => total + cv.callNo,
      0,
    );
  }

  remove() {
    this.http
      .delete('/rule', { nos: this.selectedRows.map(i => i.no).join(',') })
      .subscribe(() => {
        this.getData();
        this.st.clearCheck();
      });
  }

  approval() {
    this.msg.success(`审批了 ${this.selectedRows.length} 笔`);
  }

  add(tpl: TemplateRef<{}>) {
    this.activity = {
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
    this.modalSrv.create({
      nzTitle: '添加巫师',
      nzContent: tpl,
      nzOnOk: () => {
        this.loading = true;
        this.http
          .post('api/activity', this.activity)
          .subscribe(() => {
            this.getData();
          });
      },
    });
  }

  update(data: any) {
    this.activity = data;
    this.modalSrv.create({
      nzTitle: '修改巫师信息',
      nzContent: this.modal,
      nzOnOk: () => {
        this.loading = true;
        this.http
          .post('api/activity', this.activity)
          .subscribe(() => {
            this.getData();
          });
      },
    });
  }

  reset(ls: any[]) {
    for (const item of ls) item.value = false;
    this.getData();
  }

  options = [];
  tempKeyword = '';
  cityTimer: NodeJS.Timer;
  onInput(value: string): void {

    if (value == '') {
      this.options = [];
      return;
    }

    if (this.tempKeyword == value && this.options.length == 0)
      return;

    clearTimeout(this.cityTimer);
    this.tempKeyword = value;
    this.loading = true;
    this.cityTimer = setTimeout(() => {
      this.http.get('api/city', { keyword: value })
        .subscribe((res: any) => {
          this.loading = false;
          this.options = res;
        })
    }, 500);
  }
}
