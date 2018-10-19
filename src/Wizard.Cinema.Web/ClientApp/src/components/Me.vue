<template lang="pug">
    Layout(:has_share="false" title="我的")
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
    this.$store.state.setting.show_nav = false;
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
</style>
