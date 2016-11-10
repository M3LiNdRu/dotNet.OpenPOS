(function () {
    var app = angular.module("openPOS", []);

    app.controller("ProductsController", function () {
        var ctx = this;

        ctx.randomNumber = Math.floor((Math.random() * 100) + 1);

        ctx.refreshTopProducts = function () {
            ctx.randomNumber = Math.floor((Math.random() * 100) + 1);
        };

        setInterval(ctx.refreshTopProducts, 5000)

    });

    app.controller("OrdersController", function ($http) {
        //TODO: Figure it out if there is another workaround
        var ctx = this;

        ctx.currentOrder = {
            Name: 'NewOrder',
            Reference: 'NewOrder-00',
            Products: [
                { Id: 0, Name: "Coca Cola", Quantity: 1, Price: 1.10 },
                { Id: 3, Name: "Pipes Bossa", Quantity: 1, Price: 1.10 },
                { Id: 5, Name: "CERVESA MORITZ", Quantity: 1, Price: 1.30 }
            ],
            BaseTotal: 2.75,
            TaxTotal: 0.25,
            Total: 3
        };

        ctx.createOrder = function () {
            $http.post("api/orders", ctx.currentOrder)
                .then(function success(response) {
                    alert(response.data);
                }, function error(response) {
                    alert(response.data);
                });
        };
    });

    app.controller("AboutController", function ($http) {
        //TODO: Figure it out if there is another workaround
        var ctx = this;

        ctx.aboutInfo = {};

        ctx.getAboutInfo = $http.get("Home/About").then(function (response) {
            ctx.aboutInfo = response.data;
        });
    });

})();