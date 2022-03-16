<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light">
    <div class="container-fluid">
      <a class="navbar-brand">Commerce Bank</a>
      <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
        <div class="navbar-nav">
          <router-link to="/" class="nav-link"> Login </router-link>
          <router-link to="/home" class="nav-link"> Home </router-link>
          <router-link to="/transactions" class="nav-link">
            Transactions
          </router-link>
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
</template>
<script>
export default {};
</script>