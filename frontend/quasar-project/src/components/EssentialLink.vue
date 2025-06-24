<template>
  <q-item clickable
          v-bind="itemProps">
    <q-item-section v-if="icon" avatar>
      <q-icon :name="icon" />
    </q-item-section>
    <q-item-section>
      <q-item-label>{{ title }}</q-item-label>
      <q-item-label caption>{{ caption }}</q-item-label>
    </q-item-section>
  </q-item>
</template>

<script>
  import { defineComponent, computed } from 'vue'

  export default defineComponent({
    name: 'EssentialLink',
    props: {
      title: String,
      caption: String,
      link: String,
      icon: String,
      path: String
    },
    setup(props) {
      const itemProps = computed(() => {
        if (props.link) {
          return {
            tag: 'a',
            href: props.link,
            target: '_blank'
          }
        }
        if (props.path) {
          return { to: props.path, exact: true }
        }
        return {}
      });
      return { itemProps }
    }
  })
</script>
