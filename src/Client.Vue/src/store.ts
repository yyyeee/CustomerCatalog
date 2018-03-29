import Vue from 'vue';
import Vuex from 'vuex';
import { CustomerClient, CustomerDto } from '@/services'

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    customers: new Array<CustomerDto>()
  },
  mutations: {
    SET_CUSTOMERS (state, payload: CustomerDto[]) {
      payload.forEach(element => {
        state.customers.push(element)        
      });
    },
    ADD_CUSTOMER (state, payload) {
      state.customers.unshift(payload)
    }
  },
  actions: {
    getCustomers ({ commit }) {
      var customerClient = new CustomerClient();
      customerClient.getAll()
        .then(data => {
          commit('SET_CUSTOMERS', data)
        })
        .catch(e => alert('An error occured during retrieving customer, please try again.'));
      
    },

    addCustomer ({ commit }, data) {
      var customerClient = new CustomerClient();
      customerClient.post(data)
        .then(response => commit('ADD_CUSTOMER', data))
        .catch(e => {
          if (e.status === 409) {
            alert('Customer already exists!')
          } else {
            alert('An error occured during retrieving customer, please try again.')
          }
        });
    }
  },
});
