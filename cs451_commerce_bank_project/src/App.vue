<template>
  <div id="app">
    <div id="nav">
      <router-link to="/">Login</router-link> |
      <router-link to="/home">Home</router-link> |
      <router-link to="/transactions">Transaction</router-link>
    </div><!-- #nav -->

    <router-view/>
  </div><!-- #app -->
</template>

<script>
export default {
  name: 'App',
  watch: {
        /**
         * Add a listener to update page title on re-route.
         * 
         * @see https://stackoverflow.com/questions/51639850/how-to-change-page-titles-when-using-vue-router
         */
        $route: {
            immediate: true,
            handler(to) {
                const name = 'Commerce Bank';
                document.title = (to.meta.title ? `${to.meta.title} | ${name}` : name);
            }
        },
    }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}
</style>