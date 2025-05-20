<script setup lang="ts">
import { useRoute } from 'vue-router'
const hideNavigation = ['/register']
const route = useRoute()
</script>

<template>
  <router-link to="/register" v-if="!hideNavigation.includes(route.path)">О нас</router-link>
  <router-view></router-view>
</template>

<style>
.text-shadow {
  text-shadow: 1px 1px 2px black;
}
</style>