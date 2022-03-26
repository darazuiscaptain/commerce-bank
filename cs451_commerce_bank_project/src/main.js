import Vue from 'vue';
import App from './App.vue';
import VueRouter from 'vue-router';

import LoginPage from './pages/LoginPage.vue';
import NotificationRulesPage from './pages/NotificationRulesPage.vue';
import TransactionPage from './pages/TransactionPage.vue';
import UserRegistrationPage from './pages/UserRegistrationPage.vue';

import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';

Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'Login',
    component: LoginPage,
    meta: { title: '' }
  },
  {
    path: '/user-registration',
    name: 'User Registration',
    component: UserRegistrationPage
  },
  {
    path: '/notification-rules',
    name: 'Notification Rules',
    component: NotificationRulesPage,
    meta: { title: 'Notification Rules' }
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
