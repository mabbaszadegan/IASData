var defaultApp = angular.module("DefaultApp", ["ngRoute"]);


defaultApp.factory("ShareData", function () {
    return { value: 0 }
});

angular.module('DefaultApp')
    .run(['$rootScope', '$location', '$routeParams', function ($rootScope, $location, $routeParams) {
        $rootScope.$on('$routeChangeSuccess', function (e, current, pre) {
            console.log('Current route name: ' + $location.path());
            // Get all URL parameter
            console.log($routeParams);
        });
    }]);
defaultApp.config(["$routeProvider", "$locationProvider", function($routeProvider, $locationProvider) {
    $routeProvider.when("/",
        {
            templateUrl: "Default/_Login",
            controller: "loginController"
        });
    $routeProvider.when("/Default",
        {
            templateUrl: "Default/_Home",
            controller: "defaultController"
        });

    $routeProvider.when("/Login",
        {
            templateUrl: "Default/_Login",
            controller: "loginController"
        });
    $routeProvider.otherwise(
        {
            templateUrl: "Default/_Home",
            controller: "defaultController"
        });
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });

}]);
