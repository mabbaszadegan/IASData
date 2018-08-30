bankApp.controller("listController", function ($scope, $location, BankService, ShareData) {
    loadAll();

    function loadAll() {
        var list = BankService.getAllBank();

        list.then(function (pl) {
            $scope.banks = pl.data;
            $scope.AccessList = true;
            $scope.AccessCreate = false;
            $scope.AccessEdit = false;

        },
            function (error) { $scope.error = 'نمایش با شکست مواجه شد', error; });
    }


    $scope.addBank = function () {
        $location.path("/Create");
    };

    $scope.editBank = function (id) {
        ShareData.value = id;
        $location.path("/Edit");
    };

    $scope.deleteBank = function (id) {
        ShareData.value = id;
        $location.path("/Delete");
    };
    $scope.detailBank = function (id) {
        ShareData.value = id;
        $location.path("/Detail");
    };
});