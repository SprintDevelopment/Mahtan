var vm = new Vue({
    el: "#offcanvasNavbarEmptyShoppingCart",
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
                    var cartItem = this.cartItems.find(ci => ci.productId === productId);
                    if (cartItem === undefined)
                        this.cartItems.push(response.data);
                    else
                        cartItem = response.data;
                })
        },

        updateCount(item, isIncrease) {
            axios.get('/User/Cart/UpdateCartItem/?id=' + item.productId + '&isIncrease=' + isIncrease)
                .then(response => {
                    if (response.data === "")
                        for (var i = this.cartItems.length - 1; i >= 0; i--) {
                            if (this.cartItems[i].productId === item.productId) {
                                this.cartItems.splice(i, 1);
                            }
                        }
                    else
                        item.qty = response.data.qty;
                })
        },

        getCartItems() {
            axios
                .get("/User/Cart/Items")
                .then((res) => {
                    this.cartItems = res.data;
                })
        },
    },
    computed: {
        totalRequest() {
            return this.cartItems.reduce((acc, item) => acc + (item.price * item.qty), 0);
        }
    }
})