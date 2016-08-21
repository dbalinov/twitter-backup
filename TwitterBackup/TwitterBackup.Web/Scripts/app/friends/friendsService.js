function friendsService($http, $q) {
    "use strict";

    var self = this;

    self.getFriends = function () {
        var defer = $q.defer();

        $http.get('api/favoriteUser')
            .success(defer.resolve)
            .error(defer.reject);

        return defer.promise;
    };

    self.updateFavorite = function (friend, toAdd) {
        var defer = $q.defer();

        var data = {
            ScreenName: friend.ScreenName,
            Notifications: toAdd
        };

        $http.put('api/friendship', data)
            .success(function (response) {
                friend.Notifications = toAdd;
                defer.resolve(response);
            })
            .error(defer.reject);

        return defer.promise;
    };
}