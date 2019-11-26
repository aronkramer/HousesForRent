new Vue({
    el: '#tenant',
    mounted: function () {
        this.allRentals();
    },
    data: {
        rentals: [],
    },
    methods: {
        allRentals: function () {
            $.get("/Tenant/AllRentals", result => {
                this.rentals = result;
            });
        }
    }
})