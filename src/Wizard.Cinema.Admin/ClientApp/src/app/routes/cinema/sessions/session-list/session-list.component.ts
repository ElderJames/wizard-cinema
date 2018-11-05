import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { NzMessageService, NzModalService, NzModalComponent } from 'ng-zorro-antd';
import { _HttpClient } from '@delon/theme';
import { tap, map } from 'rxjs/operators';
import {
  SimpleTableComponent,
  SimpleTableColumn,
  SimpleTableData,
} from '@delon/abc';

import { SessionService } from '../../../../services/session.service';

@Component({
  selector: 'session',
  templateUrl: './session-list.component.html',
})
export class SessionListComponent implements OnInit {
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
    { title: '影院', index: 'cinema' },
    { title: '影厅', index: 'hall' },
    { title: '分部', index: 'division' },
    { title: '状态', index: 'status' },
    {
      title: '操作',
      buttons: [
        {
          text: '编辑',
          type: 'link',
          click: (item: any) => `cinema/sessions/${item.sessionId}`
        },
        {
          text: '开始选座',
          click: (item: any) => this.beginSelect(item.sessionId),
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
    private sessionSrv: SessionService
  ) { }

  ngOnInit() {
    this.getData();
  }

  getData() {
    this.loading = true;
    this.q.statusList = this.status
      .filter(w => w.checked)
      .map(item => item.index);
    if (this.q.status !== null && this.q.status > -1)
      this.q.statusList.push(this.q.status);
    this.http
      .get('api/session',
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

  async beginSelect(sessionId: number) {
    await this.sessionSrv.beginSelect(sessionId);
    this.getData();
  }
}
