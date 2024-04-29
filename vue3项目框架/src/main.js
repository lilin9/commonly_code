import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import api from './api/index'

const app = createApp(App)

app.use(router)

app.config.globalProperties.$api = api;

app.mount('#app')
