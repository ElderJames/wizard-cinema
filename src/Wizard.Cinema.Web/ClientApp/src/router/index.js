import Vue from 'vue'
import VueRouter from 'vue-router'
import store from '@/vuex/store';

import Index from '@/components/Index'
import Me from '@/components/Me'

Vue.use(VueRouter)

const routes = [{
    path: '/',
    name: 'Index',
    component: Index,
    meta: {
      keepAlive: true
    }
  },
  {
    path: '/apply',
    name: 'Apply',
    component: Me,
    meta: {
      keepAlive: true
    }
  },
  {
    path: '/dicovery',
    name: 'Dicovery',
    component: Me,
    meta: {
      keepAlive: true
    }
  },
  {
    path: '/user',
    name: 'login',
    component: Me,
    meta: {
      keepAlive: true
    }
  },
  {
    path: '/user/login',
    name: 'login',
    component: Me,
    meta: {
      keepAlive: true
    }
  }
]


// scrollBehavior:
// - only available in html5 history mode
// - defaults to no scroll behavior
// - return false to prevent scroll
const scrollBehavior = (to, from, savedPosition) => {
  if (savedPosition) {
    // savedPosition is only available for popstate navigations.
    return savedPosition
  } else {
    const position = {}
    // new navigation.
    // scroll to anchor by returning the selector
    if (to.hash) {
      position.selector = to.hash
    }
    // check if any matched route config has meta that requires scrolling to top
    if (to.matched.some(m => m.meta.scrollToTop)) {
      // cords will be used if no selector is provided,
      // or if the selector didn't match any element.
      position.x = 0
      position.y = 0
    }
    // if the returned position is falsy or an empty object,
    // will retain current scroll position.
    return position
  }
}

const router = new VueRouter({
  mode: 'history',
  base: __dirname,
  scrollBehavior,
  routes: routes
})


router.beforeEach((to, from, next) => {
  console.log(from);
  // 判断配置的路由中是否存在needLogin存在则做出对应的判断
  if (to.matched.some(record => record.meta.needLogin)) {
    // 从状态管理器（vuex）中获取登录状态，如果未登录过的跳转至登录页
    if (!store.state.user.is_login) {
      next({
        path: '/user/login',
      });
    } else {
      // 如果已经登录了的就可以访问该页面
      next();
    }
  } else {
    next();
  }
});

export default router
