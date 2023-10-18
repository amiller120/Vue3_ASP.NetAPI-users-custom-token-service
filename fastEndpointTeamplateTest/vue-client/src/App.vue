<template>
  <v-app>
    <v-app-bar :color="'blue-darken-3'" app>
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

      <v-list-item v-for="(item, index) in items" :key="item.title">
        <router-link :to="item.path">
          <v-list-item-title>{{ item.title }}</v-list-item-title>
        </router-link>
      </v-list-item>
    </v-navigation-drawer>
    <!-- Add a main view -->
    <v-main>
      <router-view></router-view>
    </v-main>
  </v-app>
</template>

<script lang="ts" setup>
  import { ref } from "vue"
  const drawer = ref(false);
  const items = ref([{ title: "Home", path: '/' }, { title: "About", path: '/About' }])


</script>
