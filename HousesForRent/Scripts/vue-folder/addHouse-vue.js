new Vue({
    el: '#landlord',
    mounted: function () {

    },
    data: {
        listingsInfo: {
            ContactInfo: '',
            Bedrooms:    '',
            Bathrooms:   '',
            Price:       '',
            Comments:    ''
        },
        Days: '',
        
    },
    methods: {
        addRental: function () {
            $.post("/Leaser/AddRental", this.listingsInfo);
        },
        addTime: function () {
            $.post("/Leaser/AddTime", { tim: this.Days });
        }
    }
})