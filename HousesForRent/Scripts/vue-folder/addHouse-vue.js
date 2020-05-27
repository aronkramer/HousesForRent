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
            Bedrooms: '',
            Bathrooms: '',
            Price: '',
            Comments: '',
            Date: '',
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
        getState: '',
        country: '',
        theLocationId: '',
        Edit: false,
        pictures: [],
        enabled: false,
        indexForRenewAdModal: null,
        errors: []
    },
    methods: {
        paymentModal: function () {
            var cont = this.listingsInfo.ContactInfo;
            var bed = this.listingsInfo.Bedrooms;
            var bath = this.listingsInfo.Bathrooms;
            var date = this.listingsInfo.Date;
            var loc = this.listingsInfo.LocationId;
            if (cont && bed && bath && date && loc) {
                $('#addListingModal').modal();
            }
            else {
                this.errors = [];

                if (!cont) {
                    this.errors.push('ContactInfo required.');
                }
                if (!bed) {
                    this.errors.push('Bedrooms required.');
                }
                if (!bath) {
                    this.errors.push('Bathrooms required.');
                }
                if (!date) {
                    this.errors.push('Date required.');
                }
                if (!loc) {
                    this.errors.push('Location required.');
                }
            }
            
        },
        addRental: function () {
            var cont = this.listingsInfo.ContactInfo;
            var bed = this.listingsInfo.Bedrooms;
            var bath = this.listingsInfo.Bathrooms;
            var date = this.listingsInfo.Date;
            var loc = this.listingsInfo.LocationId;
            if (cont && bed && bath && date && loc) {
                var locationId = this.theLocationId;
                var info = this.listingsInfo;
                info.LocationId = locationId;
                $.ajax({
                    url: "/Leaser/AddRental",
                    method: "POST", data: info,
                    success: function () {
                        window.location = "/Leaser/UsersListings";
                    },
                });
            }
        },
        usersListings: function () {
            $.get("/Leaser/GetUsersListings", result => {
                this.listings = result.map(r => {
                    var obj = {};
                    obj.BaseObj = r;
                    obj.BaseObj.Expired = r.IsExpired;
                    obj.Edit = false;
                    obj.Copy = null;
                    return obj;
                });
            });
        },
        getLocations: function () {
            $.get("/home/GetLocations", result => {
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
                item.Copy = jQuery.extend(true, {}, item.BaseObj);
            }
            else {
                this.cancel(item);
            }
        },
        cancel: function (object) {
            if (object.BaseObj.Id) {
                object.Date = moment.parseZone(object.BaseObj.Date).format("YYYY-MM-DD");
                object.BaseObj = object.Copy;
                object.Edit = false;
                console.log(object);
            }
        },
        updateListing: function (index) {
            var item = this.listings[index];
            item.BaseObj.Date = moment.parseZone(item.BaseObj.Date).format("YYYY-MM-DD");
            item.BaseObj.Expiration = moment.parseZone(item.BaseObj.Expiration).format("YYYY-MM-DD");
            if (item.BaseObj) {
                $.post("/Leaser/Update", { listing: item.BaseObj });
                item.Edit = !item.Edit;
            }
        },
        seePictures: function (Id) {
            $.get("/Leaser/GetPictures", { PicId: Id }, result => {
                this.pictures = result;
            });
        },
        DeletePic: function (Id, FileName, Picture) {
            $.post("/Leaser/DeletePic", { PicId: Id, Picture });
            this.seePictures(FileName);
        },
        pauseListing: function (Id) {
            $.post("/Leaser/Pause", { Id });
            const delay = ms => new Promise(res => setTimeout(res, ms));
            const pause = async () => {
                await delay(150);
                this.usersListings();
            };
            pause();
        },
        getIdToRenew: function (index) {
            this.indexForRenewAdModal = index;
        },
        renewAd: function (index) {
            var item = this.listings[index];
            item.BaseObj.Date = moment.parseZone(item.BaseObj.Date).format("YYYY-MM-DD");
            $.post("/Leaser/RenewAd", { listing: item.BaseObj });
            const delay = ms => new Promise(res => setTimeout(res, ms));
            const pause = async () => {
                await delay(350);
                window.location.reload();
            };
            pause();
        },
        deleteListing: function (index) {
            var item = this.listings[index];
            $.post(`/leaser/deleteItem`, { listingId: item.BaseObj.Id, userid: item.BaseObj.UserId });
            const delay = ms => new Promise(res => setTimeout(res, ms));
            const pause = async () => {
                await delay(350);
                window.location.reload();
            };
            pause();
        },
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
});

