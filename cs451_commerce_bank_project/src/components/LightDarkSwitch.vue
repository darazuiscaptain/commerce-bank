<template>
  <v-switch
    v-model="$vuetify.theme.dark"
    prepend-icon="mdi-weather-night"
    color="white"
    inset
  ></v-switch>
</template>

<script>
export default {
  name: "LightDarkSwitch",
};
</script>
