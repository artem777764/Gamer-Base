import { createRouter, createWebHistory } from 'vue-router'
import type { RouteRecordRaw } from 'vue-router'

import RegisterPage from '@/pages/RegisterPage.vue'
import LoginPage from '@/pages/LoginPage.vue'
import SearchResultPage from '@/pages/SearchResultPage.vue'
import GameInfoPage from '@/pages/GameInfoPage.vue'
import GameReviewPage from '@/pages/GameReviewPage.vue'
import MainPage from '@/pages/MainPage.vue'
import SearchPage from '@/pages/SearchPage.vue'
import ProfilePage from '@/pages/ProfilePage.vue'

const routes: RouteRecordRaw[] = [
  { path: '/', component: MainPage, name: 'Main' },
  { path: '/register', component: RegisterPage },
  { path: '/login', component: LoginPage },
  { path: '/search-result/name/:query', component: SearchResultPage, name: 'SearchResult' },
  { path: '/game-info/:id', component: GameInfoPage, name: 'GameInfo' },
  { path: '/game-review/:id', component: GameReviewPage, name: 'GameReview' },
  { path: '/search', component: SearchPage, name: 'Search' },
  { path: '/profile/:id', component: ProfilePage, name: 'ProfilePage' },
]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

export default router