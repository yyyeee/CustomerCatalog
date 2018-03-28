import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    customers: new Array<string>()
  },
  mutations: {
    SET_CUSTOMERS (state, payload) {
      state.customers = payload
    }

  },
  actions: {
    getCustomers ({ commit }) {
      fetch("http://172.23.1.72/api/customer",  {mode: 'no-cors'})
        .then(stream => stream.text())
        .then(data => console.log(data));
      let customers = ["lolek", "bolek"]
      commit('SET_CUSTOMERS', customers)
    }
  },
});
