<template>
  <q-page class="q-pa-md">
    <div class="text-h5 text-center q-mb-lg">تنظیمات</div>
    <q-card class="q-mb-md">
      <q-card-section>
        <q-input v-model="username" label="نام کاربری" outlined dense />
        <q-input v-model="password" label="رمز عبور جدید" type="password" outlined dense class="q-mt-md" />
        <q-btn color="primary" label="ذخیره تغییرات" class="q-mt-md" @click="save" />
      </q-card-section>
    </q-card>
    <q-card>
      <q-card-section>
        <q-btn color="negative" label="خروج از حساب" @click="logout" />
      </q-card-section>
    </q-card>
  </q-page>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import { useQuasar } from 'quasar'

const $q = useQuasar()
const username = ref('')
const password = ref('')
const router = useRouter()

onMounted(() => {
  username.value = localStorage.getItem('username') || ''
})

function save() {
  if (username.value) {
    localStorage.setItem('username', username.value)
    if (password.value) {
      localStorage.setItem('password', password.value)
      password.value = ''
    }
    $q.notify({ type: 'positive', message: 'تغییرات ذخیره شد!' })
  }
}

function logout() {
  localStorage.removeItem('username')
  localStorage.removeItem('password')
  router.push('/')
}
</script>