<template lang="pug">
  Layout(:has_share="false" title="选座" :has_footer="false")
    .body(style='visibility: visible;')
      section.seat-block
        .info-block
          .movie-info.box-flex.middle
            .flex
              .title.line-ellipsis {{activity.name}}
              .info.line-ellipsis
                span {{activity.time}}
                span(style='margin-left: 5px; ') IMAX
          ul.reminder-list
            li.reminder-item
              img(src='http://p1.meituan.net/movie/77717de09967c29cd5b3d1f76309ac841254.png')
              div 每位巫师最多只有15分钟的选择时间
              span.reminder-num(style='display: none;')
                | 1个通知
                i.fold-down
        .select-block()
          .seat-block-wrap(style='visibility: visible;')
            .hall-name-wrapper.animate
              span.hall-name IMAX厅
            .row-nav.animate
              div(v-for="rowId in rowIds") {{rowId}}
            .seats-block.animate(v-drag="true" :data-maxLength="maxSeatLength" :style='"width:"+maxSeatLength * 46 +"px"' :data-can-selct="canSelct" )
              .m-line(:style="maxSeatLength%2==0?'': '-webkit-transform: translateX(-23px);transform: translateX(-23px);'")
                .divider(:style="maxSeatLength%2==0?'': '-webkit-transform: translateX(-23px);transform: translateX(-23px);'")
              //- .seats-wrap(data-sectionid='1', data-sectionname='花城汇IMAX', style='width: 1426px;')
              .seats-wrap(data-sectionid='1', data-sectionname='', :style='"width:"+maxSeatLength * 46 +"px"')
                .wrap(:class='seat.active?"active":""' v-for="seat in seats" @click='onSeatClicked(seat)' data-love='0' :data-info="seat.info" :data-status='seat.status' :data-id='seat.seatNo' data-bid='dp_wx_seat_select')
                  .seat
                    .name(v-if="seat.rowId>0&&seat.columnId>0")
                      div {{seat.rowId}}排
                      div {{seat.columnId}}座
        .buy-block(:data-show='selectedSeats.length>0?"submit":"recommend"')
          .cinema-info
            .seat-type-info
              span.text-middle
                span.c.icon
                span.text 可选
              span.text-middle
                span.u.icon
                span.text 已选
              span.text-middle
                span.s.icon
                span.text 已售
              span.text-middle
                span.n.icon
                span.text 不可选
              //- span.text-middle
              //-   span.l.icon
              //-   span.text 情侣座
          .recommend-price-block
            .recommend-block
              .title {{canSelectTask==null?'还不能选':('请选择选'+canSelectTask.total+'个座位')}}
              .recommend-list.grid-4
          .price-block
            .title-block(v-if="canSelectTask!=null") 已选座位 ({{selectedSeats.length}}/{{canSelectTask.total}})
            .box-flex.selected-block
              .selected-seat-item(v-for="seat in selectedSeats" :data-id="seat.seatNo" @click="deleteASeat(seat)")
                .selected-seat-info {{seat.rowId}}排{{seat.columnId}}座
                //- .price-info ¥54
          .submit-block.box-flex
            .submit.flex(data-bid="b_212zq" @click="submit") {{canSelectTask==null?'还不能选座': selectedSeats.length==canSelectTask.total?'确认选座':'请先选座'}}
    mu-dialog(width="360" transition="slide-bottom" fullscreen :open.sync="openFullscreen")
      mu-appbar(color="primary" title="选座注意事项")
        mu-button(slot="left" icon @click="closeFullscreenDialog")
          mu-icon(value="close")
        mu-button(slot="right" flat  @click="closeFullscreenDialog") 同意
      div(style="padding: 24px;") 
        h1 欢迎选座
        | 亲爱的 {{taskInfo.wechatName}} ,
        span(v-if='taskInfo.unfinishedTasks.length>0') 
          | 以下是选座注意事项：
          | 您一共需要选{{taskInfo.unfinishedTasks.length}}次：
          p(v-for="(task, index) in taskInfo.unfinishedTasks") {{index+1}}，序号{{task.serialNo}}，可以选{{task.total}}个座位，等待{{task.waitTime}}分钟
        span(v-else)
          | 您没有需要选的座位了，以下是选座情况：
          p(v-for="(task, index) in taskInfo.myTasks") {{index+1}}，
            span(v-if="task.seatNos!=null&&task.seatNos.length>0") {{task.endTime}} --&gt;
              span(v-for="seatNo in task.seatNos") 已选 [{{getSeatInfo(seatNo)}}]
            span(v-else) {{task.endTime}} --&gt; {{task.status}}
