<template>
  <c-loader-status :loaders="{
        'no-initial-content no-error-content': [shoppingList.$load],
    }" #default>
    <v-container>
      <h1>
        {{sendersName}}'s Shopping List
      </h1>

      <h3>
        Outstanding Items
      </h3>
      <v-timeline dense clipped min-width="800px" side="end" class="float-left">
        <template v-for="(item, i) in outstandingItems()"
                  :key="i">
          <ShoppingListItem :listItem="item" />
        </template>
      </v-timeline>

      <v-card color="transparent" flat width="100%">
        <v-btn @click="openDialog()" color="primary" icon="fa-solid fa-plus" class="add-btn" />
      </v-card>


      <h3>
        Purchased Items
      </h3>
      <v-timeline dense clipped min-width="800px" side="end" class="float-left">
        <template v-for="(item, i) in purchasedItems()"
                  :key="i">
          <ShoppingListItem :listItem="item" />
        </template>
      </v-timeline>
    </v-container>
  </c-loader-status>

  <v-dialog v-model="addItem" width="500">
    <v-card>
      <v-card-title>
        Add Item
      </v-card-title>

      <v-card-text>
        <v-text-field autofocus @keyup.enter="addToList()" v-model="newItem.name" hide-details label="Item Name" />
        <v-checkbox color="primary" v-model="newItem.purchased" label="Purchased?" />
      </v-card-text>

      <v-card-actions>
        <v-spacer />
        <v-btn @click="addItem = false">
          Cancel
        </v-btn>
        <v-btn :disabled="!newItem.name" @click="addToList()" color="primary">
          Save
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
  import { ShoppingListItemViewModel, ShoppingListViewModel } from "../viewmodels.g";
  const props = defineProps<{ listId: number }>();

  let shoppingList = new ShoppingListViewModel();
  shoppingList.$load(props.listId);

  let newItem = new ShoppingListItemViewModel();

  const sendersName = "Joyce"
  let addItem = ref(false);

  function log() {
    console.log('click')
  }

  function purchasedItems() {
    return shoppingList.items?.filter(x => x.purchased);
  }

  function outstandingItems() {
    return shoppingList.items?.filter(x => !x.purchased);
  }

  function openDialog() {
    // Clear out the item
    newItem = new ShoppingListItemViewModel();
    addItem.value = true;
  }

  function addToList() {
    if (newItem.name) {
      if (newItem.purchased === null) {
        newItem.purchased = false;
      }
      newItem.originalName = newItem.name;
      newItem.shoppingListId = shoppingList.shoppingListId;
      shoppingList.items?.push(newItem);
      newItem.$save();
      addItem.value = false;
    }
  }
</script>

<style>
  .add-btn {
    margin-left: 22px;
    margin-bottom: 20px;
  }
</style>