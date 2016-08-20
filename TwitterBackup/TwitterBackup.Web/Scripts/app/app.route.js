// Config routes
twitterBackupApp.config(function ($routeProvider) {
    $routeProvider
        .when('/friends', {
            templateUrl: '/scripts/app/friends/friendsView.html',
            controller: 'friendsController'
        })
        .when('/timeline/:screenName', {
            templateUrl: '/scripts/app/timeline/timelineView.html',
            controller: 'timelineController'
        })
        .otherwise({
            redirectTo: '/friends'
        });
});