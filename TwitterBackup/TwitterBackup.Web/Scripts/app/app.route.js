// Config routes
twitterBackupApp.config(function ($routeProvider) {
    $routeProvider
        .when('/friends', {
            templateUrl: '/scripts/app/friends/friendsView.html',
            controller: 'friendsController'
        })
//    .when('/timeline/:id', {
//    })
        .otherwise({
            redirectTo: '/friends'
        });
});