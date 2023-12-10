<template>
  <div id="add-transaction">

    <label>Amount:</label><br>
    <input type="number" min="1" step="any" v-model="amount" /> <br>
    <label>Card Number:</label><br>
    <input type="text" v-model="cardnumber" /> <br>
    <label>Date:</label><br>
    <input type="datetime-local" v-model="date" /> <br>
    <label>Transaction Type:</label><br>
    <select v-model="selectedTransactionType">
      <option v-for="transactionType in transactionTypes" :value="transactionType.typeId" :key="transactionType.typeId">{{ transactionType.typeName }} </option>
    </select>

    <label>Client:</label><br>
    <select v-model="selectedClient">
      <option v-for="client in clients" :value="client.id" :key="client.id">{{ client.name }} {{ client.surname }} </option>
    </select>

    <label>Currency:</label><br>
    <select >
      <option value="0">--Please choose an option--</option>
      <option value="1">USD </option>
      <option value="2" > EUR </option>
      <option value="3">BYN </option>
      <option value="4">RUB </option>
    </select>

    <button @click="submit" id="submit-button">Submit</button>
  </div>
</template>

<script>
export default {
  data() {
    return {
      amount: null,
      cardnumber: null,
      date: null,
      clients: [],
      selectedClient : null,
      transactionTypes: [],
      selectedTransactionType : null,
      currency: null

    }
  },
  methods: {
    submit() {
      //this.$emit('submit', this.email)
      let params = {
        amount: this.amount,
        cardnumber: this.cardnumber,
        date: this.date,
        type: this.transactionTypes.find(x=> x.typeId ==  this.selectedTransactionType).typeName,
        clientId: this.selectedClient,
         name: this.clients.find(x=> x.id ==  this.selectedClient).name,
         surname: this.clients.find(x=> x.id ==  this.selectedClient).surname ,
         currency: "USD"
      }
      fetch('https://localhost:44325/Transaction/AddTransaction?' + new URLSearchParams(params), { method: "POST" })
        .then(r => r.json())
        .then(json => {
          console.log(json);
          //location.reload();
        });
    }
  },
  created() {
    fetch('https://localhost:44325/Client/GetClients')
      .then(r => r.json())
      .then(json => {
        console.log(json);
        this.$data.clients = json;
      });

      fetch('https://localhost:44325/TransactionType/GetTransactionTypes')
      .then(r => r.json())
      .then(json => {
        console.log(json);
        this.$data.transactionTypes = json;
      });


  }
}
</script>