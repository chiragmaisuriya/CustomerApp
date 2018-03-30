(function (app) {
    var loginController = function ($scope, $rootScope, $location, authenticationService) {
        // reset login status
        authenticationService.ClearCredentials();

        $scope.login = function () {
            $scope.dataLoading = true;
            authenticationService.Login($scope.username,
                $scope.password,
                function (response) {
                    if (response.success) {
                        authenticationService.SetCredentials($scope.username, $scope.password);
                        $location.path("/list");
                    } else {
                        $scope.error = response.message;
                        $scope.dataLoading = false;
                    }
                });
        };
    };
    app.controller("loginController", loginController);
}(angular.module("customerApp")));