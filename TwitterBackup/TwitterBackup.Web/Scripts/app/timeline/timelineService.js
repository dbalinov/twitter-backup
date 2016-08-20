function timelineService($http, $q) {
    "use strict";

    var self = this;

    self.getStatuses = function (screenName) {
        var defer = $q.defer();

        var url = 'api/status/?screenName=' + screenName;

        $http.get(url)
            .success(defer.resolve)
            .error(defer.reject);

        return defer.promise;
    };

    self.retweet = function(statusId) {
        var defer = $q.defer();

        $http.post('api/retweet/', { StatusId : statusId })
            .success(defer.resolve)
            .error(defer.reject);

        return defer.promise;
    };
}