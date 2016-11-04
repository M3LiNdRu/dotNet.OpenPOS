(function () {
    var app = angular.module("openPOS", []);

    app.controller("ProductsController", function () {


    });

    app.controller("OrdersController", function () {
        this.currentOrder = {
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
    });

})();