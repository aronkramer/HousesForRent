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
        location: {
            City: '',
            State: '',
            Country: ''
        },
        listings: null,
        countryLocations: [],
        countryLocation: '',
        getState:'',
        country: '',
        theLocationId: ''
    },
    methods: {
        addRental: function () {
            var cont = this.listingsInfo.ContactInfo;
            var bed = this.listingsInfo.Bedrooms;
            var bath = this.listingsInfo.Bathrooms;
            var date = this.listingsInfo.Date;
            var loc = this.listingsInfo.LocationId
            if (cont && bed && bath && date && loc) {
                var locationId = this.theLocationId;
                var info = this.listingsInfo;
                info.LocationId = locationId;
                $.ajax({
                    url: "/Leaser/AddRental",
                    method: "POST", data: info
                }).done(function (data) {
                    console.log(data.newUrl);
                    alert('Your listing has been submitted');
                    window.location.replace(data.newUrl);
                });
            }
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
        getLocationIdOnInput: function () {
            var locationName = $('#getLocationId').val();

            var id = this.countryLocations;
            var locationId = id.find(function (element) {
                var city = element.City;
                var state = element.State;
                var country = element.Country;
                var fulllocation = city + ' ' + state + ' ' + country;
                return locationName === fulllocation;
            }).Id;
            this.theLocationId = locationId;
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