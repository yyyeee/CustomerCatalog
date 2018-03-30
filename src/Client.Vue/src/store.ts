import Vue from 'vue';
import Vuex from 'vuex';
import { CustomerClient, CustomerDto } from '@/services'
import { createClient } from 'http';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    customers: new Array<CustomerDto>(),
    customerDetails: new Array<CustomerDto>(),
  },
  mutations: {
    SET_CUSTOMERS(state, payload: CustomerDto[]) {
      state.customers.length = 0;
      payload.forEach((element) => {
        state.customers.push(element);
      });
    }
  },
  actions: {
    getCustomers({ commit }) {
      const customerClient = new CustomerClient();
      customerClient.getAll()
        .then((data) => {
          commit('SET_CUSTOMERS', data);
        })
        .catch((e) => alert('An error occured during retrieving customer, please try again.'));
    },

    addCustomer({ dispatch, commit }, data) {
      const customerClient = new CustomerClient();
      customerClient.post(data)
        .then((response) => dispatch('getCustomers'))
        .catch((e) => {
          if (e.status === 409) {
            alert('Customer already exists!');
          } else {
            alert('An error occured during retrieving customer, please try again.');
          }
        });
    },

    saveCustomer({ dispatch, commit }, data) {
      const customerClient = new CustomerClient();
      console.log(data);
    }
  },
});
