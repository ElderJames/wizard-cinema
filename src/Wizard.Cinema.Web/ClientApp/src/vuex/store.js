import Vue from 'vue';
import Vuex from 'vuex';
import Store from "storejs";

import actions from './api';

import user from './modules/user.js';
import setting from './modules/setting'

const debug = process.env.NODE_ENV !== 'production';

Vue.use(Vuex);
Vue.config.debug = debug;

const myPlugin = store => {
  var auth_token = Store.get('auth_token');
  if (auth_token)
    store.commit('SET_AUTH_TOKEN', auth_token)

  // 当 store 初始化后调用
  store.subscribe((mutation, state) => {
    // 每次 mutation 之后调用
    // mutation 的格式为 { type, payload }
    if (mutation.type == 'SET_AUTH_TOKEN') {
      Store.set('auth_token', mutation.payload)
    }
  })
}

export default new Vuex.Store({
  actions,
  modules: {
    user,
    setting
  },
  strict: debug,
  plugins: [myPlugin]
});
