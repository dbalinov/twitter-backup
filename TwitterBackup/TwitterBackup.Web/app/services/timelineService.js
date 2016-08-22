var App;
(function (App) {
    var Services;
    (function (Services) {
        var TimelineService = (function () {
            function TimelineService($http, $q) {
                this.$http = $http;
                this.$q = $q;
            }
            TimelineService.prototype.getNext = function (userId, maxId, trimUser) {
                var defer = this.$q.defer();
                var url = "api/timeline?trimUser=" + trimUser +
                    "&userId=" + userId;
                if (maxId) {
                    url += "&maxId=" + maxId;
                }
                this.$http.get(url)
                    .success(defer.resolve)
                    .error(defer.reject);
                return defer.promise;
            };
            TimelineService.prototype.retweet = function (statusId) {
                var defer = this.$q.defer();
                this.$http.post('api/retweet/', { StatusId: statusId })
                    .success(defer.resolve)
                    .error(defer.reject);
                return defer.promise;
            };
            TimelineService.prototype.save = function (statusId) {
                var defer = this.$q.defer();
                this.$http.post('api/statusStore/', { StatusId: statusId })
                    .success(defer.resolve)
                    .error(defer.reject);
                return defer.promise;
            };
            TimelineService.prototype.unsave = function (statusId) {
                var defer = this.$q.defer();
                var url = 'api/statusStore/?statusId=' + statusId;
                this.$http.delete(url)
                    .success(defer.resolve)
                    .error(defer.reject);
                return defer.promise;
            };
            return TimelineService;
        }());
        Services.TimelineService = TimelineService;
    })(Services = App.Services || (App.Services = {}));
})(App || (App = {}));
