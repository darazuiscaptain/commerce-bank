<template>
  <div id="content-wrapper">
    <NavBar />
    <div id="page-content">
      <RuleEditor />
    </div>
  </div>
</template>

<script>
import NavBar from "../components/NavBar.vue"
import RuleEditor from "../components/RuleEditor.vue"

export default {
  name: "NewRulePage",
  components: {
    NavBar,
    RuleEditor,
  },
};
</script>