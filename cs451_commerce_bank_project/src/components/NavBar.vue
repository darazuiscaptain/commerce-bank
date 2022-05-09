<template>
  <v-navigation-drawer permanent app clipped dark
  class="primary">
    <v-list>
      <v-list-item class="px-2">
        <v-img src="/cb-logo.png"></v-img>
      </v-list-item>
    </v-list>

    <v-divider></v-divider>

    <v-list dense nav>
      <v-list-item
        v-for="item in items"
        :key="item.title"
        link
        :to="item.route"
        @click="item.action"
        class="text-decoration-none"
      >
        <v-list-item-icon>
          <v-icon>{{ item.icon }}</v-icon>
        </v-list-item-icon>

        <v-list-item-content>
          <v-list-item-title>{{ item.title }}</v-list-item-title>
        </v-list-item-content>
      </v-list-item>
      <v-divider></v-divider>
      <v-list-item>
      <LightDarkSwitch />
      </v-list-item>
    </v-list>
    <template #append>
      <div class="pa-4 text-center">
        <v-btn
          href="https://www.facebook.com/commercebank"
          target="_blank"
          style="text-decoration: none"
          icon
        >
          <v-icon> mdi-facebook </v-icon>
        </v-btn>
        <v-btn
          href="https://www.twitter.com/commercebank"
          target="_blank"
          style="text-decoration: none"
          icon
        >
          <v-icon> mdi-twitter </v-icon>
        </v-btn>
        <v-btn
          href="https://www.linkedin.com/company/commerce_bank  "
          target="_blank"
          style="text-decoration: none"
          icon
        >
          <v-icon> mdi-linkedin </v-icon>
        </v-btn>
        <v-btn
          href="https://www.instagram.com/commercebank"
          target="_blank"
          style="text-decoration: none"
          icon
        >
          <v-icon> mdi-instagram </v-icon>
        </v-btn>
        <br /><br />
        <span style="color: lightgray">
          Copyright © 2022 Commerce Bancshares, Inc.
        </span>
        <br /><br />
      </div>
    </template>
  </v-navigation-drawer>
</template>

<script>
/* eslint-disable */
import store from "../store.js";
import LightDarkSwitch from "../components/LightDarkSwitch.vue";

export default {
  data() {
    return {
      items: [
        { title: "Transactions", icon: "mdi-receipt", route: "/transactions" },
        { title: "Notification Rules", icon: "mdi-bell", route: "/notification-rules" },
        { title: "Your Account", icon: "mdi-account", route: "/account" },
        {
          title: "Logout",
          icon: "mdi-logout",
          action: this.onLogout,
        },
      ],
      right: null,
    };
  },
  methods: {
    onLogout() {
      store.userId = null;
      this.$router.push("/");
    },
  },
  components: {
    LightDarkSwitch,
  },
};
</script>
