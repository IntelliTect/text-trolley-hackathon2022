<template>
  <div class="home">
    <!-- Component is auto-imported by `unplugin-vue-components`
    (either kebab-case or PascalCase works.) -->

    <v-container>
      <v-alert class="mb-2" type="success" color="primary"> Primary </v-alert>
      <v-alert class="mb-2" type="success" color="secondary"> Secondary </v-alert>
      <v-alert class="mb-2" type="success" color="success"> Success </v-alert>
      <v-alert class="mb-2" type="info" color="info"> Info </v-alert>
      <v-alert class="mb-2" type="warning" color="warning"> Warning </v-alert>
      <v-alert class="mb-2" type="error" color="error"> Error </v-alert>
    </v-container>

    <HelloWorld msg="Welcome to your new Vue.js Coalesce application!" />
  </div>
</template>

<script setup lang="ts">
  useTitle("Home");
</script>
