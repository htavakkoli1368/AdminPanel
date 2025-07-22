<template>
  <q-page class="q-pa-md">
    <div class="text-h5 text-center q-mb-lg">ثبت و مشاهده مصرف گاز</div>
    <q-card class="q-mb-md">
      <q-card-section>
        <q-form @submit.prevent="addRecord">
          <div class="row q-col-gutter-md">
            <div class="col-12 col-md-6">
              <q-input
                v-model="amount"
                label="مقدار مصرف (متر مکعب)"
                type="number"
                outlined
                dense
                required
              />
            </div>
            <div class="col-12 col-md-6">
              <q-input
                v-model="date"
                label="تاریخ"
                type="date"
                outlined
                dense
                required
              />
            </div>
          </div>
          <div class="q-mt-md text-center">
            <q-btn color="primary" label="ثبت مصرف" type="submit" />
          </div>
        </q-form>
      </q-card-section>
    </q-card>

    <q-card>
      <q-card-section>
        <div class="text-subtitle2 q-mb-md">لیست مصرف‌های ثبت‌شده</div>
        <q-table
          :rows="records"
          :columns="columns"
          row-key="id"
          flat
          bordered
          no-data-label="هنوز مصرفی ثبت نشده است"
        />
      </q-card-section>
    </q-card>
  </q-page>
</template>

<script setup>
import { ref, onMounted } from 'vue'

const amount = ref('')
const date = ref('')
const records = ref([])

const columns = [
  { name: 'date', label: 'تاریخ', field: 'date', align: 'center' },
  { name: 'amount', label: 'مقدار (متر مکعب)', field: 'amount', align: 'center' }
]

onMounted(() => {
  const saved = localStorage.getItem('gasRecords')
  if (saved) {
    records.value = JSON.parse(saved)
  }
})

function addRecord() {
  if (amount.value && date.value) {
    records.value.push({
      id: Date.now(),
      date: date.value,
      amount: amount.value
    })
    localStorage.setItem('gasRecords', JSON.stringify(records.value))
    amount.value = ''
    date.value = ''
  }
}
</script>