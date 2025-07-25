<template>
  <q-page class="q-pa-md">
    <div class="text-h5 text-center q-mb-lg">Consumption DashBoard</div>
    <q-card class="q-mb-md">
      <q-card-section>
        <div class="row q-col-gutter-md">
          <div class="col-12 col-md-4">
            <q-card flat bordered>
              <q-card-section class="text-center">
                <q-icon name="water" color="primary" size="40px" />
                <div class="text-subtitle1 q-mt-sm">Water</div>
                <div class="text-h6">{{ waterTotal }} M3</div>
              </q-card-section>
            </q-card>
          </div>
          <div class="col-12 col-md-4">
            <q-card flat bordered>
              <q-card-section class="text-center">
                <q-icon name="bolt" color="yellow-8" size="40px" />
                <div class="text-subtitle1 q-mt-sm">Electricity</div>
                <div class="text-h6">{{ electricityTotal }} KW</div>
              </q-card-section>
            </q-card>
          </div>
          <div class="col-12 col-md-4">
            <q-card flat bordered>
              <q-card-section class="text-center">
                <q-icon name="local_fire_department" color="red" size="40px" />
                <div class="text-subtitle1 q-mt-sm">Gas</div>
                <div class="text-h6">{{ gasTotal }} M3 </div>
              </q-card-section>
            </q-card>
          </div>
        </div>
      </q-card-section>
    </q-card>
  </q-page>
</template>

<script setup>
import { ref, onMounted } from 'vue'

const waterTotal = ref(0)
const electricityTotal = ref(0)
const gasTotal = ref(0)

function calcTotal(key) {
  const arr = JSON.parse(localStorage.getItem(key) || '[]')
  return arr.reduce((sum, r) => sum + Number(r.amount), 0)
}

onMounted(() => {
  waterTotal.value = calcTotal('waterRecords')
  electricityTotal.value = calcTotal('electricityRecords')
  gasTotal.value = calcTotal('gasRecords')
})
</script>
