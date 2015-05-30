angular.module('groceryChoice', ['ui.bootstrap'])
    
    //.service('CategoryGroceryService', [function () {
    //    var self = this;

    //    self.majorCategoryId = null;

    //    self.minorCategoryId = null;

    //    self.itemCategoryId = null;
    //}])
    .factory('MinorCategoryService', ['$http', function ($http) {
        return {
            query: function () {
                return $http.get('/api/minorcategory/');
            },
            get: function (id) {
                return $http.get('api.minorcategory' + id);
            }
        };
    }])
    .factory('MajorCategoryService', ['$http', function ($http) {
        return {
            query: function () {
                return $http.get('/api/majorcategory/');
            },
            get: function (id) {
                return $http.get('api/majorcategory/' + id);
            }
        };
    }])
    .factory('ItemCategoryService', ['$http', function ($http) {
        return {
            query: function () {
                return $http.get('/api/itemcategory/');
            },
            get: function (id) {
                return $http.get('/api/itemcategory/' + id);
            }
        };
    }])
    //.factory('BrandGroceryService', ['$http', function ($http) {
    //    return {
    //        query: function () {
    //            return $http.get('/api/brandgrocery/');
    //        },
    //        get: function (id) {
    //            return $http.get('/api/brandgrocery/' + id);
    //        }
    //    };
    //}])
    //.service('GenericGroceryService', ['$http', function ($http) {
    //    return {
    //        query: function () {
    //            return $http.get('/api/genericgrocery/');
    //        },
    //        get: function (id) {
    //            return $http.get('/api/genericgrocery/' + id);
    //        }
    //    };
    //}])
    //.controller('GroceryCtrl', ['BrandGroceryService', 'GenericGroceryService',
    //    function (BrandGroceryService, GenericGroceryService) {

    //        var self = this;

    //        self.brandGroceries = {};
    //        self.genericGroceries = {};

    //        BrandGroceryService.query().then(function (response) {
    //            self.brandGroceries = response.data;
    //        }, function (errResponse) {
    //            self.errorMessage = errResponse.data.msg;
    //        });

    //        GenericGroceryService.query().then(function (response) {
    //            self.genericGroceries = response.data;
    //        }, function (errResponse) {
    //            self.errorMessage = errResponse.data.msg;
    //        });

    //}])
    .controller('MajorCategoryCtrl', ['MajorCategoryService', function (MajorCategoryService) {

        var self = this;

        self.majorCategories = {};

        MajorCategoryService.query().then(function (response) {
            self.majorCategories = response.data;
        }, function (errResponse) {
            self.errorMessage = errResponse.data.msg;
        });

        self.status = {
            isItemOpen: new Array(self.majorCategories.length),
            isFirstDisabled: false
        };

    }])
    .controller('MinorCategoryCtrl', ['MinorCategoryService', function (MinorCategoryService) {

        var self = this;

        self.minorCategories = {};

        MinorCategoryService.query().then(function (response) {
            self.minorCategories = response.data;
        }, function (errResponse) {
            self.errorMessage = errResponse.data.msg;
        });

        self.status = {
            isItemOpen: new Array(self.minorCategories.length),
            isFirstDisabled: false
        };
    }])
    .controller('ItemCategoryCtrl', ['ItemCategoryService', function (ItemCategoryService) {

        var self = this;

        self.itemCategories = {};

        ItemCategoryService.query().then(function (response) {
            self.itemCategories = response.data;
        }, function (errResponse) {
            self.errorMessage = errResponse.data.msg;
        });
    }]);