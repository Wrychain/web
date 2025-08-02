<template>
  <div class="row">
      <div class="col m-5 mb-0 input-group-lg">
        <label for="username">Username</label>
        <input 
          id="username"
          name="username"
          type="text"
          class="form-control rounded-0"
          :class="bgClass"
          v-model="username"
          @input="checkUsername"
        >
      </div>
    </div>
</template>

<script>
export default {
  name: 'UsernameInput',
  data() {
    return {
      username: '',
      status: '', // 'available' | 'taken' | ''
    };
  },
  computed: {
    bgClass() {
      if (this.status === 'available') return 'bg-success-subtle';
      if (this.status === 'taken') return 'bg-warning-subtle';
      return '';
    },
  },
  methods: {
    async checkUsername() {
      const trimmed = this.username.trim();
      if (!trimmed) {
        this.status = '';
        return;
      }

      try {
        const response = await fetch(`https://localhost/api/user/check?username=${encodeURIComponent(trimmed)}`);
        const result = await response.json();
        this.status = result.available ? 'available' : 'taken';
      }
      catch (error) {
        console.error('Username check failed:', error);
        this.status = '';
      }
    },
  },
};
</script>

<style scoped>

</style>
