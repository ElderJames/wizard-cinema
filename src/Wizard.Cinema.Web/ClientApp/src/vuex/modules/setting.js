const state = {
  show_nav: true
}

const mutations = {
  'HIDE_NAV'(state) {
    state.show_nav = false;
  },
  'SHOW_NAV'(state) {
    state.show_nav = true;
  }
}

const actions = {
  hideNav({
    commit,
    state
  }) {
    commit('HIDE_NAV')
  },
  showNav({
    commit,
    state
  }) {
    commit('SHOW_NAV')
  }
}

export default {
  state,
  mutations,
  actions
}
