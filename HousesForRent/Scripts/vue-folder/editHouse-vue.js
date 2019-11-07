new Vue({
    el: '#tenant',
    mounted: function () {
        //this.getOrders();
    },
    data: {
        StatusName: null,
        testing: 34
    },
    methods: {
        chooseUser: function () {
            $.get("/OrderB2B/UserList", result => {
                this.Users = result;
            });
        },
        getOrders: function () {
            var userId = this.user.Id;
            var statusId = this.StatusName;
            $.get("/OrderB2B/GetOrders", { userId, statusId }, result => {
                result.map(r => {
                    r.ShowDetails = false;
                    r.StatusCopy = null;
                    return r;
                })
                this.orderList = result;
            });
        },
        getOrderDetails: function (order) {
            if (order.ShowDetails) {
                order.ShowDetails = false;
                return;
            }
            $.post("/OrderB2B/GetOrderDetailsByOrderId", { OrderId: order.Id }, result => {
                order.OrderDetails = result;
                order.ShowDetails = true;
            });
        },
    }
});