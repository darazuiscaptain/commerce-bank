<template>
  <div class="container">
    <form class="card" @submit.prevent="onLogin">
      <div class="card-body">
        <v-list>
          <v-list-item class="px-2">
            <v-img src="/cb-logo-color.png"></v-img>
          </v-list-item>
        </v-list>
        <label for="username">Username:</label><br />
        <input
          v-model="data.username"
          placeholder="Enter username"
          required
        /><br /><br />
        <label for="password">Password:</label><br />
        <input
          type="password"
          v-model="data.password"
          placeholder="Enter password"
          required
        /><br /><br />
        <button type="submit">Login</button>
        <router-link to="/user-registration" class="nav-link">
          <h5>Sign Up</h5>
        </router-link>
      </div>
    </form>
  </div>
</template>

<script>
/* eslint-disable */
import store from "../store.js";

export default {
  data() {
    return {
      data: {
        username: "",
        password: "",
      },
    };
  },

  methods: {
    async onLogin() {
      const response = await fetch("https://localhost:3000/login", {
        method: "POST",
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        body: JSON.stringify(this.data),
      })
        .then(async (response) => {
          // store valid user's id in data store
          const data = await response.json();
          store.userId = data.id;
          store.accountId = data.accountId;

          if (response.status == 200) {
            this.$router.push("/transactions");
          } else if (response.status == 400) {
            alert("Username and/or password is incorrect!");
          } else {
            alert("Unable to login.");
          }
        })
        .catch((error) => {
          console.log(error);
        });

      this.data.username = "";
      this.data.password = "";
    },

    async loadItems() {
      const response = await fetch("https://localhost:3000/user");
      this.items = await response.json();
    },
  },
};
</script>

<style scoped>
button {
  appearance: none;
  backface-visibility: hidden;
  background-color: #006747;
  border-radius: 10px;
  border-style: none;
  box-shadow: none;
  color: #fff;
  cursor: pointer;
  display: inline-block;
  font-size: 1em;
  font-weight: 500;
  height: 40px;
  width: 75px;
  letter-spacing: normal;
  line-height: 1.5;
  outline: none;
  overflow: hidden;
  position: absolute;
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

.card {
  height: 22em;
  width: 30em;
  margin: auto;
}

h5 {
  color: #006747;
}

input {
  width: 24em;
}

.nav-link {
  width: 10em;
}

.container {
  margin: auto;
  padding-top: 100px;
}
</style>
