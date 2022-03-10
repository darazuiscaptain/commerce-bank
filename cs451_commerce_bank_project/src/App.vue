<template>
  <div id="app">
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <div class="container-fluid">
        <a class="navbar-brand">Commerce Bank</a>
        <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
          <div class="navbar-nav">
            <router-link to="/" class="nav-link">Login</router-link>
            <router-link to="/home" class="nav-link">Home</router-link>
            <router-link to="/transactions" class="nav-link">Transactions</router-link>
          </div>
        </div>

        <form class="d-flex">
          <input
            class="form-control me-2"
            type="search"
            placeholder="Search"
            aria-label="Search"
          />
          <button class="btn" type="submit">Search</button>
        </form>
      </div>
    </nav>

    <router-view />
  </div>
  <!-- #app -->
</template>

<script>
export default {
  name: "App",
  watch: {
    /**
     * Add a listener to update page title on re-route.
     *
     * @see https://stackoverflow.com/questions/51639850/how-to-change-page-titles-when-using-vue-router
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
#app>nav {
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