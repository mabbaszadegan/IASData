userApp.service("UserService", function ($http) {

    this.getAll = function () {
        return $http.get(APIServicePath + "/User");
    };

    this.get = function (id) {
        return $http.get(APIServicePath + "/User/" + id);
    };

    this.add = function (user) {
        var request = $http({
            method: "post",
            url: APIServicePath + "/User/",
            data: user
        });

        return request;
    };

    this.edit = function (id, user) {
        var request = $http({
            method: "put",
            url: APIServicePath + "/User/" + id,
            data: user
        });

        return request;
    };

    this.delete = function (id) {
        var request = $http({
            method: "delete",
            url: APIServicePath + "/User/" + id

        });

        return request;

    }
    this.detail = function (id) {
        return $http.get(APIServicePath + "/User/" + id);
    };
});