</template>

<script>
import Layout from "@/components/Layout";
import { Toast } from "mint-ui";

export default {
  data: function() {
    return {
      openFullscreen: true,
      taskInfo: {},
      canSelectSeats: [],
      canSelct: false,
      canSelectTask: null,
      hallData: {},
      rowIds: [],
      seats: [],
      hadselectSeats: ["6,25,0000000001"],
      selectedSeats: [],
      maxSeatLength: 0,
      sessionId: 0,
      activity: {
        name: "神奇动物在哪里2",
        time: "2018-11-16 00：00",
        info: ""
      }
    };
  },
  created() {},
  beforeRouteEnter(to, from, next) {
    var activityId = to.params.id;
    next(async vm => {
      var session = await vm.$store.dispatch("getSession", activityId);
      if (session == null) vm.$router.go(-1);
      vm.canSelectSeats = session.seatNos;
      vm.sessionId = session.sessionId;

      vm.taskInfo = await vm.$store.dispatch("getTasks", session.sessionId);
      vm.canSelectTask = vm.taskInfo.canSelectTask;
      vm.canSelct = vm.canSelectTask != null;

      var seats = await vm.$store.dispatch("getSeats", session.sessionId);
      vm.hadselectSeats = seats.filter(x => x.selected).map(x => x.seatNo);

      var hall = await vm.$store.dispatch("getHall", session.hallId);
      vm.hallData = JSON.parse(hall.seatJson);
      var lengtharr = vm.hallData.sections[0].seats.map(x => x.columns.length);
      vm.maxSeatLength = Math.max(...lengtharr);
      vm.rowIds = vm.hallData.sections[0].seats.map(x => x.rowId);
      vm.seats = vm.hallData.sections[0].seats.flatMap(x =>
        x.columns.map((c, i) => {
          return {
            rowId: x.rowId,
            rowNum: x.rowNum,
            columnId: c.columnId,
            seatNo: c.seatNo,
            st: c.st,
            status: !c.seatNo
              ? ""
              : vm.canSelectSeats.findIndex(o => o == c.seatNo) >= 0
                ? vm.hadselectSeats.findIndex(x => x == c.seatNo) >= 0
                  ? 1
                  : 0
                : -1,
            active: false,
            info: JSON.stringify({
              index: "0",
              row: x.rowNum + "",
              column: c.columnId,
              rowId: x.rowId,
              columnId: c.columnId,
              type: c.st,
              seatNo: c.seatNo
            })
          };
        })
      );
    });
  },
  mounted() {},
  methods: {
    onSeatClicked(seat) {
      if (seat.active) this.deleteASeat(seat);
      else this.selectASeat(seat);
    },
    selectASeat(seat) {
      if (!seat.seatNo || seat.status != 0) return;
      if (!this.canSelct) {
        Toast("还不能选座");
        return;
      }
      if (this.selectedSeats.length == this.canSelectTask.total) {
        Toast("最多选择" + this.canSelectTask.total + "个");
        return;
      }
      this.selectedSeats.push(seat);
      seat.active = true;
    },
    deleteASeat(seat) {
      seat.active = false;
      this.selectedSeats.splice(
        this.selectedSeats.findIndex(item => item.seatNo === seat.seatNo),
        1
      );
    },
    getSeatInfo(seatNo) {
      console.log(seatNo);
      var seat = this.seats.find(x => x.seatNo == seatNo);
      console.log(seat);
      if (seat == null) return "";
      else return `${seat.rowId}排${seat.columnId}座`;
    },
    async closeFullscreenDialog() {
      await this.$store.dispatch("taskCheckIn", this.sessionId);
      this.openFullscreen = false;
    },
    async submit() {
      if (this.selectedSeats.length > 0) {
        if (this.selectedSeats.length != this.canSelectTask.total) {
          Toast("请选择" + this.canSelectTask.total + "个座位！");
          return;
        }

        var seatNos = this.selectedSeats.map(x => x.seatNo);
        var sessionId = this.sessionId;
        console.log(sessionId, seatNos);
        await this.$store.dispatch("selectSeat", {
          seatNos,
          sessionId,
          taskId: this.canSelectTask.taskId
        });
      }
    }
  },
  computed: {},
  components: {
    Layout
  },
  directives: {
    drag: {
      // 指令的定义
      componentUpdated: function(el) {
        let odiv = el; //获取当前元素
        let p = document.querySelector(".seat-block .select-block");
        let h = document.querySelector(".select-block .hall-name-wrapper");
        let u = document.querySelector(".select-block .row-nav");

        if (u.children.length <= 0) return;
        let m = document.querySelector(".select-block .seats-block");

        let f = document.querySelector(".select-block .mew-info");
        let v = document.querySelectorAll('.seats-wrap .wrap[data-status="0"]');
        let line = document.querySelector(".m-line");
        let _ = p.clientWidth;
        let g = p.clientHeight;
        let b = m.scrollWidth;
        let w = m.scrollHeight;
        let y = u.children[0].clientWidth;
        let T = (_ - b) / 2; //x
        let E = (g - w) / 2; //y
        let F = 0.4;

        var t = b > w ? _ / b : g / w;
        t * w > g && (t = g / w);
        var A = t;
        A = A > 1 ? 1 : A;
        A = A * 0.8;
        A = A < F ? F : A;
        var I = T;
        var x = E;
        var C = A;

        var scale = A;

        var x2 = (-y * (1 - A)) / 2;
        //银幕位置
        var nameX = b / 2 + T - h.clientWidth / 2;
        //当计数列，则添加样式 -webkit-transform: translateX(-23px);transform: translateX(-23px);
        line &&
          "none" !== getComputedStyle(line)["transform"] &&
          A > 0.8 &&
          (nameX = nameX - 23);

        p.style.height =
          window.innerHeight -
          document.querySelector(".info-block").clientHeight -
          document.querySelector(".buy-block").clientHeight +
          "px";

        m.style.width = m.dataset["maxLength"] * 46 + "px";
        m.style.transform = `translate3d(${T}px, ${E}px, 0px) scale(${scale}, ${scale}) rotate3d(0, 0, 0, 0deg)`;
        u.style.transform = `translate3d(${x2}px, ${E}px, 0px) scale(${scale}, ${scale}) rotate3d(0, 0, 0, 0deg)`;
        h.style.transform = `translate3d(${nameX}px, 0px, 0px) scale(1, 1) rotate3d(0, 0, 0, 0deg)`;

        var X = {
          left: (b / 2) * (A - 1) + 40,
          right: _ - (b / 2) * (1 + A) - 40,
          top: (w / 2) * (A - 1) + 40,
          bottom: g - (w / 2) * (1 + A) - 40
        };

        // T < X.right && (T = X.right);
        // T > X.left && (T = X.left);
        // E < X.bottom && (E = X.bottom);
        // E > X.top && (E = X.top);

        p.ontouchstart = e => {
          //点击位置
          let o_X = e.touches[0].clientX;
          let o_Y = e.touches[0].clientY;

          //算出鼠标相对元素的位置
          let disX = e.touches[0].clientX - T;
          let disY = e.touches[0].clientY - E;
          let disNX = e.touches[0].clientX - nameX;

          console.log({ disX, disY });

          var j = T;
          var P = E;

          document.ontouchmove = e => {
            //位移
            var deltaX = e.touches[0].clientX - o_X;
            var deltaY = e.touches[0].clientY - o_Y;

            console.log({ deltaX, deltaY });

            T = j + deltaX;
            E = P + deltaY;

            //处理滑动范围
            _ > b * A
              ? (T = I)
              : (T < X.right && (T = X.right), T > X.left && (T = X.left));
            g > w * A
              ? (E = x)
              : (E < X.bottom && (E = X.bottom), E > X.top && (E = X.top));

            m.classList.remove("animate");
            u.classList.remove("animate");
            h.classList.remove("animate");

            m.style.transform = `translate3d(${T}px, ${E}px, 0px) scale(${scale}, ${scale}) rotate3d(0, 0, 0, 0deg)`;
            u.style.transform = `translate3d(${x2}px, ${E}px, 0px) scale(${scale}, ${scale}) rotate3d(0, 0, 0, 0deg)`;
            h.style.transform = `translate3d(${nameX}px, 0px, 0px) scale(1, 1) rotate3d(0, 0, 0, 0deg)`;
          };
          p.ontouchend = e => {
            p.ontouchstart = null;
            p.ontouchend = null;

            m.classList.add("animate");
            u.classList.add("animate");
            h.classList.add("animate");
          };
        };

        //点击时滑动
        v.forEach(seat => {
          seat.ontouchstart = e => {
            var clieked = true;
            var el = seat;

            seat.ontouchmove = e => {
              clieked = false;
            };
            seat.ontouchend = e => {
              if (!clieked) return;
              if (!m.dataset["can-selct"]) return;

              //没有放大，计算
              if (!(C >= 0.8)) {
                var t = el;
                var cw = t.clientWidth * A;
                var ch = t.clientHeight * A;
                var a = JSON.parse(t.dataset["info"]);
                var o = (function() {
                  var pNode = t.parentNode;

                  if (0 === pNode.querySelectorAll(".seats-wrap").length)
                    return 0;
                  var n = parseInt(a.index, 10);
                  if (0 === n) return 0;
                  var s = 0;
                  return (
                    pNode.querySelectorAll(".seats-wrap").each(function(t) {
                      t < n && (s += this.clientHeight);
                    }),
                    s
                  );
                })();

                var r = (function() {
                  return {
                    left: (a.column - 1) * cw,
                    top: (a.row - 1) * ch + o * A
                  };
                })();

                _ = document.querySelector(".seat-block .select-block")
                  .clientWidth;
                g = document.querySelector(".seat-block .select-block")
                  .clientHeight;
                var c = ((r.left + cw / 2) / (m.scrollWidth * A)) * b;
                var d = ((r.top + ch / 2) / (m.scrollHeight * A)) * w;

                T = _ / 2 - c;
                E = g / 2 - d;
                A = 0.9;

                var x2 = (-y * (1 - A)) / 2;
                scale = A;

                console.log({ T, E, x2, scale });
                m.style.transform = `translate3d(${T}px, ${E}px, 0px) scale(${scale}, ${scale}) rotate3d(0, 0, 0, 0deg)`;
                u.style.transform = `translate3d(${x2}px, ${E}px, 0px) scale(${scale}, ${scale}) rotate3d(0, 0, 0, 0deg)`;
              }
            };
          };
        });
      }
    }
  }
};
</script>

