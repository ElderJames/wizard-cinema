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

export default {
    state,
    mutations
}
