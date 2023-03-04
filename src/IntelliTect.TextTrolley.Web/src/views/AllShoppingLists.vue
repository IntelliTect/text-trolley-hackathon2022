<template>
  <c-loader-status :loaders="{
        'no-initial-content no-error-content': [shoppingLists.$load],
    }" #default>
    <v-card flat v-for="list in shoppingLists.$items">
      <ShoppingList :shoppingList="list" />
    </v-card>
  </c-loader-status>
</template>

<script setup lang="ts">
  import { ShoppingListListViewModel } from "../viewmodels.g";

  const shoppingLists = new ShoppingListListViewModel();
  shoppingLists.$load();

  console.log(shoppingLists.$items)
</script>
