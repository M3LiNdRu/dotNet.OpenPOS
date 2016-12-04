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
            ctx.inventory = ctx.inventory.productFamilies[index];
        };

        ctx.refreshTopProducts();
        ctx.loadInventory();

    });

    app.controller("OrdersController", function ($http) {
        //TODO: Figure it out if there is another workaround
        var ctx = this;

        ctx.currentOrder = {
            reference: 0,
            name: 'NewOrder',
            products: [],
            total: 0,
        };
        ctx.ordersList = [];

        ctx.addProduct = function (product) {
            console.log("Added Product to Cart", product);            
            var result = $.grep(ctx.currentOrder.products, function (e) { return e.id == product.id; });
            if (result.length == 0) {
                var newproduct = { id: product.id, name: product.name, quantity: 1, price: product.price, tax: product.tax, base: product.basePrice };
                ctx.currentOrder.products.push(newproduct);
            }
            else {
                ctx.currentOrder.products.forEach(
                    function (item) {
                        if (item.id == product.id)
                        {
                            item.quantity++;                     
                        }                            
                });            
            }

            ctx.updateOrderTotals();
        }

        ctx.removeProduct = function (index) {
            console.log("Removed Product from Cart", index);
            ctx.currentOrder.products.splice(index, 1); 
            ctx.updateOrderTotals();
        }

        ctx.create = function () {
            console.log('Create Order', ctx.currentOrder);
            //var data = { reference: 0, name: "NewOrder", products: [{ id: 4, name: "ENTREPA TRUITA", quantity: 1, price: 3.5, base: 3 }], total: 3.5 };
            $http.post("api/orders", ctx.currentOrder)
                .then(function success(response) {
                    ctx.clear();
                    ctx.refreshOrdersList();
                }, function error(response) {
                    alert("Ups! Something happened" + response.data);
                });
        };

        ctx.update = function () {
            $http.put("api/orders", ctx.currentOrder)
                .then(function success(response) {
                    alert(response.data);
                }, function error(response) {
                    alert("Ups! Something happened" + response.data);
                });
        };

        ctx.clear = function () {
            ctx.currentOrder.products = [];
            ctx.currentOrder.total = 0;
            ctx.currentOrder.name = 'NewOrder';
            ctx.currentOrder.reference = 0;
        };

        ctx.updateOrderTotals = function () {
            var total = 0;

            ctx.currentOrder.products.forEach(function (item) {
                total += item.quantity * item.price;
            });

            ctx.currentOrder.total = total;
        };

        ctx.refreshOrdersList = function () {
            console.log("Refresh orders");
            var ul = angular.element(".orders-list-item");


            angular.forEach(ul, function (value, key) {
                var data = angular.element(value);
                data.remove();
            });

            //$http.get("api/orders")
            //    .then(function success(response) {
            //        ctx.ordersList = response.data;
            //        console.log("Orders list", ctx.ordersList);
            //    }, function error(response) {
            //        alert("Ups! Something happened" + response.data);
            //    });
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
            serverName: "http://",
            port: 1433,
            userName: "UserName",
            password: "Password",
            databaseName: "openPOS"
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