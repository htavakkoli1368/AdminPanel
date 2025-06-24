<script>
  import axios from "axios";
  import {ref} from "vue";
  export default {
    props: ["msg"],
    setup(props, { emit }) {
      const users = ref(null);
      function getUser() {
        axios.get('http://localhost:5101/api/Users/internal')
          .then(function (response) {
            // handle success
            console.log("response");
            console.log(response);
            users.value = response.data;
          })
          .catch(function (error) {
            // handle error
            console.log(error);
          })
          .finally(function () {
            // always executed
          });
      }
      return {
        getUser,
        users
      }
    }
  }
</script>

<template>
  <div class="greetings">
    <h1 class="green">{{ msg }}</h1>
    <button @click="getUser()">get user</button>
    <p>{{users}}</p>
    <h3>
      You’ve successfully created a project with
      <a href="https://vite.dev/" target="_blank" rel="noopener">Vite</a> +
      <a href="https://vuejs.org/" target="_blank" rel="noopener">Vue 3</a>.
    </h3>
  </div>
</template>

<style scoped>
h1 {
  font-weight: 500;
  font-size: 2.6rem;
  position: relative;
  top: -10px;
}

h3 {
  font-size: 1.2rem;
}

.greetings h1,
.greetings h3 {
  text-align: center;
}

@media (min-width: 1024px) {
  .greetings h1,
  .greetings h3 {
    text-align: left;
  }
}
</style>
