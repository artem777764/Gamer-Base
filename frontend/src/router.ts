import { createRouter, createWebHistory } from 'vue-router'
import type { RouteRecordRaw } from 'vue-router'

import RegisterPage from '@/pages/RegisterPage.vue'
import LoginPage from '@/pages/LoginPage.vue'
import SearchResultPage from '@/pages/SearchResultPage.vue'
import GameInfoPage from '@/pages/GameInfoPage.vue'

const routes: RouteRecordRaw[] = [
  { path: '/', redirect: '/register'},
  { path: '/register', component: RegisterPage },
  { path: '/login', component: LoginPage },
  { path: '/search-result', component: SearchResultPage },
  { path: '/game-info/:id', component: GameInfoPage },
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

export default router