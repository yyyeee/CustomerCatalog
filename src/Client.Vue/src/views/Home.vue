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
import Guid from '@/Guid';

@Component({
  components: {
    CustomerList,
  },
})
export default class Home extends Vue {
  
  mounted () {
    this.items = this.$store.state.customers;
    this.$store.dispatch("getCustomers");
  }

  addCustomer() {
    this.$store.dispatch("addCustomer", { id: Guid.newGuid(), name: 'New customer...'})
  }

  private items: CustomerDto[] = [];
}
</script>
