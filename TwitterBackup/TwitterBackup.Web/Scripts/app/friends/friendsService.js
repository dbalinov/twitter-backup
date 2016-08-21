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

    self.addToFavorites = function (friend) {
        var defer = $q.defer();

        var data = { UserId: friend.Id };

        $http.put('api/favoriteUser', data)
            .success(function(response) {
                friend.IsSaved = true;
                defer.resolve(response);
            })
            .error(defer.reject);
      
        return defer.promise;
    };


    self.removeFromFavorites = function (friend) {
        var defer = $q.defer();

        $http.delete('api/friendship?userId=' + friend.Id)
            .success(function (response) {
                friend.IsSaved = false;
                defer.resolve(response);
            })
            .error(defer.reject);

        return defer.promise;
    };
}