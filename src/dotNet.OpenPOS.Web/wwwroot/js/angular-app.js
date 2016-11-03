(function () {
    var app = angular.module("openPOS", []);

    app.controller("ProductsController", function ($scope, $http) {

        // Get products asynchronously
        //$http.get("api/products").then(
        //    function mySucces(response) {
        //        $scope.products = response.data;
        //    },
        //    function myError(response) {
        //        $scope.myWelcome = response.statusText;
        //    }
        //);

    });

    app.controller("OrdersController", function () {
        this.currentOrder = {
            Name: 'NewOrder',
            Reference: 'NewOrder-00',
            Products: [],
            BaseTotal: 0,
            TaxTotal: 0,
            Total: 0
        };
    });

})();