(function (app) {
    var detailsController = function ($scope, $routeParams, customerService) {
        var id = $routeParams.id;
        customerService
            .getById(id)
            .then(function (response) {
                $scope.customer = response.data;
                $scope.customer.BirthDay = moment($scope.customer.BirthDay).format("MM-DD-YYYY");
            });

        $scope.edit = function () {
            $scope.edit.customer = angular.copy($scope.customer);
            $scope.edit.customer.BirthDay = new Date(moment($scope.customer.BirthDay).format("MM-DD-YYYY"));
        };


    };
    app.controller("detailsController", detailsController);
}(angular.module("customerApp")));