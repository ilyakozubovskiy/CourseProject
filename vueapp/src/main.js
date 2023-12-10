import { createApp } from 'vue'
import App from './App.vue'


const app = createApp(App)

import DateFormat from '@voidsolutions/vue-dateformat'
app.use(DateFormat);

import router from './router'
app.use(router)

app.mount('#app')