<style scoped>
.app {
  background-color: #f2f1f6;
}
.seat-block .buy-block {
  bottom: 0;
}
*,
:after,
:before {
  -webkit-box-sizing: unset;
  box-sizing: unset;
}
a {
  text-decoration: none;
}
.confirm_alert {
  width: 280px;
  background: #fff;
  border-radius: 10px;
  -webkit-border-radius: 10px;
  position: fixed;
  margin: auto;
  left: 50%;
  top: 50%;
  -webkit-transform: translateX(-50%) translateY(-50%);
  transform: translateX(-50%) translateY(-50%);
  border: 1px solid #efefef;
  text-align: center;
  z-index: 10000002;
}
.confirm_alert .alert_content {
  padding: 20px;
  border-bottom: 1px solid #efefef;
}
.confirm_alert .alert_buttons {
  font-size: 14px;
  height: 40px;
  line-height: 40px;
}
.confirm_alert a {
  color: #08c;
  float: left;
  width: 50%;
  height: 100%;
  box-sizing: border-box;
  -webkit-box-sizing: border-box;
}
.confirm_alert a.last {
  border-left: 1px solid #efefef;
}
.confirm_alert a.all {
  width: 100%;
}
</style>

<style scoped>
@import "../assets/css/hall-common.css";
</style>
<style scoped>
@import "../assets/css/hall-theme.css";
</style>
<style scoped>
@import "../assets/css/hall-seats.css";
</style>
