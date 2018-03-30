(function () {
    var app = angular.module("customerApp", ["ngRoute", "ngCookies"]);
    var config = function ($routeProvider, $locationProvider) {
        $locationProvider.hashPrefix('');
        $routeProvider
            .when("/login",
                { templateUrl: "/CustomerApp/Views/login.html", controller: "loginController" })
            .when("/list",
                { templateUrl: "/CustomerApp/Views/list.html", controller: "customerController" })
            .when("/details/:id",
                { templateUrl: "/CustomerApp/Views/details.html", controller: "detailsController" })
            .otherwise({ redirectTo: "/login" });
    };

    var run = function($rootScope, $location, $cookieStore, $http) {
        // keep user logged in after page refresh
        $rootScope.globals = $cookieStore.get('globals') || {};
        if ($rootScope.globals.currentUser) {
            $http.defaults.headers.common['Authorization'] =
                'Basic ' + $rootScope.globals.currentUser.authdata; // jshint ignore:line
        }

        $rootScope.$on('$locationChangeStart',
            function(event, next, current) {
                // redirect to login page if not logged in
                if ($location.path() !== '/login' && !$rootScope.globals.currentUser) {
                    $location.path('/login');
                }
            });
    };

    app.config(config);
    app.constant("customerApiUrl", "/api/customer/");
    app.run(run);
}());


