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
        .when('/status/timeline/:screenName', {
            templateUrl: "/app/templates/timeline.html",
            controller: "timelineController"
        })
        //.when('/status/saved/:screenName', {

        //})
        //.when('/friends', {
        //    templateUrl: '/scripts/app/friends/friendsView.html',
        //    controller: 'friendsController'
        //})
        .otherwise({
            redirectTo: '/user/favorites'
        });
});