<template>
  <v-card class="mx-auto"
          max-width="344"
          title="User Registration">
    <v-form prefix="registration"
            v-model="registerUser">
      <v-text-field v-model="first"
                    color="primary"
                    label="First name"
                    variant="underlined"></v-text-field>

      <v-text-field v-model="last"
                    color="primary"
                    label="Last name"
                    variant="underlined"></v-text-field>

      <v-text-field v-model="email"
                    color="primary"
                    label="Email"
                    variant="underlined"></v-text-field>

      <v-text-field v-model="phoneNumber"
                    color="primary"
                    label="Phone Number"
                    variant="underlined"></v-text-field>

      <v-text-field v-model="password"
                    color="primary"
                    label="Password"
                    persistent-hint
                    placeholder="Enter your password"
                    variant="underlined"></v-text-field>

    </v-form>

    <v-divider></v-divider>

    <v-card-actions>
      <v-spacer></v-spacer>

      <v-btn color="success" typeof="submit" v-on:click="onSubmit">
        Complete Registration

        <v-icon icon="fa-arrow" end></v-icon>
      </v-btn>
    </v-card-actions>
  </v-card>
</template>
<script>
import { LoginServiceApiClient } from "../api-clients.g"

  export default {
    data: () => ({
      first: null,
      last: null,
      email: null,
      password: null,
      phoneNumber: null,
    }),
  }

  function onSubmit(values) {

    var submitHandler = new LoginServiceApiClient();
    submitHandler.registerUser(values[0], values[1], values[2], values[3], values[4])
  }
</script>