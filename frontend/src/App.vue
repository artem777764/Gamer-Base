<script setup lang="ts">
import NavBar from '@/components/NavBar.vue';
import { useUserStore } from './stores/user';
import { computed } from 'vue';
const userStore = useUserStore()

import { useRoute } from 'vue-router'
const hideNavigation = ['/register', '/login']
const fixNavigation = computed(() => [
  '/',
  '/search',
  `/profile/${userStore.id}`,
]);
const route = useRoute()

const roleName = computed(() => {
  if (userStore.roleId === 1 || userStore.roleId === 2 || userStore.roleId === 3) return 'user'
  return 'guest'
})

const menuItems = computed(() => ({
  guest: [
    { label: 'GamerBase', route: { path: '/' } },
    { label: 'Поиск', route: { path: '/search' } },
    { label: 'Регистрация', route: { path: '/register' } },
    { label: 'Вход', route: { path: '/login' } },
  ],
  user: [
    { label: 'GamerBase', route: { path: '/' } },
    { label: 'Поиск', route: { path: '/search' } },
    { label: 'Избранное', route: { path: '/favorites' } },
    { label: 'Мои обзоры', route: { path: '/my-reviews' } },
    { label: 'Профиль', route: { name: 'ProfilePage', params: { id: userStore.id } } },
  ],
}))

</script>

<template>
  <NavBar
    v-if="!hideNavigation.includes(route.path)"
    :menu-items="menuItems[roleName]"
    :class="fixNavigation.includes(route.path)
      ? 'fixed top-0 left-0 w-full z-50'
      : ''"
  />
  <router-view></router-view>
</template>

<style>
.text-shadow {
  text-shadow: 1px 1px 2px black;
}
</style>