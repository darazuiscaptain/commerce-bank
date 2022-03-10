import Vue from 'vue';
import App from './App.vue';
import VueRouter from 'vue-router';
import BootstrapVue from 'bootstrap-vue';

import LoginPage from './components/LoginPage.vue';
import HomePage from './components/HomePage.vue';
import TransactionPage from './components/TransactionPage.vue';

import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';

Vue.use(VueRouter);
Vue.use(BootstrapVue);

const routes = [
  {
    path: '/',
    name: 'Login',
    component: LoginPage,
    meta: { title: '' }
  },
  {
    path: '/home',
    name: 'Home Page',
    component: HomePage,
    meta: { title: 'Home' }
  },
  {
    path: '/transactions',
    name: 'Transaction Page',
    component: TransactionPage,
    meta: { title: 'Transaction' }
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

new Vue({
  router,
  render: h =>h(App)
}).$mount('#app');