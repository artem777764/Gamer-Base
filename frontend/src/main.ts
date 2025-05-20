import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import registerGlobalComponents from '@/plagins/global-components'
import router from '@/router'


const app = createApp(App).use(router)

registerGlobalComponents(app)

app.mount('#app')