const state = {
  is_login: false,
  auth_token: '',
  self_user: {},
  is_cordova: false,
  city: {
    "count": 209,
    "id": 290,
    "n": "北京",
    "pinyinFull": "Beijing",
    "pinyinShort": "bj"
  }
}

// mutations
const mutations = {
  'SET_SELF_USER'(state, user) {
    state.self_user = user;
  },
  'SET_IS_LOGIN'(state, is_login) {
    state.is_login = is_login;
  },
  'UPDATE_SELF_USER'(state, userinfo) {
    for (let key in userinfo) {
      state.self_user[key] = userinfo[key];
    }
  },
  'SET_IS_CORDOVA'(state, is_cordova) {
    state.is_cordova = is_cordova;
  },
  'SET_CITY'(state, city) {
    state.city = city;
  },
  'SET_AUTH_TOKEN'(state, token) {
    state.auth_token = token;
    state.is_login = true;
  },
  'LOG_OUT'(state) {
    state.auth_token = null;
    state.is_login = false;
  }
}

const actions = {
  loginOut({ commit, state }) {
    commit('LOG_OUT')
  }
}


export default {
  state,
  actions,
  mutations
}
