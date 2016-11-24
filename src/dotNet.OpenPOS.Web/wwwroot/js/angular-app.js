﻿(function () {
    var app = angular.module("openPOS", []).config(function ($locationProvider) {
        $locationProvider.html5Mode(true);
    });
    
    app.controller("ProductsController", function () {
        var ctx = this;

        ctx.inventories = [];
        ctx.inventory = {};
        ctx.randomNumber = Math.floor((Math.random() * 100) + 1);
        
        ctx.loadInventory = function () {
            var target = document.getElementById('inventory-data');
            var fullInventory = target.attributes['data-content'].value;
            ctx.inventory = JSON.parse(fullInventory);
            console.log(ctx.inventory);
        };

        ctx.refreshTopProducts = function () {
            ctx.randomNumber = Math.floor((Math.random() * 100) + 1);
            setInterval(ctx.refreshTopProducts, 5000)
        };

        ctx.backproductFamily = function () {
            ctx.inventory = ctx.inventories.pop();
        }

        ctx.loadProductFamily = function (index) {
            ctx.inventories.push(ctx.inventory);
            ctx.inventory = ctx.inventory.ProductFamilies[index];
        };

        ctx.refreshTopProducts();
        ctx.loadInventory();

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

        ctx.addProduct = function (product) {
            console.log("Added Product to Cart", product);
        }

        ctx.create = function () {
            $http.post("api/orders", ctx.currentOrder)
                .then(function success(response) {
                    alert(response.data);
                }, function error(response) {
                    alert(response.data);
                });
        };

        ctx.clear = function () {
            ctx.currentOrder.Products = {};
            ctx.currentOrder.BaseTotal = 0;
            ctx.currentOrder.TaxTotal = 0;
            ctx.currentOrder.Total = 0;
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

    app.controller('InitialConfigController', function($location) {
        //TODO: Figure it out if there is another workaround
        var ctx = this;

        ctx.dbConfig = {
            ServerName: "http://",
            Port: 1433,
            UserName: "UserName",
            Password: "Password",
            DatabaseName: "openPOS"
        };

        ctx.addDbConfigResponse = false;

        ctx.testConfig = function () {
            console.log(ctx.dbConfig);
        };

        ctx.addDbConfig = function () {
            console.log(ctx.dbConfig);
            //$http.post("api/InitialConfigurationController/dbconfiguration").then(function (response) {
            //    ctx.addDbConfigResponse = response.data;
            //});
        };

        ctx.goMainPage = function() {
            $location.href("/Home");
        };
    });

})();