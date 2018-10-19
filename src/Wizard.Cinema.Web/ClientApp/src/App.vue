<template lang="pug">
  #app
    transition(:name="transitionName")
      keep-alive
        router-view(v-if="$route.meta.keepAlive")
    transition(:name="transitionName")
      router-view(v-if="!$route.meta.keepAlive")
    mu-bottom-nav(id="bottom-nav" :value="active_nav" @change="handleNavChange" shift v-if="$store.state.setting.show_nav")
      mu-bottom-nav-item(v-for="nav in bottom_nav" :value="nav.value" :title="nav.title" :icon="nav.icon" :key="nav.title" :to="nav.value" replace)
</template>
<script>
let _self;
import Store from "storejs";
// import def from '!raw-loader!muse-ui/dist/theme-default.css';
// import light from '!raw-loader!muse-ui/dist/theme-light.css';
// import dark from '!raw-loader!muse-ui/dist/theme-dark.css';
// import carbon from '!raw-loader!muse-ui/dist/theme-carbon.css';
// import teal from '!raw-loader!muse-ui/dist/theme-teal.css';
import theme from "muse-ui/lib/theme";

export default {
  name: "app",
  data() {
    return {
      transitionName: "",
      themes: {
        // def,
        // light,
        // dark,
        // carbon,
        // teal
      },
      active_nav: "/",
      bottom_nav: [
        {
          title: "活动",
          value: "/",
          icon: "subscriptions"
        },
        {
          title: "报名",
          value: "/applyer",
          icon: "movie"
        },
        {
          title: "发现",
          value: "/dicovery",
          icon: "tv"
        },
        {
          title: "我的",
          value: "/user",
          icon: "favorite"
        }
      ]
    };
  },
  watch: {
    // 页面切换过渡动画逻辑
    $route(to, from) {
      const toDepth = to.path.split("/").length;
      const fromDepth = from.path.split("/").length;
      // this.transitionName = toDepth < fromDepth ? 'slide-right' : 'slide-left'
      // console.log('toDepth: '+ toDepth + '\n fromDepth: ' + fromDepth);
      if (toDepth === fromDepth) {
        this.transitionName = "";
      }
      if (toDepth < fromDepth) {
        this.transitionName = "slide-right";
      }
      if (toDepth > fromDepth) {
        this.transitionName = "slide-left";
      }
    }
  },
  created() {
    _self = this;
    this.setTheme();
    this.setIsCordova();
  },
  methods: {
    setTheme() {
      // let local_theme = Store.get("theme") || ""; // 获取本地主题
      const styleEl = this.getThemeStyle();
      // styleEl.innerHTML = this.themes[local_theme] || "";
      theme.use("light");
    },
    getThemeStyle() {
      const themeId = "muse-theme";
      let styleEl = document.getElementById(themeId);
      if (styleEl) return styleEl;
      styleEl = document.createElement("style");
      styleEl.id = themeId;
      document.body.appendChild(styleEl);
      return styleEl;
    },
    setIsCordova() {
      document.addEventListener(
        "deviceready",
        () => {
          _self.$store.commit("SET_IS_CORDOVA", true);
        },
        false
      );
    },
    handleNavChange(val) {
      this.active_nav = val;
      // this.$router.push(val);
    }
  }
};
</script>
<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}

#bottom-nav {
  width: 100%;
  position: fixed;
  bottom: 0px;
}

.slide-right-enter-active,
.slide-right-leave-active,
.slide-left-enter-active,
.slide-left-leave-active {
  will-change: transform;
  transition: all 250ms;
  height: 100%;
  top: 0;
  position: absolute;
  backface-visibility: hidden;
  perspective: 1000;
}

.slide-right-enter {
  opacity: 0;
  transform: translate3d(-100%, 0, 0);
}

.slide-right-leave-active {
  opacity: 0;
  transform: translate3d(100%, 0, 0);
}

.slide-left-enter {
  opacity: 0;
  transform: translate3d(100%, 0, 0);
}

.slide-left-leave-active {
  opacity: 0;
  transform: translate3d(-100%, 0, 0);
}
</style>
