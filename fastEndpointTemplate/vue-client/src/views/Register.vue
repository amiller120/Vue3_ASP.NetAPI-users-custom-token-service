<template>
  <v-form>
    <v-text-field v-model="name" label="Name"></v-text-field>
    <v-text-field v-model="email" label="Email"></v-text-field>
    <v-text-field v-model="password" label="Password"></v-text-field>
  </v-form>
  <v-btn @click="submitForm">Save</v-btn>
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
