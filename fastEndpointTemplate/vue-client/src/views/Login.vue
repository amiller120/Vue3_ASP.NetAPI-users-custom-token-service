<template>
  <v-form>
    <v-text-field v-model="email" label="Email"></v-text-field>
    <v-text-field v-model="password" label="Password" type="password"></v-text-field>
    <v-btn @click="login">Login</v-btn>
    <v-btn @click="register">Register</v-btn>
  </v-form>
</template>

<script setup lang="ts">
  import { ref } from 'vue';
import AuthService from '../Services/Api/AuthService';

  const email = ref('');
  const password = ref('');

  const login = async() => {
    await AuthService.Login(email.value, password.value);
  }
</script>
