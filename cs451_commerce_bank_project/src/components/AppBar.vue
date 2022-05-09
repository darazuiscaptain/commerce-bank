<template>
  <div style="text-align: right; margin: 1em">
    <router-link to="/transactions" class="text-decoration-none">
      <v-badge color="red" content="2">
        <v-icon> mdi-receipt </v-icon>
      </v-badge>
    </router-link>
    &nbsp; &nbsp; &nbsp;
    <router-link to="/notification-rules" class="text-decoration-none">
      <v-icon> mdi-bell </v-icon>
    </router-link>
    &nbsp; &nbsp; &nbsp;
    <router-link to="/account" class="text-decoration-none">
      <v-icon> mdi-account </v-icon>
    </router-link>
    &nbsp; &nbsp; &nbsp;
    <v-icon @click="this.onLogout"> mdi-logout </v-icon>
  </div>
</template>

<script>
import store from "../store.js";

export default {
  name: "AppBar",
  methods: {
    onLogout() {
      store.userId = null;
      this.$router.push("/");
    },
  },
};
</script>
