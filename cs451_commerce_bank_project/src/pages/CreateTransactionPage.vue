<template>
<v-main>
  <div id="content-wrapper">
    <NavBar />
    <div id="page-content">
      <div id="transaction-page">
        <h2>Create a Transaction</h2>
        <label>Type</label><br>
        <input
          v-model="transaction.type"
          placeholder="Enter transaction type"
          required
        ><br><br>
        <label>Amount</label><br>
        <input
          v-model.number="transaction.amount"
          placeholder="Enter amount"
          required
        ><br><br>
        <label>Location</label><br>
        <input
          v-model="transaction.location"
          placeholder="Enter transaction location"
          required
        ><br><br>
        <label>Balance</label><br>
        <input
          v-model.number="transaction.balance"
          placeholder="Enter account balance"
          required
        ><br><br>
        <label>Processing Date</label><br>
        <input
          type="datetime-local"
          v-model="transaction.processingDate"
          placeholder="Enter transaction processing date"
          required
        ><br><br>
        <label>Description</label><br>
        <input
          v-model="transaction.description"
          placeholder="Enter description"
        ><br><br>
        <button @click="onSubmit">Submit</button>
      </div>
    </div>
  </div>
</v-main>
</template>

<script>
/* eslint-disable */
import NavBar from "../components/NavBar.vue";
import store from '../store.js';

export default {
  data() {
    return {
      transaction: {
        userAccountId: store.accountId,
        type: undefined,
        amount: undefined,
        location: undefined,
        balance: undefined,
        processingDate: undefined,
        description: undefined
      }
    }
  },

  methods: {
    onSubmit() {
      console.log(this.transaction);
      const response = fetch('https://localhost:3000/transaction', {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(this.transaction)
      }).then((response) => {
        if (response.status == 200) {
          alert('Transaction created successfully!')
        }
        else if (response.status == 400) {
          alert('Transaction could not be created.')
        }
        this.$router.push('/transactions');
      }).catch((error) => {
        console.log(error);
      });

      this.transaction.userAccountId = undefined;
      this.transaction.type = '';
      this.transaction.amount = undefined;
      this.transaction.location = '';
      this.transaction.balance = undefined;
      this.transaction.processingDate = undefined,
      this.transaction.description = '';
    },
  },

  components: {
    NavBar,
  }
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
    width: 100px;
    letter-spacing: normal;
    line-height: 1.5;
    margin-bottom: 1.5em;
    margin-right: 15em;
    outline: none;
    overflow: hidden;
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

input {
  width: 35em;
}
</style>
