
var bankApp = angular.module("BankApp", ["ngRoute"]);

angular.module('BankApp')
    .run(['$rootScope', '$location', '$routeParams', function ($rootScope, $location, $routeParams) {
        $rootScope.$on('$routeChangeSuccess', function (e, current, pre) {
            console.log('Current route name: ' + $location.path());
            // Get all URL parameter
            console.log($routeParams);
        });
    }]);

bankApp.factory("ShareData", function () {
    return { value: 0 }
});

bankApp.config(["$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider) {
 
    $routeProvider.when("/Bank", {
        templateUrl: "Admin/Bank/_List",
        controller: "listController"
    });

    $routeProvider.when("/List", {
        templateUrl: "Admin/Bank/_List",
        controller: "listController"
    });


    $routeProvider.when("/Create", {
        templateUrl: "Admin/Bank/_Create",
        controller: "addController"
    });


    $routeProvider.when("/Edit", {
        templateUrl: "Admin/Bank/_Edit",
        controller: "editController"
    });


    $routeProvider.when("/Delete", {
        templateUrl: "Admin/Bank/_Delete",
        controller: "deleteController"
    });

    $routeProvider.when("/Detail", {
        templateUrl: "Admin/Bank/_Detail",
        controller: "detailController"
    });

    $routeProvider.otherwise({
        redirectTo: "Admin/Bank"
    });

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
}]);

function MainCntl($scope, $location, $route) {
    $scope.location = $location.path(); // '/Home'
    $scope.routeName = $route.current.$$route.name; //'Main'
}
//var loginApp = angular.module('LoginApp', []);
//loginApp.controller("LoginController",
//    function ($scope, $http) {
//        $scope.checkAuthentication = function () {
//            if ($scope.username !== undefined && $scope.password !== undefined)
//                $http.get(APIServicePath + "AllowLogin").then(function (response) {
//                    $scope.users = response.data;
//                });
//            //$http({
//            //    url: APIServicePath + "AllowLogin",
//            //    method: "GET",
//            //    params: { username: $scope.username, password: $scope.password }
//            //});
//        }
//        $scope.new = function (id) {
//            alert(id);
//        }
//    });

//var bankApp = angular.module('BankApp', []);
//bankApp.controller("BankController",
//    function ($scope, $http) {
//        $('#mainContent').load('Bank/_List');
//        $http.get(APIServicePath + "Bank").then(function (response) {
//            $scope.banks = response.data;
//        });
//        $scope.create = function () {
//            $("#bankModal").modal('show');
//            $("#bankModalTitle").html('افزودن');
//            $("#bankModalBody").load("_Create");
//        }
//        $scope.edit = function () {
//            $("#bankModal").modal('show');
//            $("#bankModalTitle").html('ویرایش');
//            $("#bankModalBody").load("_Edit");
//        }
//        $scope.createBank = function () {
//            if ($scope.BankName !== "") {
//                var bank = {
//                    BankName: $scope.BankName,
//                    BankSummaryName: $scope.BankSummaryName,
//                    InsertUserId: 1
//                }
//                $http.post(APIServicePath + "Bank", bank).
//                    success(function (data, status, headers, config) {
//                    });
//            }
//        }
//        $scope.fillDetail = function (id) {
//            $http.get(APIServicePath + "Bank", id).then(function (response) {
//                $scope.bank = response.data;
//            });
//        }
//    });

