<template>
  <div class="container-fluid">
    <div id="wrychain-banner" class="row bg-dark text-white">
      <div class="col m-5">
        <h1 class="p-5 display-1 text-center">Wrychain</h1>
      </div>
    </div>
    <div class="row">
      <div class="col m-5 mb-0">
        <h1 id="login-header" class="py-3 text-center border-start-2">Register</h1>
      </div>
    </div>
    <div class="row">
      <div class="col m-5 mb-0 input-group-lg">
        <label for="username">Username</label>
        <input 
          id="username"
          name="username"
          type="text"
          class="form-control rounded-0"
          :class="usernameBackgroundClass"
          v-model="username"
          @input="checkUsername"
        >
      </div>
    </div>
    <div class="row">
      <div class="col m-5 mb-0 input-group-lg">
        <label for="display_name">Display name</label>
        <input
          id="display_name"
          name="display_name"
          v-model="displayName"
          type="text"
          class="form-control rounded-0"
        >
      </div>
    </div>
    <div class="row">
      <div class="col m-5 mb-0 input-group-lg">
        <label for="password">Password</label>
        <input
          id="password"
          name="password"
          v-model="password"
          type="password"
          class="form-control rounded-0"
          :class="passwordBackgroundClass"
        >
      </div>
    </div>
    <div class="row">
      <div class="col m-5 mb-0 input-group-lg">
        <label for="confirm_password">Confirm password</label>
        <input
          id="confirm_password"
          name="confirm_password"
          v-model="confirmPassword"
          type="password"
          class="form-control rounded-0"
          :class="passwordBackgroundClass"
        >
      </div>
    </div>
    <div class="row">
      <div class="col m-5 mb-0 input-group-lg">
        <label for="token">Token</label>
        <input
          id="token"
          name="token"
          v-model="token"
          type="password"
          class="form-control rounded-0"
          :class="tokenBackgroundClass"
          @input="checkToken"
        >
      </div>
    </div>
    <div class="row">
      <div class="col m-5">
        <form @submit.prevent="onSubmit" class="d-grid input-group-lg">
          <button
            :disabled="!formIsValid"
            id="register-button"
            class="btn bg-white py-3 button-border rounded-0"
            @click="registerSubmit"
            :class="submitBackgroundClass"
          >
            Register
          </button>
        </form>
      </div>
    </div>
    <div class="row py-5 bg-dark" style="border-top: 0.5em solid #b2bec3;">
      <div class="col mx-5">
        <router-link to="/login" class="d-grid input-group-lg text-decoration-none">
          <button id="login-button" class="btn bg-dark py-3 button-border rounded-0 text-white">
            Login
          </button>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, computed } from 'vue'

const username = ref('')
const password = ref('')
const displayName = ref('')
const confirmPassword = ref('')
const token = ref('')
const usernameAvailability = ref('')
const tokenValidity = ref('')

const passwordsMatch = computed(() => {
  return password.value && confirmPassword.value
    ? password.value === confirmPassword.value
    : ''
})

const usernameBackgroundClass = computed(() => {
  if (usernameAvailability.value === 'available') return 'bg-success-subtle'
  if (usernameAvailability.value === 'taken') return 'bg-warning-subtle'
  return ''
})

const passwordBackgroundClass = computed(() => {
  if (!password.value || !confirmPassword.value) return ''
  return passwordsMatch.value ? 'bg-success-subtle' : 'bg-warning-subtle'
})

const tokenBackgroundClass = computed(() => {
  if (!token.value) return ''
  return tokenValidity.value ? 'bg-success-subtle' : 'bg-warning-subtle'
})

const formIsValid = computed(() => {
  return (
    // null checks
    username.value &&
    displayName.value &&
    password.value &&
    confirmPassword.value &&
    token.value &&
    // api results
    usernameAvailability.value === 'available' &&
    tokenValidity.value === 'true' &&
    // background classes
    usernameBackgroundClass.value === 'bg-success-subtle' &&
    tokenBackgroundClass.value === 'bg-success-subtle'
  )
})

const submitBackgroundClass = computed(() => {
  return formIsValid.value ? 'bg-success-subtle' : 'bg-warning-subtle'
})

async function checkUsername() {
  const trimmed = username.value.trim()
  if (!trimmed) {
    usernameAvailability.value = ''
    return
  }

  try {
    const response = await fetch(
      `https://localhost/api/user/check?username=${encodeURIComponent(trimmed)}`
    )
    const result = await response.json()
    usernameAvailability.value = result.available ? 'available' : 'taken'
  } catch (error) {
    console.error('Username check failed:', error)
    usernameAvailability.value = ''
  }
}

async function checkToken() {
  const trimmed = token.value.trim()
  if (!trimmed) {
    tokenValidity.value = ''
    return
  }

  try {
    const response = await fetch(
      `https://localhost/api/invite/platform/check?token=${encodeURIComponent(trimmed)}`
    )
    const result = await response.json()
    tokenValidity.value = result.valid
  } catch (error) {
    console.error('Token check failed:', error)
    tokenValidity.value = ''
  }
}

function registerSubmit() {
  if (!formIsValid) {
    console.log('invalid')
    return
  }
  console.log('submitted')
}
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

#register-button:active
{
  background-color:#dfe6e9 !important;
}

#login-button:active
{
  background-color:#000 !important;
}
</style>
