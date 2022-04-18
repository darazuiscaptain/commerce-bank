<template>
  <div id="rule-view-wrapper">
    <button type="button" class="btn btn-primary btn-pretty">
      <router-link to="/notification-rules"> ⬅ Back to Rules </router-link>
    </button>
    <h2>Rule Details</h2>
    <ul>
      <li>Name: {{ rule.name }}</li>
      <li>Type: {{ rule.type }}</li>
      <li v-if="rule.type == 'Location'">Location: {{ rule.location }}</li>
      <li v-if="rule.type == 'Amount'">Amount: ${{ rule.amountGreaterThan }}</li>
    </ul>
  </div>
</template>

<script>
export default {
  data() {
    return {
      rule: {
        id: null,
        userId: null,
        user: null,
        name: null,
        type: null,
        startTime: null,
        endTime: null,
        location: null,
        amountGreaterThan: 0,
        amountLessThan: 0,
        amountEquals: 0,
        countTriggered: 0,
      },
    };
  },
  async mounted() {
    const response = await fetch(
      `https://localhost:3000/rules/single/${this.$route.params.id}`
    );
    if (response.status == 200) {
      this.rule = await response.json();
    }
  },
};
</script>

<style scoped>
/* TODO: move this to a css file. */
.btn-pretty a {
  color: #fff;
}
.btn-pretty {
  appearance: none;
  backface-visibility: hidden;
  background-color: #006747;
  border-radius: 10px;
  border-style: none;
  box-shadow: none;
  cursor: pointer;
  display: inline-block;
  font-size: 1em;
  font-weight: 500;
  height: 40px;
  letter-spacing: normal;
  line-height: 1.5;
  margin-bottom: 1.5em;
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
