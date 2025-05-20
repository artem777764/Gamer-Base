import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import registerGlobalComponents from '@/plagins/global-components'

const app = createApp(App)

registerGlobalComponents(app)

app.mount('#app')