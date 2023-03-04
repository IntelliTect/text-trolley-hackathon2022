<template>
  <v-timeline-item vertical-timeline-element-icon
                   dot-color="primary"
                   size="large"
                   :icon="getIcon()"
                   @click="toggleItem()"
                   width="70vw">
    <v-card @click.stop="edit" :ripple="false" flat>
      <v-row class="ma-1" dense align="center">
        <v-col>
          <span v-if="!isEditing" :class="props.listItem.purchased ? 'text-decoration-line-through' : ''">
            {{ listItem.name }}
          </span>
          <v-text-field autofocus v-else width="100%" hide-details label="Description" v-model="listItem.name" />
        </v-col>
        <v-col cols="auto" class="text-right">
          <v-btn icon="fa-solid fa-trash" color="error" @click.stop="deleteItem()" size="x-small" />
        </v-col>
      </v-row>
    </v-card>
  </v-timeline-item>
</template>

<script lang="ts">

</script>

<script setup lang="ts">
  import { ShoppingListItemViewModel } from "../viewmodels.g";
  import { getCurrentInstance } from 'vue';
  import { useTheme } from "vuetify/lib/framework.mjs"

  const props = defineProps<{ listItem: ShoppingListItemViewModel }>();
  const vue = getCurrentInstance();
  const theme = useTheme();

  let isEditing = ref(false);

  function stopEditing() {
    isEditing.value = false;
  }

  function getIcon() {
    if (props.listItem.purchased) {
      return "fa-solid fa-check";
    } else {
      return "";
    }
  }

  function edit() {
    isEditing.value = !isEditing.value;
    if (!isEditing) {
      props.listItem.$save();
    }
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
