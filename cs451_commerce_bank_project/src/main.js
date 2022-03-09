import App from './App.vue';
import BootstrapVue from 'bootstrap-vue';
import Vue from 'vue';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';

Vue.use(BootstrapVue);
new Vue({
  render: h =>h(App)
}).$mount('#app');
