import Vue from 'vue';
import Vuex from 'vuex';
import { CustomerClient, CustomerDto, AddCustomerCommand, UpdateCustomerCommand } from '@/services';
import { createClient } from 'http';
import Guid from '@/Guid';

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

    addCustomer({ dispatch, commit }, name) {
      const customerClient = new CustomerClient();
      customerClient.post(new AddCustomerCommand({ id: Guid.newGuid(), name}))
        .then((response) => dispatch('getCustomers'))
        .catch((e) => {
          if (e.status === 409) {
            alert('Customer already exists!');
          } else {
            alert('An error occured during retrieving customer, please try again.');
          }
        });
    },

    saveCustomer({ dispatch, commit }, payload: UpdateCustomerCommand) {
      const customerClient = new CustomerClient();

      customerClient.put(payload)
        .then((response) => alert('Saved!'))
        .catch((e) => {
          alert('An error occured during retrieving customer, please try again.');
        });
    },
  },
});
