import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import registerGlobalComponents from '@/plagins/global-components'
import router from '@/router'
import { createPinia } from 'pinia'
import piniaPersistedstate from 'pinia-plugin-persistedstate'

const pinia = createPinia()
pinia.use(piniaPersistedstate)

const app = createApp(App).use(router)
                          .use(pinia)

registerGlobalComponents(app)

app.mount('#app')