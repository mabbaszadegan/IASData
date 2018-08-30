bankApp.controller("editController", function ($scope, $location, BankService, ShareData) {

    var bank = BankService.getBank(ShareData.value);

    bank.then(function (res) {
        $scope.BankId = res.data.BankId;
        $scope.BankName = res.data.BankName;
        $scope.BankSummaryName = res.data.BankSummaryName;
    });

    $scope.edit = function () {
        var bank = {
            BankId: $scope.BankId,
            BankName: $scope.BankName,
            BankSummaryName: $scope.BankSummaryName
        }

        var result = BankService.editBank(ShareData.value, bank);

        result.then(function () {
            ShareData.value = 0;
            $location.path("/");
        });
    }
});