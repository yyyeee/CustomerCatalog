<template>
  <div class="customer-table">
    <vue-good-table
      title="Customers"
      :columns="columns"
      :defaultSortBy="{field: 'creationTime', type: 'desc'}"
      :rows="items">
      <template slot="table-row-after" slot-scope="props">
        <td>
          <router-link :to="{ name: 'customerDetails', params: {id: props.row.id } }">Details</router-link>
        </td>
      </template>
    </vue-good-table>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import { CustomerDto } from '@/services';

@Component
export default class CustomerList extends Vue {
  @Prop() private items: CustomerDto[];

  private columns = [
    {
      label: 'Id',
      field: 'id',
    },
    {
      label: 'Name',
      field: 'name',
      filterable: true,
    },
    {
      label: 'Created On',
      field: 'creationTime',
      type: 'date',
      inputFormat: 'YYYY-MM-DD',
      outputFormat: 'MMM Do YY',
      sortable: true,
    },
    {
      label: 'Status',
      field: 'status',
      type: 'number',
      filterable: true,
      filterDropdown: true,
      formatFn(value: number) {
        switch (value) {
          case 1:
            return 'Prospective';
          case 2:
            return 'Current';
          case 3:
            return 'Non-active';
          default:
            return 'Unknown';
        }
      },
      filterOptions: [
            { value: '1', text: 'Prospective' },
            { value: '2', text: 'Current' },
            { value: '3', text: 'Non-active' }
          ],
    },
    {
      label: 'Details',
    }
  ];
}
</script>
