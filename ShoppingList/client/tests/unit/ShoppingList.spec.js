import { mount } from '@vue/test-utils'
import ShoppingList from '@/components/ShoppingList.vue'

describe('ShoppingListFilter', () => {
    it("should be [] when hasFilter = true and amount < 20", () => {
        const wrapper = mount(ShoppingList, {
            data() {
                return {
                    hasFilter: true,
                    shoppingList: [{
                        quantity: 3,
                        amount: 1.5,
                        name: "Apples"
                    }]
                }
            }
        })

        expect(wrapper.vm.filteredList).toEqual([]);
    });

    it("should be = to shoppingList when hasFilter = false and amount < 20", () => {
        const wrapper = mount(ShoppingList, {
            data() {
                return {
                    hasFilter: false,
                    shoppingList: [{
                        quantity: 3,
                        amount: 1.5,
                        name: "Oranges"
                    }]
                }
            }
        })

        expect(wrapper.vm.filteredList).toEqual(wrapper.vm.shoppingList);
    });

    it("should be = to shoppingList when hasFilter = true and amount > 20", () => {
        const wrapper = mount(ShoppingList, {
            data() {
                return {
                    hasFilter: false,
                    shoppingList: [{
                        quantity: 3,
                        amount: 21.5,
                        name: "Bananas"
                    }]
                }
            }
        })

        expect(wrapper.vm.filteredList).toEqual(wrapper.vm.shoppingList);
    });

})