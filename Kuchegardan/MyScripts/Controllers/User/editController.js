userApp.controller("editController", function ($scope, $location, UserService, ShareData) {

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

    $scope.save = function () {
        var user = {
            UserId: $scope.UserId,
            UserFirstName: $scope.UserFirstName,
            UserLastName: $scope.UserLastName,
            UserName: $scope.UserName,
            UserIsActive: $scope.UserIsActive,
            InsertTime: $scope.InsertTime,
            InsertUserId: $scope.InsertUserId
    }

        var result = UserService.edit(ShareData.value, user);

        result.then(function () {
            ShareData.value = 0;
            $location.path("/");
        });
    }
});