<template>
  <div id="content-wrapper">
    <NavBar />
    <div id="page-content">
      <button type="button" id="new-rule-btn" class="btn btn-primary">
        <router-link to="/transactions/new" class="nav-link">
          Add Transaction
        </router-link>
      </button>
      <VueJsonToCsv :json-data="this.data.transactions" :csv-title="'transactions_export'">
        <button type="button" id="csv-btn" class="btn btn-primary btn-pretty">
          Export CSV
        </button>
      </VueJsonToCsv>
      <div id="transaction-page">
        <table class="table">
          <thead>
            <tr>
              <th scope="col">Account ID</th>
              <th scope="col">Type</th>
              <th scope="col">Amount</th>
              <th scope="col">Location</th>
              <th scope="col">Balance</th>
              <th scope="col">Processing Date</th>
            </tr>
          </thead>
          <tbody v-if="this.data.transactions.length > 0">
            <tr v-for="item in this.data.transactions" v-bind:key="item">
              <td>{{ item.userAccountId }}</td>
              <td>{{ item.type }}</td>
              <td>${{ item.amount }}</td>
              <td>{{ item.location }}</td>
              <td>${{ item.balance }}</td>
              <td>{{ item.processingDate }}</td>
            </tr>
          </tbody>
          <tbody v-else>
            <h2>No Transactions Found</h2>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
/* eslint-disable */
import NavBar from "../components/NavBar.vue";
import store from "../store.js";
import VueJsonToCsv from "vue-json-to-csv";

export default {
  name: "TransactionPage",

  data() {
    return {
      data: {
        transactions: [{}],
      },
    };
  },

  async mounted() {
    const response = await fetch(
      `https://localhost:3000/transaction?accountId=${store.accountId}`
    );
    this.data.transactions = await response.json();
  },

  components: {
    NavBar,
    VueJsonToCsv,
  },
};
</script>

<style scoped>
#new-rule-btn router-link,
#csv-btn router-link {
  color: #fff;
}
h2 {
  padding-top: 15px;
}

#new-rule-btn,
#csv-btn {
  appearance: none;
  backface-visibility: hidden;
  background-color: #006747;
  border-radius: 10px;
  border-style: none;
  box-shadow: none;
  box-sizing: border-box;
  cursor: pointer;
  display: inline-block;
  float: right;
  font-size: 1em;
  font-weight: 500;
  height: 40px;
  width: 110px;
  letter-spacing: normal;
  line-height: 1em;
  margin-top: 1em;
  margin-bottom: 1.5em;
  margin-right: 1.5em;
  outline: none;
  overflow: hidden;
  padding: 0;
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
