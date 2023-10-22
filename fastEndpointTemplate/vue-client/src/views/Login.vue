<template>
  <v-container class="d-flex justify-center">
    <v-form class="w-50">
      <v-text-field v-model="email" label="Email"></v-text-field>
      <v-text-field v-model="password" label="Password" type="password"></v-text-field>
      <v-btn @click="login">Login</v-btn>
      <router-link to="/register"><v-btn>Register</v-btn></router-link>
    </v-form>
  </v-container>
</template>

<script setup lang="ts">
  import { ref } from 'vue';
  import AuthService from '../Services/Api/AuthService';
  import { useRouter } from 'vue-router'

  const email = ref('');
  const password = ref('');
  const router = useRouter();

  const login = async () => {
    let loginResponse = await AuthService.Login(email.value, password.value);
    if (loginResponse.status == 200) {
      router.push("/");
    }
  }
</script>
