<template>
  <v-container class="d-flex justify-center">
    <v-form class="w-50">
      <v-text-field v-model="name" label="Name"></v-text-field>
      <v-text-field v-model="email" label="Email"></v-text-field>
      <v-text-field v-model="password" label="Password"></v-text-field>
      <v-btn @click="submitForm">Save</v-btn>
    </v-form>    
  </v-container>
</template>

<script setup lang="ts">
  import { ref } from 'vue';
  import AuthService from '../Services/Api/AuthService';

  const name = ref('');
  const email = ref('');
  const password = ref('');

  const submitForm = async () => {
    let response = await AuthService.register(email.value, name.value, password.value);
  }
</script>
