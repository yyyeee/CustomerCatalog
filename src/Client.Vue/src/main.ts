import Vue from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';
import VueGoodTablePlugin from 'vue-good-table';

Vue.use(VueGoodTablePlugin);

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount('#app');
