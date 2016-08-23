var App;
(function (App) {
    var Services;
    (function (Services) {
        var TimelineService = (function () {
            function TimelineService($http, $q) {
                this.$http = $http;
                this.$q = $q;
            }
            TimelineService.prototype.getNext = function (userId, maxId, trimUser, savedOnly) {
                var defer = this.$q.defer();
                var url = "api/timeline?trimUser=" + trimUser +
                    "&userId=" + userId +
                    "&savedOnly=" + savedOnly +
                    "&count=" + 5;
                if (maxId) {
                    url += "&maxId=" + maxId;
                }
                this.$http.get(url)
                    .success(defer.resolve)
                    .error(defer.reject);
                return defer.promise;
            };
            return TimelineService;
        }());
        Services.TimelineService = TimelineService;
    })(Services = App.Services || (App.Services = {}));
})(App || (App = {}));
//# sourceMappingURL=timelineService.js.map