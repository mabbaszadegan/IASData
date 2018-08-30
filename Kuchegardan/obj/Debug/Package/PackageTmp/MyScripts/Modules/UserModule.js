var userApp = angular.module("UserApp", ["ngRoute"]);


userApp.factory("ShareData", function () {
    return { value: 0 }
});


userApp.config(["$routeProvider", "$locationProvider", function($routeProvider, $locationProvider) {

    $routeProvider.when("/User/Index", {
        templateUrl: "Admin/User/_List",
        controller: "listController"
    });

    $routeProvider.when("/List", {
        templateUrl: "Admin/User/_List",
        controller: "listController"
    });


    $routeProvider.when("/Create", {
        templateUrl: "Admin/User/_Create",
        controller: "addController"
    });


    $routeProvider.when("/Edit", {
        templateUrl: "Admin/User/_Edit",
        controller: "editController"
    });


    $routeProvider.when("/Delete", {
        templateUrl: "Admin/User/_Delete",
        controller: "deleteController"
    });

    $routeProvider.when("/Detail", {
        templateUrl: "Admin/User/_Detail",
        controller: "detailController"
    });

    $routeProvider.otherwise({
        redirectTo: "Admin/User/Index"
    });


    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });

}]);
