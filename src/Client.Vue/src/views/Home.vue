<template>
  <div class="home">
    <CustomerList v-bind:items="items"/>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import CustomerList from '@/components/CustomerList.vue';

@Component({
  components: {
    CustomerList,
  },
})
export default class Home extends Vue {
  
  mounted () {
    this.$store.dispatch("getCustomers");
    this.items = this.$store.state.customers;
  }

  private items: string[] = [];
}
</script>
