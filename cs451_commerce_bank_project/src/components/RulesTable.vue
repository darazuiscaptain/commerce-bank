<template>
  <v-main>
    <div id="transaction-page">
      <router-link to="/notification-rules/new">
        <button type="button" id="new-rule-btn" class="btn primary btn-pretty">
          <v-icon dark> mdi-plus-circle </v-icon>
          <span style="color: white">New Rule</span>
        </button>
      </router-link>
      <VueJsonToCsv :json-data="this.rules" :csv-title="'rules_export'">
        <button type="button" id="csv-btn" class="btn primary btn-pretty">
          <v-icon dark> mdi-file-export </v-icon>
          <span style="color: white">Export CSV</span>
        </button>
      </VueJsonToCsv>

      <br /><br /><!-- TODO: remove this hack -->
      <v-card class="mb-1">
        <v-card-title>
          <v-icon>mdi-bell</v-icon>&nbsp;
          Notification Rules
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
          :items="rules"
          :items-per-page="10"
          :search="search"
          :loading="!rules.length"
          loading-text="Loading... Please wait"
        >
          <template #[`item.actions`]="{ item }">
            
            <router-link :to="`/notification-rules/${item.id}/edit`" class="text-decoration-none">
            <v-icon small class="mr-2">
              mdi-pencil
            </v-icon>
            Edit
            </router-link>
          </template>
        </v-data-table>
      </v-card>
    </div>
  </v-main>
</template>

<script>
/* eslint-disable */
import store from "../store.js";
import VueJsonToCsv from "vue-json-to-csv";

export default {
  data() {
    return {
      search: "",
      headers: [
        {
          text: "Rule Name",
          align: "start",
          value: "name",
        },
        { text: "Rule Type", value: "type" },
        { text: "Count Triggered", value: "countTriggered" },
        { text: "Actions", value: "actions", sortable: false },
      ],
      rules: [{}],
    };
  },
  components: {
    VueJsonToCsv,
  },
  async mounted() {
    // TODO: handle network errors (e.g. 500) .. axios?
    const response = await fetch(
      `https://localhost:3000/rules/${store.userId}`
    );
    this.rules = response.status == 200 ? await response.json() : null;
  },
};
</script>

<style scoped>
/* TODO: move this to a css file. */
h2 {
  padding-top: 15px;
}
#new-rule-btn router-link,
#csv-btn router-link {
  color: #fff;
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
