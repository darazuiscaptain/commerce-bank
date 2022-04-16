<template>
  <div class="container">
    <form class="card" @submit.prevent="onCreate">
      <div class="card-body">
        <h2>User Registration</h2><br>
        <label for="name">Name:</label><br>
        <input
          v-model="data.name"
          placeholder="Enter name"
          required
        ><br><br>
        <label for="emailAddress">Email Address:</label><br>
        <input
          v-model="data.emailAddress"
          placeholder="Enter email address"
          required
        ><br><br>
        <label for="username">Username:</label><br>
        <input
          v-model="data.username"
          placeholder="Enter username"
          required
        ><br><br>
        <label for="password">Password:</label><br>
        <input
          type="password"
          v-model="data.password"
          placeholder="Enter password"
          required
        ><br><br>
        <button type="submit">Create User</button>
        <router-link to="/" class="nav-link">
          <h5>Cancel</h5>
        </router-link>
      </div>
    </form>
  </div>
</template>

<script>
/* eslint-disable */
export default {
  data() {
    return {
      data: {
        name: '',
        emailAddress: '',
        username: '',
        password: ''
      }
    }
  },

  methods: {
    onCreate() {
      const response = fetch('https://localhost:3000/user', {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(this.data)
      }).then((response) => {
        if (response.status == 200) {
          alert('User created successfully!')
          this.$router.push('/notification-rules');
        }
        else if (response.status == 400) {
          alert('User could not be created.')
          this.$router.push('/');
        }
      }).catch((error) => {
        console.log(error);
      });

      this.data.name = '';
      this.data.username = '';
      this.data.password = '';
    },

    async loadItems() {
      const response = await fetch('https://localhost:3000/user')
      this.items = await response.json()
    }
  }
}
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
    font-size: 12px;
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
    transition: all .3s;
    user-select: none;
    -webkit-user-select: none;
    touch-action: manipulation;
    vertical-align: top;
    white-space: nowrap;
}

.card {
  height: 32em;
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
  padding-top: 200px;
}
</style>
