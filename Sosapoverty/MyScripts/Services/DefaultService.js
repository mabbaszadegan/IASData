defaultApp.service("DefaultService", function ($http) {

    
    this.login = function (user) {
        var request = $http({
            method: "post",
            url: APIServicePath + "Access/",
            data: user
        });

        return request;
    };
    
    this.detail = function (id) {
        return $http.get(APIServicePath + "User/" + id);
    };
});