<template>
<div>
  <div class="customer-details" v-if="customer">
      {{customer.name}}
  </div>
</div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import { CustomerDto } from '@/services';
import { mapState } from 'vuex';

@Component({
  computed: {
    customer() {
        return this.$store.state.customers.find(c => c.id === this.$route.params.id);
    },
  },
})
export default class CustomerDetails extends Vue {
}
</script>
