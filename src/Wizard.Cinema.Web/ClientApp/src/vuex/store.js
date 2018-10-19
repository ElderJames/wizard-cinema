import Vue from 'vue';
import Vuex from 'vuex';
import actions from './api';

import user from './modules/user.js';
import setting from './modules/setting'

const debug = process.env.NODE_ENV !== 'production';

Vue.use(Vuex);
Vue.config.debug = debug;


export default new Vuex.Store({
  actions,
  modules: {
    user,
    setting
  },
  strict: debug,
});
