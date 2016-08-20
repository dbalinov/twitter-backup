function timelineService($http, $q) {
    "use strict";

    var self = this;

    self.getStatuses = function (screenName) {
        var defer = $q.defer();

        var url = 'api/status/?screenName=' + screenName;
        console.log(url);
        $http.get(url)
            .success(defer.resolve)
            .error(defer.reject);

        return defer.promise;
    };
}