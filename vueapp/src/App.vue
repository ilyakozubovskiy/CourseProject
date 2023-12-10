<template>
    <img id="logo" alt="MTBank logo" src="./assets/logo-mtbank.png">
    <p>
        Search Transactions <router-link to="/"><img id="transactions-button" alt="Transactions"
                src="./assets/view-records.png"></router-link>
        Add New Transaction <router-link to="/add-transaction"><img id="add-transaction-button" alt="Add Transaction"
                src="./assets/transaction.png"></router-link>
        Add New Client <router-link to="/add-client"><img id="add-client-button" alt="Add Client"
                src="./assets/client.png"></router-link>
    </p>
    <router-view />
</template>

<script>

export default {
    name: 'App',
}
</script>

<style>
#app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
}

#logo {
    height: 100px;
    width: 300px;
}

#add-transaction-button,
#add-client-button,
#transactions-button {
    width: 40px;
    height: 40px;
    display: inline-block;
    vertical-align: middle;
    margin-right: 10px;
}

#edit-transaction-button {
    width: 30px;
    height: 30px;

}

#add-transaction,
#add-client {
    text-align: left;
    width: 25%;
    margin: auto;
}

input,
select {
    display: inline-block;
    width: 350px;
    margin: 20px auto;
    padding: 10px;
    background-size: 15px 15px;
    font-size: 16px;
    border: none;
    border-radius: 5px;
    box-shadow: rgba(50, 50, 93, 0.25) 0px 2px 5px -1px, rgba(0, 0, 0, 0.3) 0px 1px 3px -1px;
}

select {
    width: 370px;
}

#search {
    display: inline-block;
    width: 350px;
    margin: 20px auto;
    padding: 10px 45px;
    background: white url("assets/search-icon.svg") no-repeat 15px center;
    background-size: 15px 15px;
    font-size: 16px;
    border: none;
    border-radius: 5px;
    box-shadow: rgba(50, 50, 93, 0.25) 0px 2px 5px -1px, rgba(0, 0, 0, 0.3) 0px 1px 3px -1px;
}

.content {
    width: fit-content;
    margin: auto;

    border-collapse: collapse;
    font-size: 0.9em;
    font-family: sans-serif;
    box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);
}

.content thead tr {
    background-color: #0f56a8;
    color: #ffffff;
    text-align: center;
}

.content th,
.content td {
    padding: 12px 15px;
}

.content tbody tr.active-row {
    font-weight: bold;
    color: #009879;
}

.content tbody tr {
    border-bottom: 1px solid #dddddd;
}

#add-record {
    width: 50px;
    height: 50px;
}


/* CSS */
#submit-button {
    appearance: button;
    backface-visibility: hidden;
    background-color: #405cf5;
    border-radius: 6px;
    border-width: 0;
    box-shadow: rgba(50, 50, 93, .1) 0 0 0 1px inset, rgba(50, 50, 93, .1) 0 2px 5px 0, rgba(0, 0, 0, .07) 0 1px 1px 0;
    box-sizing: border-box;
    color: #fff;
    cursor: pointer;
    font-family: -apple-system, system-ui, "Segoe UI", Roboto, "Helvetica Neue", Ubuntu, sans-serif;
    font-size: 100%;
    height: 44px;
    line-height: 1.15;
    margin: 12px 0 0;
    outline: none;
    overflow: hidden;
    padding: 0 25px;
    position: relative;
    text-align: center;
    text-transform: none;
    transform: translateZ(0);
    transition: all .2s, box-shadow .08s ease-in;
    user-select: none;
    -webkit-user-select: none;
    touch-action: manipulation;
    width: 100%;
}

.submit-button:disabled {
    cursor: default;
}

.submit-button:focus {
    box-shadow: rgba(50, 50, 93, .1) 0 0 0 1px inset, rgba(50, 50, 93, .2) 0 6px 15px 0, rgba(0, 0, 0, .1) 0 2px 2px 0, rgba(50, 151, 211, .3) 0 0 0 4px;
}</style>

