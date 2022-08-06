<template>
    <!--<div>
        <button @click="fetch">Fetch from API</button>
    </div>-->
    <ShoppingList /><!--:msg="message"-->
</template>

<script>
    import axios from "axios";
    import ShoppingList from './components/ShoppingList.vue'

    export default {
        name: 'App',
        data() {
            return {
                message: "Welcome to Your Vue.js App",
            };
        },
        methods: {
            async fetch() {
                try {
                    const url = "http://localhost:39326/api/ShoppingItems";
                    const response = await axios.get(url);
                    const data = response.data;
                    this.message = data;
                } catch (error) {
                    this.message = error;
                }
            },
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
