<template>
  <v-main>
    <div id="content-wrapper">
      <AppBar />
      <NavBar />
      <div id="page-content">
        <RuleEditor />
      </div>
    </div>
  </v-main>
</template>

<script>
import AppBar from "../components/AppBar.vue";
import NavBar from "../components/NavBar.vue";
import RuleEditor from "../components/RuleEditor.vue";

export default {
  name: "NewRulePage",
  components: {
    AppBar,
    NavBar,
    RuleEditor,
  },
};
</script>