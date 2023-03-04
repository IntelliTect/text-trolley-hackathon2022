<template>
  <v-hover v-slot="{ isHovering, props }">
    <v-timeline-item vertical-timeline-element-icon
                     v-bind="props"
                     dot-color="primary"
                     size="large"
                     :icon="getIcon(isHovering)"
                     @click="toggleItem()"
                     :width="width()">
      <v-card @click.stop="" :ripple="false" flat :color="listItem.purchased ? 'indigo-lighten-5' : 'grey-lighten-3'">
          <v-list-item class="ma-3">
            <v-list-item-title v-if="!isEditing">
              {{ listItem.name }}
            </v-list-item-title>
            <v-text-field v-else width="100%" hide-details label="Description" v-model="listItem.name" />

            <template v-slot:append>
              <v-btn :icon="isEditing ? 'fa-solid fa-floppy-disk' : 'fa-solid fa-pen'" color="secondary" class="mr-3 ml-5" @click.stop="edit()" size="small" />
              <v-btn icon="fa-solid fa-trash" color="error" @click.stop="deleteItem()" size="small" />
            </template>
          </v-list-item>
      </v-card>
    </v-timeline-item>
  </v-hover>
</template>

<script lang="ts">

</script>

<script setup lang="ts">
  import { ShoppingListItemViewModel } from "../viewmodels.g";
  import { getCurrentInstance } from 'vue';

  const props = defineProps<{ listItem: ShoppingListItemViewModel }>();

  let isEditing = ref(false);

  function stopEditing() {
    isEditing.value = false;
  }

  function width() {
    const vue = getCurrentInstance();
    if (vue?.proxy?.$vuetify.display.xs) {
      return "100%";
    }
    return "70vw";
  }

  function getIcon(hover: boolean) {
    if (props.listItem.purchased) {
      return "fa-solid fa-check";
    } else {
      return hover ? "fa-solid fa-check" : "";
    }
  }

  function edit() {
    isEditing.value = !isEditing.value;
    if (!isEditing) {
      props.listItem.$save();
    }
  }

  function getClass() {
    return props.listItem.purchased ? "text-decoration-line-through" : "";
  }

  function deleteItem() {
    if (window.confirm(`Are you sure you want to delete ${props.listItem.name}?`)) {
      props.listItem.$delete();
    }
  }

  function toggleItem() {
    if (props.listItem.purchased) {
      props.listItem.purchased = false;
      console.log("unresolved item");
    }
    else {
      props.listItem.purchased = true;
      console.log("resolved item");
    }
    props.listItem.$save();
  }
</script>
