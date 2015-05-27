angular.module('groceryChoice', ['ngResource'])
    .service('minorCategoryService', function ($resource) {

        return $resource('http://localhost:6200/api/minorcategory/', {});
    })
    .service('majorCategoryService', function ($resource) {

        return $resource('http://localhost:6200/api/majorcategory/', {});
    })
    .service('itemCategoryService', function ($resource) {

        return $resource('http://localhost:6200/api/itemcategory/', {});
    })
    .service('brandGroceryService', function ($resource) {
        return $resource('http://localhost:6200/api/brandgrocery/', {});
    })
    .service('genericGroceryService', function ($resource) {
        return $resource('http://localhost:6200/api/genericgrocery/', {});
    })
    .controller('GroceryCtrl', ['$scope', 'brandGroceryService', 'genericGroceryService',
        function ($scope,  brandGroceryService, genericGroceryService) {

            $scope.brandGroceries = {};
            $scope.genericGroceries = {};

            brandGroceryService.query(function (response) {
                $scope.brandGroceries = response;
            });

            genericGroceryService.query(function (response) {
                $scope.genericGroceries = response;
            });

    }])
    .controller('CategoryCtrl', ['$scope', 'majorCategoryService', 'minorCategoryService', 'itemCategoryService',
        function ($scope, majorCategoryService, minorCategoryService, itemCategoryService) {

            $scope.majorCategories = {};
            $scope.minorCategories = {};
            $scope.itemCategories = {};

            majorCategoryService.query(function (response) {
                $scope.majorCategories = response;
            });

            minorCategoryService.query(function (response) {
                $scope.minorCategories = response;
            });

            itemCategoryService.query(function (response) {
                $scope.itemCategories = response;
            });
    }]);