// Config routes
twitterBackupApp.config(function ($routeProvider) {
    $routeProvider
        .when('/friends', {
            templateUrl: '/scripts/app/friends/friendsView.html',
            controller: 'friendsController'
        })
//    .when('/GeofenceGroup/:id?', {
//        templateUrl: '/scripts/app/views/GeofenceGroup/Edit.html',
//        controller: 'GeofenceGroupController'
//    })
        .otherwise({
            redirectTo: '/friends'
        });
});