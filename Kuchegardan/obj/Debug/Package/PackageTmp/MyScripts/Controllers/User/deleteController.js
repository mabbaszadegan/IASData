userApp.controller("deleteController", function ($scope, $location, ShareData, UserService) {

    var user = UserService.get(ShareData.value);

    user.then(function (res) {
        $scope.UserId = res.data.UserId;
        $scope.UserFirstName = res.data.UserFirstName;
        $scope.UserLastName = res.data.UserLastName;
        $scope.UserName = res.data.UserName;
        $scope.UserIsActive = res.data.UserIsActive;
        $scope.InsertTime = res.data.InsertTime;
        $scope.InsertUserId = res.data.InsertUserId;
        $scope.UpdateTime = res.data.UpdateTime;
        $scope.UpdateUserId = res.data.UpdateUserId;
    });


    $scope.delete = function () {
        var result = UserService.delete(ShareData.value);


        result.then(function (pl) {
            $location.path("/list");

        }, function (error) {
            $scope.error = error;
        });
    };

    $scope.return = function () {
        $location.path("/list");
    };


});