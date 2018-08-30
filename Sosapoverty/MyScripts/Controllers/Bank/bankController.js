bankApp.controller("bankController", function ($scope, $location, BankService, ShareData) {
    setAccess();

    function setAccess() {
        var accessList = BankService.getAllBank();

        accessList.then(function (res) {
            $scope.banks = res.data;
            $scope.AccessList = true;
            $scope.AccessCreate = false;
            $scope.AccessEdit = false;

        },
            function (error) { $scope.error = 'نمایش با شکست مواجه شد', error; });
    }


});