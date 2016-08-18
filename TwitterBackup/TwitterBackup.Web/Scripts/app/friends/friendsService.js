function friendsService($http) {
    "use strict";

    var self = this;

    self.getFriends = function(callback) {
        $http.get('api/friends')
            .success(callback)
            .error(function (error) { console.log(error); });
    };

    self.updateFavorite = function(friend, toAdd) {
        $http.put('api/friends',
            {
                ScreenName: friend.ScreenName,
                Notifications: toAdd
            })
            .success(function() {
                console.log('success');
                friend.Notifications = toAdd;
            });
    };
}