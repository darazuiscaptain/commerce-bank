<template>
  <v-main>
    <div id="content-wrapper">
      <AppBar />
      <NavBar />
      <div id="page-content">
        <button type="button" id="new-rule-btn" class="btn primary">
          <router-link to="/transactions/new">
            <v-icon dark> mdi-plus-circle </v-icon>
            Add Transaction
          </router-link>
        </button>
        <VueJsonToCsv
          :json-data="this.data.transactions"
          :csv-title="'transactions_export'"
        >
          <button type="button" id="csv-btn" class="btn primary btn-pretty">
            <v-icon dark> mdi-file-export </v-icon>
            <span style="color: white">Export CSV</span>
          </button>
        </VueJsonToCsv>

        <br /><br /><!-- TODO: remove this hack -->
        <div id="transaction-page">
          <v-card class="mb-1">
            <v-card-title>
              <v-icon>mdi-receipt</v-icon>&nbsp;
              Transactions
              <v-spacer></v-spacer>
              <v-text-field
                v-model="search"
                append-icon="mdi-magnify"
                label="Search"
                single-line
                hide-details
              ></v-text-field>
            </v-card-title>
            <v-data-table
              :headers="headers"
              :items="data.transactions"
              :items-per-page="10"
              :search="search"
              :loading="!data.transactions.length"
              loading-text="Loading... Please wait"
            >
              <template #[`item.type`]="{ item }">
                <v-chip :color="getColor(item.type)" dark>
                  {{ item.type }}
                </v-chip>
              </template>
            </v-data-table>
          </v-card>
        </div>
      </div>
    </div>
  </v-main>
</template>

<script>
/* eslint-disable */
import AppBar from "../components/AppBar.vue";
import NavBar from "../components/NavBar.vue";
import store from "../store.js";
import VueJsonToCsv from "vue-json-to-csv";

export default {
  name: "TransactionPage",

  data() {
    return {
      search: "",
      headers: [
        {
          text: "Account ID",
          align: "start",
          sortable: false,
          value: "userAccountId",
        },
        { text: "Type", value: "type" },
        { text: "Amount", value: "amount", sortable: false },
        { text: "Location", value: "location" },
        { text: "Balance", value: "balance", sortable: false },
        { text: "Processing Date", value: "processingDate", sortable: false },
      ],
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

    const formatter = new Intl.NumberFormat("en-US", {
      style: "currency",
      currency: "USD",
    });
    await this.data.transactions.forEach((e) => {
      e.amount = formatter.format(e.amount);
      e.balance = formatter.format(e.balance);
      e.processingDate = new Date(e.processingDate).toLocaleDateString(
        "en-us",
        { weekday: "long", year: "numeric", month: "short", day: "numeric" }
      );
    });
  },

  components: {
    NavBar,
    AppBar,
    VueJsonToCsv,
  },

  methods: {
    getColor(type) {
      switch (type) {
        case "DR":
          return "green";

        case "CR":
          return "orange";

        default:
          return "blue";
      }
    },
  },
};
</script>

<style scoped>
#new-rule-btn a,
#csv-btn a {
  color: #fff;
  text-decoration: none;
}
h2 {
  padding-top: 15px;
}

#new-rule-btn,
#csv-btn {
  border-radius: 10px;
  border-style: none;
  cursor: pointer;
  font-size: 1em;
  font-weight: 500;
  margin-right: 1em;
}
</style>
