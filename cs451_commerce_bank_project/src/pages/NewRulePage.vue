<template>
  <div id="content-wrapper">
    <NavBar />
    <div id="page-content">
      <NewRulesForm />
    </div>
  </div>
</template>

<script>
import NavBar from "../components/NavBar.vue"
import NewRulesForm from "../components/NewRuleForm.vue"

export default {
  name: "NewRulePage",
  components: {
    NavBar,
    NewRulesForm,
  },
};
</script>