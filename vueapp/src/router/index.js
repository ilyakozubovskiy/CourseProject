import { createRouter, createWebHistory } from 'vue-router'
import Transactions from '../views/TransactionsComponent.vue'
import AddTransaction from '../views/AddTransactionComponent.vue'
import EditTransaction from '../views/EditTransactionComponent.vue'
import AddClient from '../views/AddClientComponent.vue'

const routes = [
    {
        path: '/',
        name: 'Transactions',
        component: Transactions
    },
    {
        path: '/add-transaction',
        name: 'AddTransaction',
        component: AddTransaction
    },
    {
        path: '/edit-transaction',
        name: 'EditTransaction',
        component: EditTransaction
    },
    {
        path: '/add-client',
        name: 'AddClient',
        component: AddClient
    }
]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URl),
    routes
})

export default router