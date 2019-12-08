new Vue({
    el: '#landlord',
    mounted: function () {
        var v = window.location.toString();
        if (v.includes("UsersListings")) {
            this.usersListings()
        }
    },
    data: {
        listingsInfo: {
            ContactInfo: '',
            Bedrooms:    '',
            Bathrooms:   '',
            Price:       '',
            Comments:    '',
            Date:        '',
        },
        listings: null,
       
        
    },
    methods: {
        addRental: function () {
            $.post("/Leaser/AddRental", this.listingsInfo);
            alert('Listing has been added successfully');
            window.location.href = "/Leaser/UsersListings";
        },
        usersListings: function () {
            $.get("/Leaser/GetUsersListings", result => {
               
                console.log(result);
                this.listings = result;
            });
        }
    },
    filters: {
        toShortDateString: function (value) {
            if (value) {
                return moment(value).format('L');
            }
            return null;
        }
    }
})