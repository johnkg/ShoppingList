<template>
    <div class="shopping">
        <form id="shopping-list">
            <h2>Shopping List</h2>
            <div class="form-check">
                <input class="form-check-input" type="checkbox" v-model="hasFilter" id="flexCheckDefault">
                <label class="form-check-label" for="checkFilter">
                    Filter by Subtotal > 20 and Name starts with X
                </label>
            </div>
            <table id="shopping-list-table" class="table table-hover">
                <thead>
                    <tr>
                        <th>Item</th>
                        <th>Quantity</th>
                        <th>Subtotal</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tr v-for="item in filteredList" :key="item">
                    <td>
                        <span v-show="!item.inEditMode">{{ item.name }}</span>
                        <input v-bind:placeholder="item.name" v-show="item.inEditMode" v-model="item.name" class="form-control" />
                    </td>

                    <td>
                        <span v-show="!item.inEditMode">{{ item.quantity }} pc<span v-show="item.quantity > 1">s</span> </span>
                        <input type="number" v-bind:placeholder="item.quantity" v-show="item.inEditMode" v-model="item.quantity" class="form-control" />
                    </td>

                    <td>
                        <span v-show="!item.inEditMode">${{ item.amount }}</span>
                        <input type="number" v-bind:placeholder="item.amount" v-show="item.inEditMode" v-model="item.amount" class="form-control" />
                    </td>

                    <td>
                        <button type="button" class="btn btn-success" v-show="item.inEditMode" @click="editItemComplete(item)"><i class="fa fa-save"></i> Save  </button>
                        <button type="button" class="btn btn-info" v-show="!item.inEditMode" @click="editItem(item)"><i class="fa fa-edit"></i> Edit  </button>
                        <button type="button" class="btn btn-danger" @click="removeItem()"><i class="fa fa-remove"></i> Delete  </button>
                    </td>
                </tr>
            </table>
            <h4>Add new item</h4>
            <br />
            <div class="row col-md-6">
                <div class="col-md-6 form-group">
                    Name
                    <input type="text" v-model="name" class="form-control">
                </div>

                <div class="col-md-6 form-group">
                    Quantity
                    <input type="number" v-model="quantity" class="form-control" autofocus>
                </div>
            </div>

            <div class="row col-md-6">
                <div class="col-md-6 form-group">
                    Subtotal
                    <input type="number" v-model="amount" class="form-control">
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
            shoppingItems: Array
        },
        data() {
            return {
                quantity: '',
                name: '',
                amount: '',
                hasFilter: false,
                inEditMode: false,
                list: []
            };
        },
        methods: {
            addItem () {
                let quantityIN = this.quantity;
                let nameIN = this.name.trim();
                let amountIN = this.amount;
                this.shoppingList.push({
                    quantity: quantityIN,
                    name: nameIN,
                    amount: amountIN,
                    inEditMode: false
                });
                this.clearAll();
            },
            clearQuantity () {
                this.quantity = '';
            },
            clearname () {
                this.name = '';
            },
            clearAmount () {
                this.amount = '';
            },
            clearAll () {
                this.clearQuantity();
                this.clearname();
                this.clearAmount();
            },
            removeItem(item) {
                if (item) {
                    let index = this.shoppingList.findIndex(listItem => listItem.id === item.id);
                    this.shoppingList.splice(index, 1); //delete 1 element from the array at the position index
                }
            },
            editItem (item) {
                item.inEditMode = true;
            },
            editItemComplete (item) {
                item.inEditMode = false;
            },
            copyToList() {
                this.list = this.shoppingItems;
            }
        },
        computed: {
            shoppingList() {
                if (this.list.length == 0)
                    this.copyToList();

                return this.list;
            },
            filteredList() {
                return this.shoppingList.filter(shoppingItem => {
                    if (this.hasFilter)
                        return shoppingItem.amount > 20 && shoppingItem.name.toLowerCase().startsWith('x');
                    else
                        return shoppingItem;
                });
            }
        }
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
        width: 60%;
        vertical-align: middle;
    }

    button {
        margin-left: 2%;
    }
</style>
