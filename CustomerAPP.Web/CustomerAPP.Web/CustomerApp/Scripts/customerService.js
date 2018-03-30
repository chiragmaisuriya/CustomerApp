(function (app) {
    var customerService = function ($http, customerApiUrl) {
        
        var getAll = function () {
            return $http.get(customerApiUrl + "GetAllCustomers");
        };

        var getById = function (id) {
            return $http.get( customerApiUrl +"GetCustomerById/"+ id);
        };

        var update = function (customer) {
            return $http.put(customerApiUrl + "UpdateCustomer", customer);
        };

        var create = function (customer) {
            console.log(JSON.stringify(customer));
            return $http.post(customerApiUrl + "CreateNewCustomer", customer);
        };

        var destroy = function (id) {
            return $http.delete( customerApiUrl + id);
        };

        return {
            getAll: getAll,
            getById: getById,
            update: update,
            create: create,
            delete: destroy
        };
    };
    app.factory("customerService", customerService);
}(angular.module("customerApp")));