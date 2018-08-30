defaultApp.controller("defaultController",
    function ($scope, $location, DefaultService, ShareData) {
        if (sessionStorage["userId"] === undefined ||
            sessionStorage["userId"] == null ||
            sessionStorage["userId"] === "0" ||
            sessionStorage["userId"] === "null")
            $location.path("Login");

    });