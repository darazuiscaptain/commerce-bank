import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router'
import vuetify from '@/plugins/vuetify' 

import LoginPage from './pages/LoginPage.vue'
import TransactionPage from './pages/TransactionPage.vue'
import CreateTransactionPage from './pages/CreateTransactionPage.vue'
import UserRegistrationPage from './pages/UserRegistrationPage.vue'
import NotificationRulesPage from './pages/NotificationRulesPage.vue'
import NewRulePage from './pages/NewRulePage.vue'
import RuleViewingPage from './pages/RuleViewingPage.vue'
import RuleEditPage from './pages/RuleEditPage.vue'
import AccountPage from './pages/AccountPage.vue'

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

Vue.use(VueRouter)

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
    path: '/account',
    name: 'Account Page',
    component: AccountPage,
    meta: { title: 'Account Page' }
  },
  {
    path: '/notification-rules',
    name: 'Notification Rules',
    component: NotificationRulesPage,
    meta: { title: 'Notification Rules' }
  },
  {
    path: '/notification-rules/new',
    name: 'New Rules',
    component: NewRulePage,
    meta: { title: 'New Rule' }
  },
  {
    path: '/notification-rules/:id',
    name: 'View Rule',
    component: RuleViewingPage,
    meta: { title: 'Notification Rule' }
  },
  {
    path: '/notification-rules/:id/edit',
    name: 'Edit Rule',
    component: RuleEditPage,
    meta: { title: 'Edit Rule' }
  },
  {
    path: '/transactions',
    name: 'Transaction Page',
    component: TransactionPage,
    meta: { title: 'Transaction' }
  },
  {
    path: '/transactions/new',
    name: 'Create a Transaction',
    component: CreateTransactionPage,
    meta: { title: 'Create a Transaction' }
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

new Vue({
  router,
  vuetify,
  render: h =>h(App)
}).$mount('#app');
