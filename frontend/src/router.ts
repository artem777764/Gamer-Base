import { createRouter, createWebHistory } from 'vue-router'
import type { RouteRecordRaw } from 'vue-router'

import RegisterPage from '@/pages/RegisterPage.vue'
import LoginPage from '@/pages/LoginPage.vue'
import SearchResultPage from '@/pages/SearchResultPage.vue'

const routes: RouteRecordRaw[] = [
  { path: '/', redirect: '/register'},
  { path: '/register', component: RegisterPage },
  { path: '/login', component: LoginPage },
  { path: '/search-result', component: SearchResultPage}
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

export default router