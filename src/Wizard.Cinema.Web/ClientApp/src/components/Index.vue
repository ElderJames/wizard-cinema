<template lang="pug">
    Layout(:has_share="false" title="活动")
      mu-carousel(class='banner' hide-controls hide-indicators)
        mu-carousel-item
          img(src="https://muse-ui.org/img/carousel4.2a7cbfca.jpg")
      
      //- mu-card(style="width: 100%; max-width: 375px; margin: 0 auto;")
      //-   mu-card-media(title="Image Title")
      //-     img(src="https://muse-ui.org/img/sun.a646a52d.jpg")
      mu-grid-list
        mu-sub-header 广州
        mu-grid-tile(v-for="activity in activities" :cols="2" :rows="1" title-position="bottom" action-position="left" @click="onTileClick(activity)" )
          img(:src="activity.picUrl" style="height:100%;width:100%")
          span(slot="title") {{activity.name}} 
          span(slot="subTitle") {{activity.summary}} 
          mu-button(slot="action" icon)
            mu-icon(value="star_border")
</template>

<script>
let _self;
import Layout from "@/components/Layout";

export default {
  data: function() {
    return {
      activities: []
    };
  },
  created() {
    _self = this;
    this.activities = [
      {
        picUrl: "https://muse-ui.org/img/sun.a646a52d.jpg",
        activityId: 1,
        name: "神期动物在哪里2",
        summary: "首映"
      },
      {
        picUrl: "https://muse-ui.org/img/sun.a646a52d.jpg",
        activityId: 1,
        name: "神期动物在哪里2",
        summary: "周末"
      },
      {
        picUrl: "https://muse-ui.org/img/sun.a646a52d.jpg",
        activityId: 1,
        name: "神期动物在哪里2",
        summary: "三强争霸赛"
      }
    ];
  },
  mounted() {},
  methods: {
    onTileClick(activity) {
      console.log(activity);
    }
  },
  computed: {},
  components: {
    Layout
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="less">
.banner {
  height: 10em;
}
</style>
