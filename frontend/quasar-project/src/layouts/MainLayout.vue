<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated>
      <q-toolbar>
        <q-btn
          flat
          dense
          round
          icon="menu"
          aria-label="Menu"
          @click="toggleLeftDrawer"
        />

        <q-toolbar-title>
          Quasar App
        </q-toolbar-title>

        <div>Quasar v{{ $q.version }}</div>
      </q-toolbar>
    </q-header>

    <q-drawer
      v-model="leftDrawerOpen"
      show-if-above
      bordered
    >
      <q-list>
        <q-item-label
          header
        >
          Essential Links
        </q-item-label>

        <EssentialLink
          v-for="link in linksList"
          :key="link.title"           
          v-bind="link"
        />
      </q-list>
    </q-drawer>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
import { defineComponent, ref } from 'vue'
import EssentialLink from 'components/EssentialLink.vue'

const linksList = [
  {
    title: 'Dashboard',
    caption: 'All in One',
    icon: 'admin_panel_settings',
    link: 'https://quasar.dev',
    path: '/docs'
  },
  {
    title: 'Shop',
    caption: 'Shoping Center',
    icon: 'shop',
    link: 'https://github.com/quasarframework',
    path: '/github'
  },
  {
    title: 'Reports',
    caption: 'Users Reports',
    icon: 'report',
    link: 'https://github.com/quasarframework',
    path: '/github'
  },
  {
    title: 'Chat',
    caption: 'Be in Touch',
    icon: 'chat',
    link: 'index',
    path: '/index'
  },
  {
    title: 'Accounts',
    caption: 'Users Account',
    icon: 'account_circle',
    link: 'users',
    path: '/users'
  }, 
  {
    title: 'Log Out',
    caption: 'Logout',
    icon: 'logout',
    link: 'index',
    path: '/index'
  } 
 
]

export default defineComponent({
  name: 'MainLayout',

  components: {
    EssentialLink
  },

  setup () {
    const leftDrawerOpen = ref(false)

    return {
      linksList,
      leftDrawerOpen,
      toggleLeftDrawer () {
        leftDrawerOpen.value = !leftDrawerOpen.value
      }
    }
  }
})
</script>
