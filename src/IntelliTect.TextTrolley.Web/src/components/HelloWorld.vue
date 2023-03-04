<template>
  <v-container>
    <v-row class="pa-15">
      <v-col>
        <v-card>
          <v-card-title align="center">
            {{ msg }}
          </v-card-title>
          <v-row>
            <v-col align="center">
              <v-icon color="success">
                fa-solid fa-cart-shopping
              </v-icon>
            </v-col>
          </v-row>
          <v-card-text>
            <v-row style="max-width: 500px"
                   class="mx-auto"
                   justify="space-around"
                   align="end">
              <v-col>
                <h4 align="center">
                  The Text-Trolley is your grocery shopping helper enabling effective
                  communication between those needing groceries and those doing the shopping!
                </h4>
              </v-col>
            </v-row>            
          </v-card-text>
        </v-card>
      </v-col>     
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
defineProps<{ msg: string | null }>();
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
