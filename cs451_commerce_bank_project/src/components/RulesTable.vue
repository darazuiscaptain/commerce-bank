<template>
  <div id="transaction-page">
    <button type="button" id="new-rule-btn" class="btn btn-primary">
      <router-link to="/notification-rules/new" class="nav-link"> New Rule </router-link>
    </button>
    <table class="table">
      <thead>
        <tr>
          <th scope="col">Rule Name</th>
          <th scope="col">Rule Type</th>
          <th scope="col">Times Triggered</th>
          <th scope="col"></th>
        </tr>
      </thead>
      <tbody v-if="this.rules.length > 0">
        <tr v-for="rule in rules" v-bind:key="rule.name">
          <td><router-link :to="`/notification-rules/${rule.id}`">{{ rule.name }}</router-link></td>
          <td>{{ rule.type }}</td>
          <td>{{ rule.countTriggered }}</td>
          <td><router-link :to="`/notification-rules/${rule.id}/edit`">Edit</router-link></td>
        </tr>
      </tbody>
      <tbody v-else>
        <h2>No Rules Found</h2>
      </tbody>
    </table>
  </div>
</template>

<script>
/* eslint-disable */
import store from "../store.js"

export default {
  data() {
    return {
      rules: [{}]
    };
  },

  async mounted() {
    // TODO: handle network errors (e.g. 500) .. axios?
    const response = await fetch(
      `https://localhost:3000/rules/${store.userId}`
    )
    this.rules = (response.status == 200 ? await response.json() : null)
  },
};
</script>

<style scoped>
/* TODO: move this to a css file. */
h2 {
  padding-top: 15px;
}
#new-rule-btn a {
  color: #fff;
}
#new-rule-btn {
  appearance: none;
  backface-visibility: hidden;
  background-color: #006747;
  border-radius: 10px;
  border-style: none;
  box-shadow: none;
  cursor: pointer;
  display: inline-block;
  float: right;
  font-size: 1em;
  font-weight: 500;
  height: 40px;
  width: 100px;
  letter-spacing: normal;
  line-height: 1.5;
  margin-top: 1em;
  margin-bottom: 1.5em;
  margin-right: 1.5em;
  outline: none;
  overflow: hidden;
  right: 15px;
  text-align: center;
  text-decoration: none;
  transform: translate3d(0, 0, 0);
  transition: all 0.3s;
  user-select: none;
  -webkit-user-select: none;
  touch-action: manipulation;
  vertical-align: top;
  white-space: nowrap;
}
</style>
