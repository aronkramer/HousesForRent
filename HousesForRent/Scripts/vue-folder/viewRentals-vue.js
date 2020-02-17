new Vue({
    el: '#tenant',
    mounted: function () {
        this.allRentals();
        this.getLocations();
    },
    data: {
        rentals: [],
        locations: '',
        cities: [],
        theLocationId: ''
    },
    methods: {
        allRentals: function () {
            document.getElementById("temp").value = -1;
            document.getElementById("getLocationId").value = "";
            $.get("/Tenant/AllRentals", result => {
                this.rentals = result;
            });
        },
        getLocations: function () {
            $.get("/Leaser/GetLocations", result => {
                this.cities = result;
            });
        },
        getLocationIdOnInput: function () {
            var locationName = $('#getLocationId').val();
            var id = this.cities;
            var cityId = id.find(function (element) {
                var city = element.City;
                var state = element.State;
                var country = element.Country;
                var fulllocation = city + ' ' + state + ' ' + country;
                return locationName === fulllocation;
            }).Id;
            this.theLocationId = cityId;
            var locationsWithId = this.rentals.filter(function (row) {
                if (row.LocationId === cityId) {
                    return row;
                }
            });
            this.rentals = locationsWithId;
        },
        filterDates: function () {
            var d = $('#startingDate').val();
            console.log(d);
        },
        filterFurn: function () {
            var checked = $('#temp').val();
            if (checked == 0) {
                var isFurnished = this.rentals.filter(function (row) {
                    if (row.Furnished) {
                        return row;
                    }
                })
                this.rentals = isFurnished;
            }
            else {
                var isFurnished = this.rentals.filter(function (row) {
                    if (!row.Furnished) {
                        return row;
                    }
                })
                this.rentals = isFurnished;
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