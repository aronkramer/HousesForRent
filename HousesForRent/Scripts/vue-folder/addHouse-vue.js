new Vue({
    el: '#landlord',
    mounted: function () {

    },
    data: {
        tester: 111111,
        listingsInfo: {
            ContactInfo: '',
            Bedrooms:    '',
            Bathrooms:   '',
            Price:       '',
            Comments:    ''
        }
        
    },
    methods: {
        addRental: function () {
            $.post("/Leaser/AddRental", this.listingsInfo);
        }
    }
})