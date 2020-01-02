var vm = new Vue({
    el: '#landlord',
    mounted: function () {
        var url = window.location.toString();
        if (url.includes("UsersListings")) {
            this.usersListings()
        }
        if (url.includes("addhouse")) {
            this.getLocations();
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
            Furnished: '',
            LocationId: ''
        },
        listings: null,
        countryLocations: [],
        countryLocation: '',
        stateLocations: [],
        stateLocation: [],
        getState:'',
        country: ''
        
    },
    methods: {
        addRental: function () {
            $.post("/Leaser/AddRental", this.listingsInfo);
            alert('Listing has been added successfully');
            window.location.href = "/Leaser/UsersListings";
        },
        usersListings: function () {
            $.get("/Leaser/GetUsersListings", result => {
                this.listings = result;
            });
        },
        getLocations: function () {
            $.get("/Leaser/GetLocations", result => {
                this.countryLocations = result;
            });
        },
        getcountryId: function () {
            $("input[name=country]").focusout(function () {
                alert($(this).val());
            });
        },
        getLocationIdForInput: function () {
            var test = $('#country').val();
            console.log(test);
        },
        makeEditable: function (item) {
            if (!item.Edit) {
                item.Edit = !item.Edit;
                //item.Copy = jQuery.extend(true, {}, item);
            }

            else {
                this.cancel(item);
            }
        }
    },
    filters: {
        toShortDateString: function (value) {
            if (value) {
                return moment(value).format('L');
            }
            return null;
        },
        isFurnished: function (value) {
            if (value) {
                return '✓';
            }
            return null;
        }
    }
})