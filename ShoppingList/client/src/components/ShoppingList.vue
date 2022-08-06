<template>
    <div class="shopping">
        <!--<h1>{{ msg }}</h1>-->
        <form id="shopping-list">
            <h2>Shopping List</h2>
            <table id="shopping-list-table" class="table table-hover">
                <thead>
                    <tr>
                        <th>Item</th>
                        <th>Amount</th>
                        <th>Quantity</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tr v-for="(item, index) in itemsList" :key="item">
                    <td>
                        <span v-show="!item.inEditMode">{{ item.itemName }}</span>
                        <input v-bind:placeholder="item.itemName" v-show="item.inEditMode" v-model="item.itemName" class="form-control" />
                    </td>

                    <td>
                        <span v-show="!item.inEditMode">${{ item.amount }}</span>
                        <input type="number" v-bind:placeholder="item.amount" v-show="item.inEditMode" v-model="item.amount" class="form-control" />
                    </td>

                    <td>
                        <span v-show="!item.inEditMode">{{ item.quantity }} pc(s) </span>
                        <input type="number" v-bind:placeholder="item.quantity" v-show="item.inEditMode" v-model="item.quantity" class="form-control" />
                    </td>
                    <td>
                        <button type="button" class="btn btn-success" v-show="item.inEditMode" @click="editItemComplete(item)"><i class="fa fa-save"></i> Save  </button>
                        <button type="button" class="btn btn-info" v-show="!item.inEditMode" @click="editItem(item)"><i class="fa fa-edit"></i> Edit  </button>
                        <button type="button" class="btn btn-danger" @click="removeItem(index)"><i class="fa fa-remove"></i> Delete  </button>
                    </td>
                </tr>
            </table>
            <h4>Add new item</h4>
            <br />
            <div class="row col-md-6">
                <div class="col-md-6 form-group">
                    Name
                    <input type="text" v-model="itemName" class="form-control">
                </div>

                <div class="col-md-6 form-group">
                    Amount
                    <input type="number" v-model="amount" class="form-control">
                </div>
            </div>

            <div class="row col-md-6">
                <div class="col-md-6 form-group">
                    Quantity
                    <input type="number" v-model="quantity" class="form-control" autofocus>
                </div>
            </div>

            <div class="row col-md-6">
                <button type="button" @click="addItem" class="btn btn-primary"><i class="fa fa-plus"></i> Add </button>
            </div>

        </form>
    </div>
</template>

<script>
    export default {
        name: 'ShoppingList',
        props: {
            msg: String
        },
        data() {
            return {
                quantity: '',
                itemName: '',
                // add sample data for now
                itemsList: [
                    {
                        quantity: 3,
                        amount: 1.5,
                        itemName: "Apples",
                        inEditMode: false
                    },
                    {
                        quantity: 6,
                        amount: 1,
                        itemName: "Pears",
                        inEditMode: false
                    }],
                inEditMode: false
            };
        },
        methods: {
            addItem: function () {
                var quantityIN = this.quantity;
                var itemNameIN = this.itemName.trim();
                this.itemsList.push({
                    quantity: quantityIN,
                    itemName: itemNameIN,
                    inEditMode: false
                });
                this.clearAll();
            },
            clearQuantity: function () {
                this.quantity = '';
            },
            clearItemName: function () {
                this.itemName = '';
            },
            clearAll: function () {
                this.clearQuantity();
                this.clearItemName();
            },
            removeItem: function (index) {
                this.itemsList.splice(index, 1); //delete 1 element from the array at the position index
            },
            editItem: function (item) {
                item.inEditMode = true;
            },
            editItemComplete: function (item) {
                item.inEditMode = false;
            },

        },
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    a {
        color: #42b983;
    }

    h2, h4 {
        font-family: 'Jost', sans-serif;
        background-color: #4fc08d;
        color: white;
    }

    #shopping-list-table {
        table-layout: fixed;
        width: 50%;
        vertical-align: middle;
    }

    button {
        margin-left: 2%;
    }
</style>
