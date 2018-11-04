<template lang="pug">
    Layout(:has_share="false" title="活动")
      mu-carousel(class='banner' hide-controls hide-indicators)
        mu-carousel-item
          img(src="https://muse-ui.org/img/carousel4.2a7cbfca.jpg")
      mu-grid-list
        mu-sub-header 广州
        mu-grid-tile(v-for="(activity,index) in activities" :key="index" :cols="2" :rows="1" title-position="bottom" action-position="left" @click="onTileClick(activity)" )
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
      activities: [],
      a_page: 1,
      a_size: 10
    };
  },
  async created() {
    _self = this;
    await this.setList(1, 100);
  },
  mounted() {},
  methods: {
    async onTileClick(activity) {
      console.log(activity);
   
   
      this.$router.push({ path: `/hall/${activity.activityId}` });
    },
    async setList(page, size) {
      var list = await this.$store.dispatch("getActivityList", { page, size });
      console.log(list);
      this.activities = list.map(x => {
        return {
          activityId: x.activityId,
          name: x.name,
          summary: x.summary,
          picUrl: x.thumbnail
        };
      });
    },
    async getSession(id) {
      console.log(session);
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
