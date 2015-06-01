angular.module('groceryChoice', ['ui.bootstrap', 'ngRoute'])
    .config(function ($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(false);

        //$locationProvider.hashPrefix('#');

        $routeProvider.when('/', {
            templateUrl: 'Scripts/views/welcome.html'
        }).when('/:majorCategory', {
            templateUrl: 'Scripts/views/majorCategoryGrocery.html',
            controller: ['$routeParams', function($routeParams) {
                this.majorCateogry = $routeParams.majorCategory;
            }],
            controllerAs: 'CategoryMenuCtrl'
        }).when('/:majorCategory/:minorCategory', {
            templateUrl: 'Scripts/views/minorCategoryGrocery.html',
            controller: ['$routeParams', function ($routeParams) {
                //this.majorCateogry = $routeParams.majorCategory;
                this.minorCategory = $routeParams.minorCategory;
            }],
            controllerAs: 'CategoryMenuCtrl'
        });
    })
    .factory('MinorCategoryService', ['$http', function ($http) {
        return {
            query: function () {
                return $http.get('/api/minorcategory/');
            },
            get: function (id) {
                return $http.get('api/minorcategory' + id);
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
    .factory('BrandGroceryService', ['$http', function ($http) {
        return {
            query: function () {
                return $http.get('/api/brandgrocery/');
            },
            get: function (id) {
                return $http.get('/api/brandgrocery/' + id);
            }
        };
    }])
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
    .controller('CategoryMenuCtrl', [ function () {
        
        var self = this;

        self.majorCategory = '';

        self.minorCategory = '';

        self.itemCategory = '';

    }])
    .controller('GroceryCategoryCtrl', [ function () {

        var self = this;


        self.majorCategory = 0;

        self.minorCategory = 0;

        self.itemCategory = 0;
    }])
    .controller('GroceryCtrl', ['BrandGroceryService',
        function (BrandGroceryService) {

            var self = this;

            self.brandGroceries = {};
            //self.genericGroceries = {};

            BrandGroceryService.query().then(function (response) {
                self.brandGroceries = response.data;
            }, function (errResponse) {
                self.errorMessage = errResponse.data.msg;
            });

            //GenericGroceryService.query().then(function (response) {
            //    self.genericGroceries = response.data;
            //}, function (errResponse) {
            //    self.errorMessage = errResponse.data.msg;
            //});

    }])
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