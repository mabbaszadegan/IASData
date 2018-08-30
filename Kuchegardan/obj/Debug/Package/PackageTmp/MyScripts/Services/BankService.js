bankApp.service("BankService", function ($http) {

    this.getAllBank = function () {
        return $http.get(APIServicePath + "/Bank");
    };

    this.getBank = function (id) {
        return $http.get(APIServicePath + "/Bank/" + id);
    };

    this.addBank = function (bank) {
        var request = $http({
            method: "post",
            url: APIServicePath + "/Bank/",
            data: bank
        });

        return request;
    };

    this.editBank = function (id, bank) {
        var request = $http({
            method: "put",
            url: APIServicePath + "/Bank/" + id,
            data: bank
        });

        return request;
    };

    this.deleteBank = function (id) {
        var request = $http({
            method: "delete",
            url: APIServicePath + "/Bank/" + id

        });

        return request;

    }
    this.detailBank = function (id) {
        return $http.get(APIServicePath + "/Bank/" + id);
    };
});