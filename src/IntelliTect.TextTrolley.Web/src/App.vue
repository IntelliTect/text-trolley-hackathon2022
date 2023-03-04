<template>
  <v-app id="vue-app">
    <v-app-bar color="primary">
    <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
    <v-toolbar-title>
      <router-link to="/" style="color: inherit">
        Coalesce Vue Template
      </router-link>
    </v-toolbar-title>


      <template v-slot:append>
        <v-btn icon @click="toggleTheme">
          <v-icon v-if="isDarkMode()">
            fa-solid fa-lightbulb
          </v-icon>
          <v-icon v-else>
            fa-regular fa-lightbulb
          </v-icon>
        </v-btn>
      </template>
  </v-app-bar>

    <v-navigation-drawer v-model="drawer">
      <v-list>
        <v-list-item link to="/">
          <template #prepend>
            <v-icon>fas fa-home</v-icon>
          </template>
          <v-list-item-title>Home</v-list-item-title>
        </v-list-item>

        <v-list-item link to="/shopping-lists">
          <template #prepend>
            <v-icon>fa-solid fa-list-check</v-icon>
          </template>
          <v-list-item-title>Shopping Lists</v-list-item-title>
        </v-list-item>

        <v-list-item link to="/register">
          <template #prepend>
            <v-icon>fa-solid fa-user</v-icon>
          </template>
          <v-list-item-title>Register</v-list-item-title>
        </v-list-item>

        <v-list-item link to="/coalesce-example">
          <template #prepend>
            <v-icon>fas fa-palette</v-icon>
          </template>
          <v-list-item-title>Custom Page Example</v-list-item-title>
        </v-list-item>

        <v-list-item link to="/admin">
          <template #prepend>
            <v-icon>fas fa-cogs</v-icon>
          </template>
          <v-list-item-title>Admin Pages</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-main>
      <!-- https://stackoverflow.com/questions/52847979/what-is-router-view-key-route-fullpath -->
      <router-view v-slot="{ Component, route }">
        <transition name="router-transition" mode="out-in" appear>
          <component :is="Component" :key="route.path" />
        </transition>
      </router-view>
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
  import { useTheme } from "vuetify/lib/framework.mjs"

  const drawer = ref<boolean | null>(null)
  const theme = useTheme()

  theme.global.name.value = localStorage.getItem("DARK_THEME") ?? "dark";

  function toggleTheme() {
    theme.global.name.value = isDarkMode() ? 'light' : 'dark'
    localStorage.setItem("DARK_THEME", theme.global.name.value);
  }

  function isDarkMode() {
    return theme.global.current.value.dark
  }

</script>

<style lang="scss">
.router-transition-enter-active,
.router-transition-leave-active {
  transition: 0.1s ease-out;
}

.router-transition-move {
  transition: transform 0.4s;
}

.router-transition-enter-from,
.router-transition-leave-to {
  opacity: 0;
}
</style>
