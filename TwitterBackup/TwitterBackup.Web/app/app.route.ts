// Config routes
twitterBackupApp.config(($routeProvider: ng.route.IRouteProvider) => {
    $routeProvider
        .when("/user/favorites", {
            templateUrl: "/app/templates/favoriteUser.html",
            controller: "favoriteUserController"
        })
        .when('/user/search', {
            templateUrl: "/app/templates/searchUser.html",
            controller: "searchUserController"
        })
        .when('/status/timeline/:userId', {
            templateUrl: "/app/templates/timeline.html",
            controller: "timelineController"
        })
        .when('/status/saved/:userId', {
            templateUrl: "app/templates/savedStatus.html",
            controller: "savedStatusController"
        })
        .when('/dashboard', {
            templateUrl: "app/templates/dashboard.html",
            controller: "dashboardController"
        })
        .when('/unauthorized', {
            templateUrl: "app/templates/unauthorized.html"
        })
        .otherwise({
            redirectTo: '/user/favorites'
        });
});