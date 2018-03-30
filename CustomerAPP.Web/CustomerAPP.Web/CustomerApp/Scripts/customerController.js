(function (app) {
    var customerController = function ($scope, customerService, $log) {
        $scope.$log = $log;
       
        $scope.getCustomers = function () {
            customerService.getAll()
            .then(function (response){
                $scope.customers = response.data;
             },function (error) {
                $log.error(error);
            });}
            
        
        $scope.create = function () {
            $scope.edit = {
                customer: {
                    FirstName: "",
                    LastName: "",
                    BirthDay: new Date(moment(new Date()).format('MM-DD-YYYY')),
                    Address: ""
                }
            };
        };

        $scope.delete = function (customer) {
            customerService.delete(customer.Id)
                .then(function () {
                    $scope.getCustomers();
                });
        };
        $scope.init = function () {
            $scope.getCustomers();
        }
    };
    app.controller("customerController", customerController);
}(angular.module("customerApp")));
