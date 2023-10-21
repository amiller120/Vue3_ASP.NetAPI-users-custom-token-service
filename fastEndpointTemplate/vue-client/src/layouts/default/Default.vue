<template>
  <v-app>
    <v-app-bar app>
      <v-app-bar-nav-icon @click="drawer = !drawer"></v-app-bar-nav-icon>
      <v-toolbar-title>Your Dashboard</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn icon>
        <v-icon>mdi-magnify</v-icon>
      </v-btn>
      <v-btn icon>
        <v-icon>mdi-dots-vertical</v-icon>
      </v-btn>
    </v-app-bar>

    <!-- Add a navigation drawer -->
    <v-navigation-drawer v-model="drawer" location="left">
      <v-list-item title="Shopify Demo" subtitle="A&C LLC"></v-list-item>
      <v-divider></v-divider>


      <v-list-item link title="Home"><router-link to="/"></router-link></v-list-item>
      <v-list-item link title="List Item 2"><router-link to="/login"></router-link></v-list-item>
      <v-list-item link title="List Item 3"></v-list-item>
    </v-navigation-drawer>
  </v-app>
</template>

<script lang="ts" setup>
  import { ref } from "vue"
  const drawer = ref(false);
  const items = ref([{ title: "Home", path: '/' }, { title: "Login", path: '/Login' }])


</script>
