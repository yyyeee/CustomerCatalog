<template>
  <div class="hello">
    <h3>Customers</h3>
    <ul>
      <li v-for="item in items">
        {{ item }}
      </li>
    </ul>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class HelloWorld extends Vue {
  @Prop() private items: string[];
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
