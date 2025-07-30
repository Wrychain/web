<template>
  <div class="container-fluid">
    <div id="wrychain-banner" class="row bg-dark text-white">
      <div class="col m-5">
        <h1 class="p-5 display-1 text-center">Wrychain</h1>
      </div>
    </div>
    <div class="row">
      <div class="col m-5 mb-0">
        <h1 id="login-header" class="py-3 text-center border-start-2">Login</h1>
      </div>
    </div>
    <div class="row">
      <div class="col m-5 mb-0 input-group-lg">
        <label for="username">Username</label>
        <input id="username" type="text" class="form-control rounded-0">
      </div>
    </div>
    <div class="row">
      <div class="col m-5 mb-0 input-group-lg">
        <label for="password">Password</label>
        <input id="password" type="password" class="form-control rounded-0">
      </div>
    </div>
    <div class="row">
      <div class="col m-5 mb-0">
        <label for="duration">Duration ({{ duration }}) days</label>
        <input id="duration" type="range" class="form-range" min="1" max="60" step="1" v-model="duration">
      </div>
    </div>
    <div class="row">
      <div class="col m-5 d-grid input-group-lg">
        <button id="login-button" class="btn bg-white py-3 button-border rounded-0">
          Login
        </button>
      </div>
    </div>
    <div class="row py-5 bg-dark" style="border-top: 0.5em solid #b2bec3;">
      <div class="col mx-5">
        <router-link to="/register" class="d-grid input-group-lg text-decoration-none">
          <button id="register-button" class="btn bg-dark py-3 button-border rounded-0 text-white">
            Register
          </button>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      duration: 14,
    };
  },
};
</script>

<style scoped>
#wrychain-banner
{
  border-bottom: 10px solid #b2bec3;
}

#login-header
{
  border-left: 10px solid #b2bec3;
}

.button-border
{
  transition: border-width 0.1s ease-in-out, border-color 0.1s ease-in-out, background 0.1s ease-in-out !important;
  border-width: 1px 1px 10px 10px !important;
  border-color: #b2bec3 !important;
}

.button-border:active
{
  border-width: 10px 10px 1px 1px !important;
  border-color: #636e72 !important;
}

#login-button:active
{
  background-color:#dfe6e9 !important;
}

#register-button:active
{
  background-color:#000 !important;
}
</style>
