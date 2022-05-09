<template>
  <v-main>
    <div id="content-wrapper">
      <AppBar />
      <NavBar />
      <div id="page-content">
        <v-card class="mx-auto" max-width="434" tile>
          <v-img
            height="100%"
            src="https://cdn.vuetifyjs.com/images/cards/server-room.jpg"
          >
            <v-row align="end" class="fill-height">
              <v-col align-self="start" class="pa-0" cols="12">
                <v-avatar class="profile" color="grey" size="164" tile>
                  <v-img
                    src="https://static.wikia.nocookie.net/supermonkeyball/images/5/56/Aiai2001.png"
                  ></v-img>
                </v-avatar>
              </v-col>
              <v-col class="py-0">
                <v-list-item color="rgba(0, 0, 0, .4)" dark>
                  <v-list-item-content>
                    <v-list-item-title class="text-h6">
                      Michael Day
                    </v-list-item-title>
                    <v-list-item-subtitle
                      >Customer for 4 years</v-list-item-subtitle
                    >
                  </v-list-item-content>
                </v-list-item>
              </v-col>
            </v-row>
          </v-img>
          <v-list>
            <v-list-item v-for="(item, i) in items" :key="i">
              <v-list-item-icon>
                <v-icon v-text="item.icon"></v-icon>
              </v-list-item-icon>
              <v-list-item-content>
                <v-list-item-title><strong>{{ item.text }}</strong></v-list-item-title>
                {{ item.content }}
              </v-list-item-content>
              <v-list-item-action>
                <v-btn v-if="item.action" icon>
                  <v-icon color="grey lighten-1">{{ item.action }}</v-icon>
                </v-btn>
              </v-list-item-action>
            </v-list-item>
          </v-list>
        </v-card>
      </div>
    </div>
  </v-main>
</template>

<script>
import AppBar from "../components/AppBar.vue";
import NavBar from "../components/NavBar.vue";

export default {
  name: "AccountPage",
  components: {
    NavBar,
    AppBar,
  },
  data: () => ({
    selectedItem: 1,
    items: [
      {
        text: "Full Name",
        content: "Michael Day",
        icon: "mdi-card-account-details",
      },
      { text: "Account ID", content: "1010000749", icon: "mdi-passport" },
      { text: "Username", content: "mumky", icon: "mdi-badge-account" },
      {
        text: "Email Address",
        content: "mumky@gmail.com",
        icon: "mdi-email",
        action: "mdi-pencil",
      },
      {
        text: "Password",
        content: "********",
        icon: "mdi-lock",
        action: "mdi-pencil",
      },
    ],
  }),
};
</script>
