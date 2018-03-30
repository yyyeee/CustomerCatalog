<template>
<div>
  <div class="customer-details" v-if="customer">
    <div>
        <label>Customer name</label>
        <input id="customerNameInput" v-model="customer.name" placeholder="Customer name">
    </div>
    <div>
        <label>Status</label>
        <select id="customerStatusSelect" v-model="customer.status">
            <option v-for="option in statuses" v-bind:value="option.value">
                {{ option.text }}
            </option>
        </select>
    </div>
    <button @click="addNote" id="addNoteButton">Add note</button>
    <button @click="save" id="saveButton">Save changes</button>
  </div>
</div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import { CustomerDto } from '@/services';
import { mapState } from 'vuex';

@Component({
  computed: {
    customer(): CustomerDto {
        return this.$store.state.customers.find(c => c.id === this.$route.params.id);
    },
  },
  data() {
    return {
      statuses: [
      { text: 'Prospective', value: '1' },
      { text: 'Current', value: '2' },
      { text: 'Non-active', value: '3' },
    ]};
  },
})
export default class CustomerDetails extends Vue {
    public save() {
        const command = { id: this.customer.id  };
        this.$store.dispatch('saveCustomer', command);
    }

    public addNote() {
        const note = prompt('Please add note for customer:');
        if (note !== null) {
            console.log(note);
        }
    }
}
</script>
