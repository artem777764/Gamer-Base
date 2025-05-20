<script setup lang="ts">
import { ref } from 'vue';
const test = ref("f");
</script>

<template>
  <h1>{{ test }}</h1>
  <MyInput placeholder="Email" v-model="test"></MyInput>
  <MyInput placeholder="Login"></MyInput>
  <MyInput placeholder="Password" is-password></MyInput>
  <MyButton>Зарегистрироваться</MyButton>
</template>

<style>
.text-shadow {
  text-shadow: 1px 1px 2px black;
}
</style>