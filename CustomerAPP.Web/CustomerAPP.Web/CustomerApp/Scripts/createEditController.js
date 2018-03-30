(function (app) {
    var createEditController = function ($scope, customerService) {


        $scope.isEditable = function () {
            return $scope.edit && $scope.edit.customer;
        };

        $scope.cancel = function () {
            $scope.edit.customer = null;
        };

        $scope.save = function () {
            if ($scope.edit.customer.Id) {
                updatecustomer();
            } else {
                createcustomer();
            }
        };
       
        var updatecustomer = function () {
            customerService.update($scope.edit.customer)
                .then(function () {
                    $scope.edit.customer.BirthDay = moment($scope.edit.customer.BirthDay).format("MM-DD-YYYY");
                    angular.extend($scope.customer, $scope.edit.customer);
                    $scope.edit.customer = null;
                });
        };

        var createcustomer = function () {
            customerService.create($scope.edit.customer)
                .then(function () {
                    $scope.getCustomers();
                    $scope.edit.customer = null;
                });
        };
    };
    app.controller("createEditController", createEditController);
}(angular.module("customerApp")));