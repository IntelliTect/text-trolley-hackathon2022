<template>
  <v-container style="max-width: 600px">
    <v-card>
      <v-card-title> Text-Trolley Admin Pages </v-card-title>
      <v-card-text class="black--text">
        <ul>
          <li v-for="typeMeta in adminTypes" :key="typeMeta.name">
            <router-link
              :to="{
                name: 'coalesce-admin-list',
                params: { type: typeMeta.name },
              }"
            >
              {{ typeMeta.displayName }}
            </router-link>
          </li>
        </ul>
      </v-card-text>     
    </v-card>
  </v-container>
</template>

<script setup lang="ts">
import $metadata from "@/metadata.g";

const adminTypes = Object.values($metadata.types).filter(
  (t) => t.type == "model"
);
</script>
