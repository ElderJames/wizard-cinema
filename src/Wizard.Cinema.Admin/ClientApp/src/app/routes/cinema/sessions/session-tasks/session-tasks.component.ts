import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { NzMessageService, NzModalService, NzModalComponent } from 'ng-zorro-antd';
import { _HttpClient } from '@delon/theme';
import { tap, map } from 'rxjs/operators';
import {
  SimpleTableComponent,
  SimpleTableColumn,
  SimpleTableData,
} from '@delon/abc';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { SessionService } from '../../../../services/session.service';

@Component({
  selector: 'session',
  templateUrl: './session-tasks.component.html',
})
export class SessionTaskComponent implements OnInit {
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
    { title: '排序', index: 'serialNo' },
    { title: '手机', index: 'mobile' },
    { title: '姓名', index: 'realName' },
    { title: '微信', index: 'wechatName' },
    { title: '座位号', index: 'seatNos' },
    { title: '状态', index: 'status' },
    {
      title: '操作',
      buttons: [
        {
          text: '编辑',
          type: 'link',
          click: (item: any) => `cinema/sessions/${item.sessionId}`
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
  sessionId: number;

  constructor(
    private http: _HttpClient,
    public msg: NzMessageService,
    private modalSrv: NzModalService,
    private sessionSrv: SessionService,
    private route: ActivatedRoute,
    private router: Router,
  ) { }

  async ngOnInit() {
    this.sessionId = await this.getId();
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

    var res = await this.sessionSrv.getTaskList(this.sessionId, this.q.ps, this.q.pi)
    this.total = res.totalCount;
    this.data = res.records;
  }

  async change(e) {
    this.q.pi = this.st.pi;
    await this.getData();
  }

  async beginSelect(sessionId: number) {
    await this.sessionSrv.beginSelect(sessionId);
    await this.getData();
  }
}
