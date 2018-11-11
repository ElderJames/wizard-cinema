using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wizard.Cinema.Admin.Models
{
    public class ImportWedianApplicantModel
    {
        [Column("订单编号")]
        public string OrderNo { get; set; }

        [Column("收件人手机")]
        public string Mobile { get; set; }

        [Column("收件人姓名")]
        public string RealName { get; set; }

        [Column("收件人姓名")]
        public string WechatName { get; set; }

        [Column("购买数量")]
        public int Count { get; set; }

        [Column("付款时间")]
        public DateTime CreateTime { get; set; }
    }
}
