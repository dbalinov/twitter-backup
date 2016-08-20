function timelineService($http, $q) {
    "use strict";

    var self = this;

    //self.after = '';

    self.maxId = null;

    self.getNext1 = function(screenName) {
        var defer = $q.defer();

        var url = "api/timeline?trimUser=true&screenName=" + screenName;
        if (self.maxId) {
            url += "&maxId=" + self.maxId;
        }

        $http.get(url)
            .success(function (data) {
                var items = data.Statuses;
                defer.resolve(items);
                self.maxId = items[items.length - 1].Id;
            })
            .error(defer.reject);

        return defer.promise;
    };

    //self.getNext = function () {
    //    var defer = $q.defer();
       
    //    var url = "https://api.reddit.com/hot?after=" + self.after + "&jsonp=JSON_CALLBACK";

    //    $http.jsonp(url)
    //        .success(function (data) {
    //            var items = data.data.children;
    //            defer.resolve(items);
    //            self.after = "t3_" + items[items.length - 1].id;
    //        })
    //        .error(defer.reject);

    //    return defer.promise;

    //};

    //self.getStatuses = function (screenName) {
    //    var defer = $q.defer();

    //    var url = 'api/status/?screenName=' + screenName;

    //    $http.get(url)
    //        .success(defer.resolve)
    //        .error(defer.reject);

    //    return defer.promise;
    //};

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

        $http.delete('api/statusStore/', { StatusId: statusId })
            .success(defer.resolve)
            .error(defer.reject);
        return defer.promise;
    };
}