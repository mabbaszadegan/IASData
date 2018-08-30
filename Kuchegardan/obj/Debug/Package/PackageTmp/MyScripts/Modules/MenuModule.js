var menuApp = angular.module("MenuApp", []);




menuApp.controller("menuController", function ($scope, $location, BankService) {
    loadMenu();

    function loadMenu() {
        var list = BankService.getAllBank();

        list.then(function (pl) { $scope.menues = pl.data; },
            function (error) { $scope.error = 'نمایش با شکست مواجه شد', error; });
    }


});


