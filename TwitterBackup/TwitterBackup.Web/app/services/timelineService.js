var App;
(function (App) {
    var Services;
    (function (Services) {
        var TimelineService = (function () {
            function TimelineService($http, $q) {
                this.$http = $http;
                this.$q = $q;
                this.maxId = null;
                this.trimUser = false;
                this.noMorePosts = false;
            }
            TimelineService.prototype.getNext = function (screenName) {
                var _this = this;
                var defer = this.$q.defer();
                if (this.noMorePosts) {
                    defer.resolve({ Statuses: [] });
                }
                else {
                    var url = "api/timeline?trimUser=" + this.trimUser +
                        "&screenName=" + screenName;
                    if (this.maxId) {
                        url += "&maxId=" + this.maxId;
                    }
                    this.$http.get(url)
                        .success(function (data) {
                        defer.resolve(data);
                        var items = data.Statuses;
                        if (items.length > 0) {
                            _this.maxId = items[items.length - 1].Id;
                        }
                        else {
                            _this.noMorePosts = true;
                        }
                    })
                        .error(defer.reject);
                    this.trimUser = true;
                }
                return defer.promise;
            };
            TimelineService.prototype.retweet = function (statusId) {
                var defer = this.$q.defer();
                this.$http.post('api/retweet/', { StatusId: statusId })
                    .success(defer.resolve)
                    .error(defer.reject);
                return defer.promise;
            };
            return TimelineService;
        }());
        Services.TimelineService = TimelineService;
    })(Services = App.Services || (App.Services = {}));
})(App || (App = {}));
