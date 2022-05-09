<template>
  <v-app>
    <v-fade-transition mode="out-in">
      <router-view />
    </v-fade-transition>
  </v-app>
</template>

<script>
export default {
  name: "App",
  watch: {
    /**
     * Add a listener to update browser tab page title on re-route.
     *
     * @see https://stackoverflow.com/questions/51639850
     */
    $route: {
      immediate: true,
      handler(to) {
        const name = "Commerce Bank";
        document.title = to.meta.title ? `${to.meta.title} | ${name}` : name;
      },
    },
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}
#page-content {
  margin: 1em;
}
</style>
