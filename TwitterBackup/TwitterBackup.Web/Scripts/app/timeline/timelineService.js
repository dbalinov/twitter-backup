function timelineService($http, $q) {
    "use strict";

    var self = this;

    self.maxId = null;
    self.trimUser = false;

    self.getNext = function(screenName) {
        var defer = $q.defer();

        var url = "api/timeline?trimUser=" + self.trimUser +
            "&screenName=" + screenName;
        if (self.maxId) {
            url += "&maxId=" + self.maxId;
        }

        $http.get(url)
            .success(function (data) {
                defer.resolve(data);
                var items = data.Statuses;
                self.maxId = items[items.length - 1].Id;
            })
            .error(defer.reject);

        self.trimUser = true;

        return defer.promise;
    };

    self.retweet = function(statusId) {
        var defer = $q.defer();

        $http.post('api/retweet/', { StatusId : statusId })
            .success(defer.resolve)
            .error(defer.reject);

        return defer.promise;
    };

    self.save = function (statusId) {
        var defer = $q.defer();

        $http.post('api/statusStore/', { StatusId: statusId })
            .success(defer.resolve)
            .error(defer.reject);

        return defer.promise;
    };

    self.unsave = function (statusId) {
        var defer = $q.defer();
        var url = 'api/statusStore/?statusId=' + statusId;
        $http.delete(url)
            .success(defer.resolve)
            .error(defer.reject);
        return defer.promise;
    };
}