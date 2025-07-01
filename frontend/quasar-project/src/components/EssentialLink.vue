<template>
  <q-list v-bind="itemProps">
    <q-item clickable :to="link" exact>
      <q-item-section>{{title}}</q-item-section>
    </q-item>  
  </q-list>
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
    setup(props ) {
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
