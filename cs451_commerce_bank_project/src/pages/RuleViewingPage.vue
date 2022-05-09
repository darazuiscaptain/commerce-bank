<template>
  <div id="content-wrapper">
    <AppBar />
    <NavBar />
    <div id="page-content">
      <RuleViewer />
    </div>
  </div>
</template>

<script>
import AppBar from "../components/AppBar.vue";
import NavBar from "../components/NavBar.vue";
import RuleViewer from "../components/RuleViewer.vue";

export default {
  name: "NewRulePage",
  components: {
    AppBar,
    NavBar,
    RuleViewer,
  },
};
</script>