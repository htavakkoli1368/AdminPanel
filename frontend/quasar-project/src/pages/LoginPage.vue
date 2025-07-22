<template>
  <q-page class="flex flex-center">
    <q-card style="min-width:300px;max-width:90vw;">
      <q-card-section>
        <div class="text-h6 text-center">
          {{ isRegister ? 'ثبت‌نام' : 'ورود' }}
        </div>
      </q-card-section>
      <q-card-section>
        <q-input v-model="username" label="نام کاربری" dense outlined />
        <q-input v-model="password" label="رمز عبور" type="password" dense outlined class="q-mt-md" />
        <q-input
          v-if="isRegister"
          v-model="confirmPassword"
          label="تکرار رمز عبور"
          type="password"
          dense
          outlined
          class="q-mt-md"
        />
      </q-card-section>
      <q-card-actions align="center">
        <q-btn
          color="primary"
          :label="isRegister ? 'ثبت‌نام' : 'ورود'"
          @click="isRegister ? register() : login()"
        />
        <q-btn
          flat
          color="primary"
          :label="isRegister ? 'برگشت به ورود' : 'ثبت‌نام'"
          @click="isRegister = !isRegister"
        />
      </q-card-actions>
    </q-card>
  </q-page>
</template>

<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'

const username = ref('')
const password = ref('')
const confirmPassword = ref('')
const isRegister = ref(false)
const router = useRouter()

function login() {
  if (username.value && password.value) {
    router.push('/dashboard')
  }
}

function register() {
  if (username.value && password.value && password.value === confirmPassword.value) {
    // اینجا می‌تونی ثبت‌نام واقعی بزنی
    isRegister.value = false
    username.value = ''
    password.value = ''
    confirmPassword.value = ''
  }
}
</script>