<template>
  <div id="app">
    <router-view />
  </div>
  <!-- #app -->
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
  color: #2c3e50;
}

/*
TODO: Eliminate the CSS below.

This is very much a CSS hack just to get the navbar looking nice for
demonstration purposes. We'll want to look into the proper Bootstrap
approach for doing things like changing colors.

We'll want to use the Commerce Bank CSS styling file once that's been
merged into the main branch.
*/
#app > nav {
  background-color: #006747 !important;
}
#app .nav-link,
#app .navbar-brand,
#app .btn {
  /* font-weight: bold; */
  color: lightgray;
}
#transaction-page,
#home-page {
  width: 75%;
  margin: 3em auto;
}
</style>
