// Config routes
twitterBackupApp.config(function ($routeProvider) {
    $routeProvider
        .when("/user/favorites", {
        templateUrl: "/app/templates/favoriteUser.html",
        controller: "favoriteUserController"
    })
        .when('/user/search', {
        templateUrl: "/app/templates/searchUser.html",
        controller: "searchUserController"
    })
        .when('/status/timeline/:screenName', {
        templateUrl: '/app/templates/timeline.html',
        controller: 'timelineController'
    })
        .otherwise({
        redirectTo: '/user/favorites'
    });
});
//# sourceMappingURL=app.route.js.map