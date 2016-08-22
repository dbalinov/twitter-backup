var App;
(function (App) {
    var Services;
    (function (Services) {
        var SavedStatusService = (function () {
            function SavedStatusService($http, $q) {
                this.$http = $http;
                this.$q = $q;
            }
            SavedStatusService.prototype.getNext = function (userId, maxId, trimUser) {
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
            return SavedStatusService;
        }());
        Services.SavedStatusService = SavedStatusService;
    })(Services = App.Services || (App.Services = {}));
})(App || (App = {}));
//# sourceMappingURL=savedStatusService.js.map