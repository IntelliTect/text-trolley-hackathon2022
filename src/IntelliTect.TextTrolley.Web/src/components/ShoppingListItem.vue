<template>
  <v-hover v-slot="{ isHovering, props }">
    <v-timeline-item vertical-timeline-element-icon
                     v-bind="props"
                     dot-color="primary"
                     size="large"
                     :icon="getIcon(isHovering)"
                     @click="toggleItem()"
                     width="70vw">
      <v-card flat color="grey-lighten-3">
        <v-container fluid>
          <v-row>
            <v-col cols="auto">
              <span :class="getClass()">
                {{ listItem.itemDescription }}
              </span>
            </v-col>
            <v-col align="right">
              <v-btn variant="plain">
                <v-icon color="primary" small>
                  fa-solid fa-pen
                </v-icon>
              </v-btn>
              <v-btn variant="plain">
                <v-icon color="error">
                  fa-solid fa-trash
                </v-icon>
              </v-btn>
            </v-col>
          </v-row>

        </v-container>
      </v-card>
    </v-timeline-item>
  </v-hover>
</template>

<script setup lang="ts">
  const props = defineProps<{ listItem: any }>();

  function getIcon(hover: boolean) {
    if (props.listItem.isPurchased) {
      return "fa-solid fa-check";
    } else {
      return hover ? "fa-solid fa-check" : "";
    }
  }

  function getClass() {
    return props.listItem.isPurchased ? "text-decoration-line-through" : "";
  }

  function toggleItem() {
    // TODO: Make dynamic
    if (props.listItem.isPurchased) {
      props.listItem.isPurchased = false;
      console.log("unresolved item");
    }
    else {
      props.listItem.isPurchased = true;
      console.log("resolved item");
    }
  }
</script>
