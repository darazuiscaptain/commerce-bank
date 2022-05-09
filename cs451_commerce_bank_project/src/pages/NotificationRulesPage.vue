<template>
  <div id="content-wrapper">
    <AppBar />
    <NavBar />
    <div id="page-content">
      <RulesTable />
    </div>
  </div>
</template>

<script>
import AppBar from "../components/AppBar.vue";
import NavBar from "../components/NavBar.vue";
import RulesTable from "../components/RulesTable.vue";

export default {
  name: "NotificationRulesPage",
  components: {
    AppBar,
    NavBar,
    RulesTable,
  },
};
</script>