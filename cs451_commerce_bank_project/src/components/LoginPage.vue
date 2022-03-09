<template>
  <div class="container">
    <b-card
      title="Login"
    >
    <b-form @login="onClickSave">
      <b-form-group
        id="emailAddress"
        label="Email Address: "
        label-for="emailAddressInput"
      >
        <b-form-input
          id="emailAddressInput"
          class="w-75"
          v-model="data.emailAddress"
          type="email"
          placeholder="Enter email address"
          required
        ></b-form-input>
      </b-form-group>
      <br />
      <b-form-group
        id="password"
        label="Password: "
        label-for="passwordInput"
      >
        <b-form-input
          id="passwordInput"
          class="w-75"
          v-model="data.password"
          placeholder="Enter password"
          required
        ></b-form-input>
      </b-form-group>
      <br />
      <button @click="onLogin">Login</button>
    </b-form>
    </b-card>
  </div>
</template>

<script>
/* eslint-disable */
export default {
  data() {
    return {
      data: {
        emailAddress: '',
        password: ''
      },
      items: []
    }
  },

  methods: {
    async onClickSave() {
      const response = await fetch('https://localhost:3000/user', {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({ name: this.name })
      })

      this.name = ''
      await this.loadItems();
    },

    onLogin() {
      debugger;
      console.log(this.data);
      const response = fetch('https://localhost:3000/login', {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(this.data)
      })
    },

    async loadItems() {
      const response = await fetch('https://localhost:3000/user')
      this.items = await response.json()
    }
  }
}
</script>

<style scoped>
div {
  width: 400px;
  margin: auto;
}

input {
  margin-right: 100px;
}

button {
    appearance: none;
    backface-visibility: hidden;
    background-color: #2f80ed;
    border-radius: 10px;
    border-style: none;
    box-shadow: none;
    color: #fff;
    cursor: pointer;
    display: inline-block;
    font-size: 15px;
    font-weight: 500;
    height: 40px;
    width: 75px;
    letter-spacing: normal;
    line-height: 1.5;
    outline: none;
    overflow: hidden;
    position: relative;
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

.container {
  margin: auto;
  padding-top: 150px;
}
</style>
