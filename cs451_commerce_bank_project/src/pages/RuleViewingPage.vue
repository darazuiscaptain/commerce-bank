<template>
  <div id="content-wrapper">
    <NavBar />
    <div id="page-content">
      <RuleViewer />
    </div>
  </div>
</template>

<script>
import NavBar from "../components/NavBar.vue"
import RuleViewer from "../components/RuleViewer.vue"

export default {
  name: "NewRulePage",
  components: {
    NavBar,
    RuleViewer,
  },
};
</script>