<template>
  <v-container>
    <v-row>
      <v-col class="mb-2">

        <v-card class="ma-15">
          <v-card-title align="center">
            {{ msg }}
          </v-card-title>
          <v-row>
            <v-col align="center">
              <v-form v-model="valid">
                <v-container>
                  <v-row>
                    <v-col align="center" class="pa-5">
                      <v-text-field v-model="username"
                                    :rules="loginRules"
                                    label="Username"
                                    required></v-text-field>
                    </v-col>                                  
                  </v-row>
                  <v-row>
                    <v-col align="center" class="pa-5">
                      <v-text-field v-model="password"
                                    :rules="loginRules"
                                    label="Password"
                                    required></v-text-field>
                    </v-col>
                  </v-row>
                </v-container>
              </v-form>
            </v-col>
          </v-row>
          <v-row>
            <v-col align="center">
              <v-btn color="primary" onclick="login">
                Login
              </v-btn>
            </v-col>
          </v-row>
          <v-row>
            <v-divider class="my-4"></v-divider>
          </v-row>
          <v-row>
            <v-col align="center">
              Don't have an account yet?
            </v-col>
          </v-row>
          <v-row>
            <v-col align="center">
              <v-btn class="p" color="primary" onclick="register">
                Register
              </v-btn>
            </v-col>
          </v-row>
          <v-card-text class="black--text">
          </v-card-text>
        </v-card>
        <v-card class="ma-15">
          <v-card-title align="center">
            What is the Text-Trolley?
          </v-card-title>
          <v-row>
            <v-col class="pa-6" align="center">
              The Text-Trolley is your grocery shopping helper enabling effective communication
              between those who need groceries and those doing the shopping!
            </v-col>
          </v-row>
        </v-card>
      </v-col>    
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
  import { LoginServiceViewModel } from '@/viewmodels.g';

  defineProps<{ msg: string | null }>();

  const loginService = new LoginServiceViewModel();

  async function login() {
    await loginService.loginUser;
  }

  async function register() {
    await loginService.registerUser;
  }



</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.browser-logos {
  position: relative;
  width: 64px;
  height: 64px;
  margin: auto;
  img {
    position: absolute;
    top: 0;
    animation-name: fade;
    animation-iteration-count: infinite;
    animation-duration: 6s;
    animation-timing-function: ease-in-out;
  }
}

@keyframes fade {
  0% {
    opacity: 0;
  }
  20% {
    opacity: 1;
  }
  33% {
    opacity: 1;
  }
  53% {
    opacity: 0;
  }
  100% {
    opacity: 0;
  }
}

.f2 {
  animation-delay: -4s;
}
.f3 {
  animation-delay: -2s;
}
</style>
