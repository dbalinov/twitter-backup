// Config routes
twitterBackupApp.config(function ($routeProvider) {
    $routeProvider
        //.when('/users/favorites', {
            
        //})
        //.when('/users/search', {
            
        //})
        .when('/statuses/timeline/:screenName', {
            templateUrl: '/scripts/app/timeline/timelineView.html',
            controller: 'timelineController'
        })
        //.when('/statuses/saved/:screenName', {

        //})
        //.when('/users/favorites', {

        //})
        .when('/friends', {
            templateUrl: '/scripts/app/friends/friendsView.html',
            controller: 'friendsController'
        })
        .otherwise({
            redirectTo: '/friends'
        });
});