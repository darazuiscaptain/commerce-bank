import Vue from 'vue'
import Vuetify from 'vuetify'
import 'vuetify/dist/vuetify.min.css'
import colors from '../cb-colors.js'

Vue.use(Vuetify)

const opts = {
    theme: {
        themes: {
            light: {
                primary: colors.darkgreen,
                secondary: colors.green,
                accent: colors.gold,
            },
            dark: {
                primary: colors.ultradarkgreen,
                secondary: colors.darkgreen,
                accent: colors.blue,
            },
        },
    },
}

export default new Vuetify(opts)
