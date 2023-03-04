<template>
  <c-loader-status :loaders="{
        'no-initial-content no-error-content': [shoppingLists.$load],
    }" #default>
    <v-container>
      <v-row>
        <v-col cols="12" sm="6" md="4" xl="3" v-for="list in shoppingLists.$items.filter(x => !x.isComplete)">
          <v-card height="100%" color="primary" class="pa-1">
            <v-card flat tile height="100%">
              <v-card-title>
                <v-row>
                  <v-col>
                    Shopping List {{ list.shoppingListId }}

                  </v-col>
                  <v-col class="text-right">
                    <v-btn @click="closeList(list)" size="x-small" color="error" icon="fa-solid fa-shop-slash" />

                  </v-col>
                </v-row>
                <v-spacer />
              </v-card-title>


              <v-card-text>
                <v-divider :thickness="5" color="primary" />
                <br />
                <v-icon class="mr-2" color="primary">
                  fa-solid fa-cart-shopping
                </v-icon>
                {{ list.items.length }} item(s)
              </v-card-text>

              <v-card-actions>
                <v-btn :to="`/shopping-lists/${list.shoppingListId}`" variant="flat" width="100%" color="primary">
                  View List
                </v-btn>
              </v-card-actions>
            </v-card>
          </v-card>
        </v-col>
        <v-col cols="12" sm="6" md="4" xl="3">
          <v-card @click="addList" height="100%" color="primary" class="pa-1">
            <v-card flat tile height="100%">
              <v-container align="center" justify="center">
                <v-sheet height="120px" class="d-flex">
                  <v-container class="my-auto">
                    <v-btn icon="fas fa-plus" color="primary" size="x-large" />
                  </v-container>
                </v-sheet>
              </v-container>
            </v-card>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </c-loader-status>
</template>

<script setup lang="ts">
  import { ShoppingListListViewModel, ShoppingListViewModel } from "../viewmodels.g";

  const shoppingLists = new ShoppingListListViewModel();

  shoppingLists.$load();

  function closeList(shoppingList: ShoppingListViewModel) {
    shoppingList.isComplete = true;
  }

  function addList() {
    const shoppingList = new ShoppingListViewModel();

    shoppingList.isComplete = false;
    shoppingList.isDelivered = false;

    shoppingList.$save();

    shoppingLists.$load();
  }
</script>
