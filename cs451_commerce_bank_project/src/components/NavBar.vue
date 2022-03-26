<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light">
    <div class="container-fluid">
      <a class="navbar-brand">Commerce Bank</a>
      <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
        <div class="navbar-nav">
          <router-link to="/notification-rules" class="nav-link"> Rules </router-link>
          <router-link to="/transactions" class="nav-link">
            Transactions
          </router-link>
        </div>
      </div>
      <!-- <router-link @click="onLogout()" to="/" class="nav-link"> Logout </router-link> -->
      <a @click="onLogout()" class="nav-link"> Logout </a>
    </div>
  </nav>
</template>

<script>
/* eslint-disable */
import store from '../store.js';

export default {
  methods: {
    onLogout() {
      store.userId = null;
      this.$router.push('/');
    }
  }
};
</script>
