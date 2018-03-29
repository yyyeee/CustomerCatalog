<template>
  <div class="hello">
    <h3>Customers</h3>
    <ul>
      <li v-for="item in items">
        {{ item.name }}
      </li>
    </ul>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import { CustomerDto } from '@/services';

@Component
export default class HelloWorld extends Vue {
  @Prop() private items: CustomerDto[];
}
</script>

<style scoped lang="scss">
ul {
  list-style-type: none;
  padding: 0;
}
a {
  color: #42b983;
}
</style>
