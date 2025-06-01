<script setup lang="ts">
import type { RouteLocationRaw } from 'vue-router';

interface MenuItem{
    label: string,
    route: RouteLocationRaw;
}

defineProps<{
    menuItems: MenuItem[]
}>()
</script>

<template>
<nav class="bg-secondary px-7 py-2 font-russo text-white text-xl text-shadow flex justify-between shadow-md">
    <router-link v-for="item in menuItems" :key="item.label" :to="item.route">{{ item.label }}</router-link>
</nav>
</template>