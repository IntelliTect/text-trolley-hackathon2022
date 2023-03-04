<template>
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
</template>

<script setup lang="ts">
  const sendersName = "Joyce"

  const shoppingList = [
    {
      itemDescription: "Banannas",
      isPurchased: true,
    },
    {
      itemDescription: "Salad",
      isPurchased: true,
    },
    {
      itemDescription: "Man Sex Pills",
      isPurchased: false,
    },
    {
      itemDescription: "Bread",
      isPurchased: false,
    },
    {
      itemDescription: "Cream Cheese",
      isPurchased: false,
    },
    {
      itemDescription: "Crackers",
      isPurchased: false,
    },
    {
      itemDescription: "Apples",
      isPurchased: true,
    },
    {
      itemDescription: "Jelly",
      isPurchased: false,
    },
    {
      itemDescription: "Those things you put ontop of salads",
      isPurchased: false,
    },
    {
      itemDescription: "Chicken",
      isPurchased: false,
    }
  ]

  outstandingItems();
  purchasedItems();

  function purchasedItems() {
    return shoppingList.filter(x => x.isPurchased);
  }

  function outstandingItems() {
    return shoppingList.filter(x => !x.isPurchased);
  }
</script>
