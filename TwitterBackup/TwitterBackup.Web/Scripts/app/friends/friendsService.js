function friendsService($http) {
    "use strict";

    var self = this;

    self.getFriends = function(callback) {
        $http.get('api/friends')
            .success(callback)
            .error(function (error) { console.log(error); });
    };
}