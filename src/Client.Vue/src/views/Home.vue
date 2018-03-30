<template>
  <div class="home">
    <button @click="addCustomer">Add customer</button>
    <CustomerList v-bind:items="items"/>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import CustomerList from '@/components/CustomerList.vue';
import { CustomerDto } from '@/services';

@Component({
  components: {
    CustomerList,
  },
})
export default class Home extends Vue {
  private items: CustomerDto[] = [];

  public mounted() {
    this.items = this.$store.state.customers;
  }

  public addCustomer() {
    this.$store.dispatch('addCustomer', 'New customer...');
  }
}
</script>
