<template>
    <div id="add-client">
  
      <label>Client ID:</label><br>
      <input type="text" v-model="clientId" /> <br>

      <label>Name</label><br>
      <input type="text" v-model="name" /> <br>

      <label>Surname:</label><br>
      <input type="text" v-model="surname" /> <br>
  
      <button @click="submit" id="submit-button">Create Client</button>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        clientId: '',
        name: '',
        surname: ''
      }
    },
    methods: {
      submit() {
        //this.$emit('submit', this.email)
        let params = {
          id: this.clientId,
          name: this.name,
          surname: this.surname
        }
        fetch('https://localhost:44325/Client/AddClient?' + new URLSearchParams(params),{method:'POST'})
          .then(r => r.json())
          .then(json => {
            console.log(json);
            location.reload();
          });
      }
    }
  }
  </script>