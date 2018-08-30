userApp.controller("listController", function ($scope, $location, UserService, ShareData) {
    loadAll();

    function loadAll() {
        var list = UserService.getAll();

        list.then(function (pl) { $scope.users = pl.data; },
            function (error) { $scope.error = 'نمایش با شکست مواجه شد', error; });
    }


    $scope.add = function () {
        $location.path("/Create");
    };

    $scope.edit = function (id) {
        ShareData.value = id;
        $location.path("/Edit");
    };

    $scope.delete = function (id) {
        ShareData.value = id;
        $location.path("/Delete");
    };
    $scope.detail = function (id) {
        ShareData.value = id;
        $location.path("/Detail");
    };
});