import Vue from 'vue';
import Vuex from 'vuex';
import { CustomerClient, CustomerDto, AddCustomerCommand, UpdateCustomerCommand, AddCustomerNoteCommand, NoteDto } from '@/services';
import { createClient } from 'http';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    customers: new Array<CustomerDto>(),
    notes: new Array<object>(),
  },
  mutations: {
    SET_CUSTOMERS(state, payload: CustomerDto[]) {
      state.customers.length = 0;
      payload.forEach((element) => {
        state.customers.push(element);
      });
    },
    SET_NOTES(state, payload) {
      state.notes = state.notes.filter(n => n.customerId !== payload.customerId);
      state.notes.push({customerId: payload.customerId, notes: payload.notes});
    },
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

    addCustomer({ dispatch, commit }, payload: AddCustomerCommand) {
      const customerClient = new CustomerClient();
      customerClient.post(payload)
        .then((response) => dispatch('getCustomers'))
        .catch((e) => {
          if (e.status === 409) {
            alert('Customer already exists!');
          } else {
            alert('An error occured during adding customer, please try again.');
          }
        });
    },

    saveCustomer({ dispatch, commit }, payload: UpdateCustomerCommand) {
      const customerClient = new CustomerClient();

      customerClient.put(payload)
        .then((response) => alert('Saved!'))
        .catch((e) => {
          alert('An error occured during updating customer, please try again.');
        });
    },

    getNotes({ dispatch, commit }, customerId: string) {
      const customerClient = new CustomerClient();
      customerClient.getNotes(customerId)
        .then((data) => commit('SET_NOTES', { customerId, notes: data}))
        .catch((e) => {
          alert('An error occured during adding not for customer, please try again.');
        });
    },

    addNote({ dispatch, commit }, payload: AddCustomerNoteCommand) {
      const customerClient = new CustomerClient();
      customerClient.addNote(payload)
        .then((response) => dispatch('getNotes', payload.customerId))
        .catch((e) => {
          alert('An error occured during adding not for customer, please try again.');
        });
    },
  },
});
