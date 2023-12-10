<template>
    <div class="post">

        <div>
            <input @keyup.enter="fetchData" type="text" placeholder="Enter Transaction or Client Identifier.."
                v-model="myInput" id="search" />
        </div>
        <div v-if="loading" class="loading">
            Loading...
        </div>
        <div v-if="noRecords" class="loading">
            No records!
        </div>
        <div v-if="table" class="content">

            <table>
                <thead>
                    <tr>
                        <th>Transaction Id</th>
                        <th>Client Id</th>
                        <th>Name</th>
                        <th>Surname</th>
                        <th>Amount</th>
                        <th>Type</th>
                        <th>Currency</th>
                        <th>Date</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="transaction in post" :key="transaction.transactionId">
                        <td>{{ transaction.transactionId }}</td>
                        <td>{{ transaction.clientId }}</td>
                        <td>{{ transaction.name }}</td>
                        <td>{{ transaction.surname }}</td>
                        <td>{{ transaction.amount }}</td>
                        <td>{{ transaction.type }}</td>
                        <td>{{ transaction.currency }}</td>
                        <td>{{ transaction.date }} </td>
                        <td><router-link :to="`/edit-transaction?transactionId=${transaction.transactionId}`"><img
                                    id="edit-transaction-button" alt="EditTransaction" src="./assets/edit-record.png"
                                    click=""> </router-link> </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script lang="js">
import { defineComponent } from 'vue';

export default defineComponent({
    data() {
        return {
            loading: false,
            post: null,
            table: false,
            myInput: "",
            noRecords: false
        };
    },
    created() {
        // fetch the data when the view is created and the data is
        // already being observed
        //this.fetchData();
    },
    watch: {
        // call again the method if the route changes
        '$route': 'fetchData'
    },
    methods: {
        fetchData() {
            this.post = null;
            this.loading = true;
            this.table = false;
            this.noRecords = false;

            //if (!this.myInput) {
            //    this.myInput = " "
            //}
            fetch('https://localhost:44325/Transaction/GetTransactions?' + new URLSearchParams({ parameter: this.myInput }))
                .then(r => r.json())
                .then(json => {
                    this.post = json;
                    this.loading = false;

                    if (json.length > 0) {
                        this.table = true;

                    }
                    else {
                        this.noRecords = true;
                    }


                    return;
                });
        },

    },
});
</script>