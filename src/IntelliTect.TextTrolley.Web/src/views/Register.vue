<template>
  <v-card class="mx-auto ma-15"
          max-width="350"
          title="User Registration">
    <v-card-text>
    <v-text-field v-model="first"
                  color="primary"
                  label="First name"
                  variant="underlined" />

    <v-text-field v-model="last"
                  color="primary"
                  label="Last name"
                  variant="underlined" />

    <v-text-field v-model="email"
                  color="primary"
                  label="Email"
                  variant="underlined" />
    <v-text-field v-model="phoneNumber"
                  color="primary"
                  label="Phone Number"
                  variant="underlined" />

    <v-text-field v-model="password"
                  color="primary"
                  type="password"
                  label="Password"
                  persistent-hint
                  placeholder="Enter your password"
                  variant="underlined" />
    </v-card-text>

    <v-divider />

    <v-card-actions>
      <v-spacer />
      <v-btn color="success" @click="submit">
        Register
        <v-icon class="ml-2" icon="fa-solid fa-arrow-right" />
      </v-btn>
    </v-card-actions>
  </v-card>
</template>
<script setup lang="ts">
  import { LoginServiceViewModel } from "../viewmodels.g";

  const loginService = new LoginServiceViewModel();

  let first = ref('');
  let last = ref('');
  let email = ref('');
  let password = ref('');
  let phoneNumber = ref('');

  function submit() {
    loginService.registerUser(first.value, last.value, email.value, password.value, phoneNumber.value);
  }
</script>