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
  divisionData = [];
  applicantData: any

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
    // this.http
    //   .get('api/activity/applicants',
    //     {
    //       PageNow: this.q.pi,
    //       PageSize: this.q.ps,
    //     }
    //   )
    //   .pipe(
    //     map((res: any) => res
    //       // list.records.map(i => {
    //       //   return i;
    //       //   // const statusItem = this.status[i.status];
    //       //   // i.statusText = statusItem.text;
    //       //   // i.statusType = statusItem.type;
    //       //   // return i;
    //       // }),
    //     ),
    //     tap(() => (this.loading = false)),
    //   )
    //   .subscribe(res => {
    //     this.total = res.totalCount;
    //     this.data = res.records;
    //   });
    var res = await this.activitySrv.getApplicants(this.q.ps, this.q.pi, this.activity.activityId);
    this.total = res.totalCount;
    this.data = res.records;
  }

  async import(e: any) {
    const file = e.target.files[0];
    // var data = await this.xlsx.import(node.files[0])
    // node.value = '';
    // var importModel = {
    //   ActivityId: 0,
    //   Data: [{
    //     OrderNo: '',
    //     Name: '',
    //     Mobile: '',
    //     RealName: '',
    //     WechatName: '',
    //     Count: '',
    //     CreateTime: ''
    //   }]
    // }
    //data.excelReport.splice(0, 1);
    var formdata = new FormData();
    formdata.append('excelfile', file)
    console.log(formdata)


    // this.applicantData = data.excelReport.map(x => {
    //   return {
    //     OrderNo: x[0],
    //     Mobile: x[23],
    //     RealName: x[23],
    //     WechatName: x[41],
    //     Count: x[14],
    //     CreateTime: x[6],
    //   }
    // })
    // console.log(this.applicantData)
    await this.activitySrv.importApplicantsFromWeidian(this.activity.activityId, this.applicantData);

  }
}

//微店到处表格字段头部
// 0: "订单编号"
// 1: "订单金额（不含退款）"
// 2: "订单总积分"
// 3: "改价前金额"
// 4: "订单状态"
// 5: "订单类型"
// 6: "下单时间"
// 7: "付款时间"
// 8: "发货时间"
// 9: "买家确认收货时间"
// 10: "商品名称"
// 11: "商品型号"
// 12: "商品id"
// 13: "商品编码"
// 14: "购买数量"
// 15: "商品价格"
// 16: "商品积分"
// 17: "发货状态"
// 18: "退款状态"
// 19: "退款金额"
// 20: "客服指派退款"
// 21: "商品原价"
// 22: "运费退款"
// 23: "收件人姓名"
// 24: "收件人手机"
// 25: "省"
// 26: "市"
// 27: "区"
// 28: "收货详细地址"
// 29: "物流公司"
// 30: "物流单号"
// 31: "商品总件数"
// 32: "订单描述"
// 33: "运费"
// 34: "税费"
// 35: "推广费"
// 36: "满减优惠"
// 37: "赠品"
// 38: "优惠券"
// 39: "满包邮"
// 40: "买家留言"
// 41: "微信"
// 42: "备注"
// 43: "分销商店铺ID"
// 44: "分销商注册姓名"
// 45: "分销商手机号"
// 46: "分成金额"
// 47: "下单账号"
// 48: "是否已成团"
// 49: "身份证号"
// 50: "支付方式"
// 51: "是否自提"

// 0: "810060749590313"
// 1: "110.0"
// 3: "待发货"
// 4: "担保交易"
// 5: "2018-10-04 14:43:37"
// 6: "2018-10-04 14:44:16"
// 7: "广州屋子神动2IMAX3D观影活动"
// 10: "B 活动+观影"
// 11: "2604101706"
// 12: "1"
// 13: "待发货"
// 14: "格林"
// 15: "110.0"
// 16: "待发货"
// 17: "担保交易"
// 18: "待发货"
// 19: "待发货"
// 20: "待发货"
// 21: "110.0"
// 23: "13534268095"
// 24: "广东"
// 25: "广州市"
// 26: "天河区"
// 27: "广东 广州市 天河区  龙洞北路321号"
// 28: "广州屋子神动2IMAX3D观影活动 B 活动+观影 [数量:1]"
// 30: "待发货"
// 31: "格林"
// 32: "0.0"
// 33: "0"
// 35: "0"
// 36: "待发货"
// 37: "待发货"
// 38: "待发货"
// 39: "待发货"
// 40: "13534268095"
// 41: "广东"
// 42: "待发货"
// 43: "借记卡"
// 44: "待发货"
// 45: "待发货"
// 46: "0"
// 47: "广东"
// 48: "待发货"
// 50: "810059601944649"
// 51: "待发货"