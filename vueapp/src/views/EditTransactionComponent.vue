<template>
  <div id="add-transaction">

    <label>Amount:</label><br>
    <input type="number" min="1" step="any" v-model="amount" /> <br>
    <label>Card Number:</label><br>
    <input type="text" v-model="cardnumber" /> <br>
    <label>Date:</label><br>
    <input type="datetime-local" v-model="date" /> <br>
    <label>Type:</label><br>
    <input type="text" v-model="type" /><br>

    <label>Client Id:</label><br>
    <input type="text" v-model="clientId" /><br>

    <button @click="edit" id="submit-button">Edit</button>
  </div>
</template>
  
<script>
export default {
  data() {
    return {
      amount: '',
      cardnumber: '',
      date: '',
      type: '',
      clientId: '',
    }
  },
  methods: {
    edit() {
      //this.$emit('submit', this.email)
      let params = {
        transactionId: this.$route.query.transactionId,
        amount: this.amount,
        cardnumber: this.cardnumber,
        date: this.date,
        type: this.type,
        clientId: this.clientId,
      }
      fetch('https://localhost:44325/Transaction/EditTransaction?' + new URLSearchParams(params),
        {
          method: 'PUT',

        })
        .then(r => r.json())
        .then(json => {
          console.log(json);
          //location.reload();
        });
    }
  },
  created() {
    fetch('https://localhost:44325/Transaction/GetTransaction?' + new URLSearchParams({transactionId: this.$route.query.transactionId }))
    .then(r => r.json())
    .then(json => {
      this.$data.amount =  json.amount;
      this.$data.cardnumber = json.cardNumber;
      this.$data.date = json.date ;
      this.$data.type =  json.type;
      this.$data.clientId=  json.clientId;
      return;
    });

  }
}
</script>