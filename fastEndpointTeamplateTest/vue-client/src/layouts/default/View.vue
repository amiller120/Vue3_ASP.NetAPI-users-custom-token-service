<template>
  <v-layout>
    <!-- <v-system-bar color="deep-purple darken-3"></v-system-bar> -->

    <v-app-bar color="primary" prominent>
      <v-app-bar-nav-icon variant="text" @click.stop="drawer = !drawer"></v-app-bar-nav-icon>

      <v-spacer></v-spacer>

      <v-btn variant="text" icon="mdi-magnify"></v-btn>

      <v-btn variant="text" icon="mdi-filter"></v-btn>

      <v-btn variant="text" icon="mdi-dots-vertical"></v-btn>
    </v-app-bar>

    <v-navigation-drawer v-model="drawer" location="left">
      <v-list-item title="Shopify Demo" subtitle="A&C LLC"></v-list-item>
      <v-divider></v-divider>
      
      
      <v-list-item link title="Home"><router-link to="/"></router-link></v-list-item>
      <v-list-item link title="List Item 2"><router-link to="/about"></router-link></v-list-item>
      <v-list-item link title="List Item 3"></v-list-item>
    </v-navigation-drawer>

    <v-main style="height: 500px;">
      <slot>
        <router-view />
      </slot>
    </v-main>
  </v-layout>
</template>

<script lang="ts" setup>
  import { ref } from 'vue';

  const drawer = ref(false);
</script>
