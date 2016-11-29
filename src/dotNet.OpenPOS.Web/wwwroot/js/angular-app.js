(function () {
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
            Products: [ ],
            BaseTotal: 0,
            TaxTotal: 0,
            Total: 0
        };

        ctx.addProduct = function (product) {
            console.log("Added Product to Cart", product);            
            var result = $.grep(ctx.currentOrder.Products, function (e) { return e.Id == product.Id; });
            if (result.length == 0) {
                var newproduct = { Id: product.Id, Name: product.Name, Quantity: 1, Price: product.Price, Tax: product.Tax, Base: product.BasePrice };
                ctx.currentOrder.Products.push(newproduct);
            }
            else {
                ctx.currentOrder.Products.forEach(
                    function (item) {
                        if (item.Id == product.Id)
                        {
                            item.Quantity++;                     
                        }                            
                });            
            }

            ctx.updateOrderTotals();
        }

        ctx.removeProduct = function (index) {
            console.log("Removed Product from Cart", index);
            ctx.currentOrder.Products.splice(index, 1); 
            ctx.updateOrderTotals();
        }

        ctx.create = function () {
            $http.post("api/orders", ctx.currentOrder)
                .then(function success(response) {
                    alert(response.data);
                }, function error(response) {
                    alert(response.data);
                });
        };

        ctx.update = function () {
            $http.put("api/orders", ctx.currentOrder)
                .then(function success(response) {
                    alert(response.data);
                }, function error(response) {
                    alert(response.data);
                });
        };

        ctx.clear = function () {
            ctx.currentOrder.Products = [];
            ctx.currentOrder.BaseTotal = 0;
            ctx.currentOrder.TaxTotal = 0;
            ctx.currentOrder.Total = 0;
        };

        ctx.updateOrderTotals = function () {
            var total = 0;
            var tax = 0;
            var base = 0;

            ctx.currentOrder.Products.forEach(function (item) {
                total += item.Quantity * item.Price;
                base += item.Quantity * item.Base;
                tax += item.Quantity * item.Tax;
            });

            ctx.currentOrder.Total = total;
            ctx.currentOrder.TaxTotal = tax;
            ctx.currentOrder.BaseTotal = base;
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