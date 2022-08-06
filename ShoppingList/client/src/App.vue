<template>
    <ShoppingList :shoppingItems="shoppingListData"/>
</template>

<script>
    import axios from "axios";
    import ShoppingList from './components/ShoppingList.vue'

    export default {
        name: 'App',
        data() {
            return {
                shoppingListData: []
            };
        },
        methods: {
            async fetch() {
                try {
                    const url = "http://localhost:39326/api/ShoppingItems";
                    const response = await axios.get(url);
                    const data = response.data;
                    this.shoppingListData = data;
                } catch (error) {
                    console.log(error);
                }
            },
        },
        beforeMount() {
            this.fetch()
        },
        components: {
            ShoppingList
        }
    }
</script>

<style>
    #app {
        font-family: Avenir, Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        color: #2c3e50;
        margin-top: 60px;
    }

    body {
        padding: 1%;
    }

</style>
