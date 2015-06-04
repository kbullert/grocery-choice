angular.module('groceryChoice', ['ngRoute'])
    .config(function ($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);

        $locationProvider.hashPrefix('#');

        $routeProvider.when('/', {
            templateUrl: 'Scripts/views/welcome.html'
        }).when('/:majorCategory', {
            templateUrl: 'Scripts/views/groceryMajor.html',
            controller: ['$routeParams', function($routeParams) {
                this.majorCateogry = $routeParams.majorCategory;
            }],
            controllerAs: 'CategoryMenuCtrl'
        }).when('/:majorCategory/:minorCategory', {
            templateUrl: 'Scripts/views/groceryMinor.html',
            controller: ['$routeParams', function ($routeParams) {
                this.minorCateogry = $routeParams.minorCategory;
            }],
            controllerAs: 'CategoryMenuCtrl'
        }).when('/:majorCategory/:minorCategory/:itemCategory', {
            templateUrl: 'Scripts/views/groceryItem.html',
            controller: ['$routeParams', function ($routeParams) {
                this.itemCateogry = $routeParams.itemCategory;
            }],
            controllerAs: 'CategoryMenuCtrl'
        });
    })
    .factory('MinorCategoryService', ['$http', '$q', function ($http, $q) {
        return {
            query: function () {
                var promise = $http.get('/api/minorcategory/')
                .success(function (data, status, headers, config) {
                    return data;
                })
                .error(function (data, status, headers, config) {
                    return {"status": false};
                });

                return promise;
            },
            get: function (id) {
                return $http.get('api/minorcategory' + id);
            }
        };
    }])
    .factory('MajorCategoryService', ['$http', '$q', function ($http, $q) {
        return {
                query: function () {
                    var promise = $http.get('/api/majorcategory/')
                    .success(function (data, status, headers, config) {
                        return data;
                    })
                    .error(function (data, status, headers, config) {
                        return {"status": false};
                    });

                    return promise;
                },
            get: function (id) {
                return $http.get('api/majorcategory' + id);
            }
        };
    }])
    .factory('ItemCategoryService', ['$http', '$q', function ($http, $q) {
        return {
                query: function () {
                    var promise = $http.get('/api/itemcategory/')
                    .success(function (data, status, headers, config) {
                        return data;
                    })
                    .error(function (data, status, headers, config) {
                        return {"status": false};
                    });

                    return promise;
                },
            get: function (id) {
                return $http.get('/api/itemcategory/' + id);
            }
        };
    }])
    .factory('BrandGroceryService', ['$http', '$q', function ($http, $q) {
        return {
                query: function () {
                    var promise = $http.get('/api/brandgrocery/')
                    .success(function (data, status, headers, config) {
                        return data;
                    })
                    .error(function (data, status, headers, config) {
                        return {"status": false};
                    });

                    return promise;
                },
            get: function (id) {
                return $http.get('/api/brandgrocery/' + id);
            }
        };
    }])
    //.service('GenericGroceryService', ['$http', '$q',function ($http, $q) {
    //    return {
    //        query: function () {
    //            return $http.get('/api/genericgrocery/');
    //        },
    //        get: function (id) {
    //            return $http.get('/api/genericgrocery/' + id);
    //        }
    //    };
    //}])
    .controller('CategoryGroceryCtrl', [ function () {
        
        var self = this;

        self.major = 0;

        self.minor = 0;

        self.item = 0;

    }])
    .controller('CategoryMenuCtrl', [function () {

        var self = this;

        self.majorCategory = '';

        self.minorCategory = '';

        self.itemCategory = '';
    }])
    .controller('GroceryCtrl', ['BrandGroceryService',
        function (BrandGroceryService) {

            var self = this;

            self.brandGroceries = [];
            //self.genericGroceries = {};

            BrandGroceryService.query().then(function (promise) {
                self.brandGroceries = promise.data;
            }, function (errResponse) {
                self.errorMessage = errResponse.data.msg;
            });

            //GenericGroceryService.query().then(function (response) {
            //    self.genericGroceries = response.data;
            //}, function (errResponse) {
            //    self.errorMessage = errResponse.data.msg;
            //});

    }])
    .controller('CategoryCtrl', ['MajorCategoryService', 'MinorCategoryService', 'ItemCategoryService',
        function (MajorCategoryService, MinorCategoryService, ItemCategoryService) {

        var self = this;

        self.majorCategories = [];
        self.minorCategories = [];
        self.itemCategories = [];

        MajorCategoryService.query().then(function (promise) {
            self.majorCategories = promise.data;
        }, function (errResponse) {
            self.errorMessage = errResponse.data.msg;
        });

        MinorCategoryService.query().then(function (promise) {
            self.minorCategories = promise.data;
        }, function (errResponse) {
            self.errorMessage = errResponse.data.msg;
        });

        ItemCategoryService.query().then(function (promise) {
            self.itemCategories = promise.data;
        }, function (errResponse) {
            self.errorMessage = errResponse.data.msg;
        });

    }]);