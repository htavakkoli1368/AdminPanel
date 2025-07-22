<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated>
      <q-toolbar>
        <q-btn flat dense round icon="menu" @click="leftDrawerOpen = !leftDrawerOpen" aria-label="Menu" />
        <q-toolbar-title>
          اپ مدیریت آب، برق و گاز
        </q-toolbar-title>
      </q-toolbar>
    </q-header>

    <q-drawer v-model="leftDrawerOpen" show-if-above bordered>
      <q-list>
        <q-item clickable v-ripple to="/dashboard">
          <q-item-section avatar>
            <q-icon name="dashboard" />
          </q-item-section>
          <q-item-section>داشبورد</q-item-section>
        </q-item>
        <q-item clickable v-ripple to="/water">
          <q-item-section avatar>
            <q-icon name="water" />
          </q-item-section>
          <q-item-section>مصرف آب</q-item-section>
        </q-item>
        <q-item clickable v-ripple to="/electricity">
          <q-item-section avatar>
            <q-icon name="bolt" />
          </q-item-section>
          <q-item-section>مصرف برق</q-item-section>
        </q-item>
        <q-item clickable v-ripple to="/gas">
          <q-item-section avatar>
            <q-icon name="local_fire_department" />
          </q-item-section>
          <q-item-section>مصرف گاز</q-item-section>
        </q-item>
        <q-item clickable v-ripple to="/settings">
          <q-item-section avatar>
            <q-icon name="settings" />
          </q-item-section>
          <q-item-section>تنظیمات</q-item-section>
        </q-item>
      </q-list>
    </q-drawer>
    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script setup>
  import { ref } from 'vue'
  const leftDrawerOpen = ref(false)
</script>
