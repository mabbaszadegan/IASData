userApp.controller("addController", function ($scope, UserService) {


    $scope.ID = 0;

    $scope.save = function () {
        var user = {
            UserId: $scope.UserId,
            UserFirstName: $scope.UserFirstName,
            UserLastName: $scope.UserLastName,
            UserName: $scope.UserName,
            UserPassword: $scope.UserPassword,
            UserIsActive: $scope.UserIsActive
        };

        var result = UserService.add(user);

        result.then(function (pl) {
            $scope.UserId = pl.data.UserId;
            alert('Person ID : ' + pl.data.UserId);
        },
            function (error) {
                $scope.error = 'ثبت با شکست مواجه شد', error;
            });

    }

});