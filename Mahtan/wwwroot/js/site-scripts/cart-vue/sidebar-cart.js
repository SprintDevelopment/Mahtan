var vm = new Vue({
    el: "#cart-nav",
    data: {
        cartItems: [],
    },
    created() {
        this.getCartItems();
    },
    methods: {
        addToCart(productId) {
            axios.get('/User/Cart/AddToCart/?id=' + productId)
                .then(response => {
                    if (response.status == 200) {
                        this.addOrUpdate(response.data);
                    }
                });
        },

        updateCount(item, isIncrease) {
            axios.get('/User/Cart/UpdateCartItem/?id=' + item.productId + '&incOrDecQty=' + isIncrease ? +1 : -1)
                .then(response => {
                    if (response.status == 200) {
                        this.addOrUpdate(response.data);
                    }
                    else
                        this.remove(item.productId);
                })
        },

        removeFromCart(productId) {
            axios.get('/User/Cart/RemoveFromCart/?id=' + productId)
                .then(response => {
                    if (response.status == 200)
                        this.remove(productId);
                })
        },

        getCartItems() {
            axios
                .get("/User/Cart/Items")
                .then((res) => {
                    this.cartItems = res.data;
                })
        },

        addOrUpdate(cartItem) {
            var preCartItem = this.cartItems.find(ci => ci.productId === cartItem.productId);
            if (preCartItem === undefined)
                this.cartItems.push(cartItem);
            else
                preCartItem.qty = cartItem.qty;
        },

        remove(productId) {
            var index = this.cartItems.findIndex(ci => ci.productId === productId);
            if(index >= 0)
                this.$delete(this.cartItems, index);
        },
    },
    computed: {
        totalRequest() {
            return this.cartItems.reduce((acc, item) => acc + (item.price * item.qty), 0);
        }
    }
})