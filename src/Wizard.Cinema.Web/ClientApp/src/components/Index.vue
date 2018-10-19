<template lang="pug">
    Layout(:has_share="false" title="活动")
      mu-carousel(class='banner' hide-controls)
        mu-carousel-item
         img(src="https://muse-ui.org/img/carousel4.2a7cbfca.jpg")
      div(class="wrap")
        mu-list
          mu-list-item(title="关于" to="user/about")
            mu-icon(slot="left" value="timeline")
            mu-icon(slot="right" value="keyboard_arrow_right")
</template>

<script>
let _self;
import Layout from "@/components/Layout";

export default {
  data: function() {
    return {};
  },
  created() {
    _self = this;
  },
  mounted() {},
  methods: {},
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
