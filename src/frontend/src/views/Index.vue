<template>
  <div class="container-fluid">
    <div class="row">
      <div id="wrychain-banner" class="col vh-100 d-flex align-items-center justify-content-center">

        <div class="box text-center">
          <h1 id="wrychain-header" class="display-1 mb-5 py-4">Wrychain</h1>
          <div class="p-5 bg-light">Trust is your social network.</div>
        </div>

      </div>
    </div>
    <div id="login" class="row bg-dark">
      <router-link to="/login" class="p-0 text-decoration-none text-white">
        <div class="col p-5 display-6">
          Login
        </div>
      </router-link>
    </div>
    <div class="row bg-dark">
      <router-link to="/register" class="p-0 text-decoration-none text-white">
        <div class="col mx-0 p-5 display-6">
          Register
        </div>
      </router-link>
    </div>
  </div>
</template>

<script>
</script>

<style scoped>
div#wrychain-banner
{
  border-bottom: 10px solid #b2bec3;
}
h1#wrychain-header
{
  border-left: 10px solid #b2bec3;
}
div#login
{
  border-bottom: 1px solid #636e72;
}
</style>
