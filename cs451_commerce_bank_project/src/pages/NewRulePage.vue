<template>
  <v-main>
    <div id="content-wrapper">
      <NavBar />
      <div id="page-content">
        <NewRuleForm />
      </div>
    </div>
  </v-main>
</template>

<script>
import NavBar from "../components/NavBar.vue";
import NewRuleForm from "../components/NewRuleForm.vue";

export default {
  name: "NewRulePage",
  components: {
    NavBar,
    NewRuleForm,
  },
};
</script>