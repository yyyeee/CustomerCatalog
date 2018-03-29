<template>
  <div class="hello">
    <vue-good-table
      title="Customers"
      :columns="columns"
      :rows="items"
      :paginate="true"/>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import { CustomerDto } from '@/services';

@Component
export default class HelloWorld extends Vue {
  @Prop() private items: CustomerDto[];
  
  private columns = [
    {
      label: 'Id',
      field: 'id'
    },
    {
      label: 'Name',
      field: 'name',
      filterable: true
    },
    {
      label: 'Created On',
      field: 'creationTime',
      type: 'date',
      inputFormat: 'YYYY-MM-DD',
      outputFormat: 'MMM Do YY',
      sortable: true
    },
    {
      label: 'Status',
      field: 'status',
      filterable: true,
      filterDropdown: true,
      formatFn: function(value: number) {
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
    }
  ];
}
</script>
