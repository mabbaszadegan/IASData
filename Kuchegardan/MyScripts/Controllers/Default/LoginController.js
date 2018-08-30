defaultApp.controller("loginController",
    function ($scope, $location, DefaultService, ShareData) {
        if (sessionStorage["userId"] !== undefined &&
            sessionStorage["userId"] != null &&
            sessionStorage["userId"] !== "0" &&
            sessionStorage["userId"] !== "null")
            $location.path("Default");


        $scope.checkAuthentication = function () {
            var user = {
                UserName: $scope.username,
                Password: $scope.password
            };

            var result = DefaultService.login(user);
            result.then(function (pl) {
                    if (pl.data.result.IsAccessible) {
                        sessionStorage["userId"] = pl.data.result.UserTempId;
                        sessionStorage["menu"] = pl.data.menuItems;
                        ShareData.menu = pl.data.menuItems;
                        
                        $location.path("Default");
                    }
                },
                function (error) {
                    $scope.error = 'ثبت با شکست مواجه شد', error;
                });
        }
    });