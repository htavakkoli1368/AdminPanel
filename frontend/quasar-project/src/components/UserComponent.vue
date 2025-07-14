<template>  
    <div class="q-pa-md">
      <q-table style="height: 400px"
               flat bordered
               title="Users"
               :rows="rows"
               :columns="columns"
               row-key="index"
               virtual-scroll
                />
    </div>
    <q-btn @click="getUsers">show Users</q-btn> 
</template> 
  <script>
    import { onMounted, reactive, ref, toRefs } from "vue";   
    import axios from "axios";
   export default {
      setup() {
       const users = ref(null);
      const pagination= ref({
         rowsPerPage: 0
       })
      const state = reactive({
      columns : [
          { name: 'id', align: 'center', label: 'id', field: 'id', sortable: true },
          { name: 'userName', align: 'center', label: 'userName', field: 'userName', sortable: true },
          { name: 'password', align: 'center', label: 'password', field: 'password', sortable: true },
          { name: 'role', align: 'center', label: 'role', field: 'role', sortable: true },
          { name: 'isAdmin', align: 'center', label: 'isAdmin', field: 'isAdmin', sortable: true }
        ],
      rows :[          
        ]
      });
       onMounted( () => {
         getUsers();
       });
      function getUsers() {
        axios.get('http://localhost:5101/api/Users/internal')
          .then(function (response) {         
            users.value = response.data;
            response.data.forEach((element) => {              
              state.rows.push(element);
            });
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
        ...toRefs(state),
        getUsers,
        users,
        pagination

      }
    }
  }
</script>
 
