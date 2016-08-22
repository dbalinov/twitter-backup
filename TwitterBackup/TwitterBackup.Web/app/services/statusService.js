var App;
(function (App) {
    var Services;
    (function (Services) {
        var StatusService = (function () {
            function StatusService($http, $q) {
                this.$http = $http;
                this.$q = $q;
            }
            StatusService.prototype.retweet = function (statusId) {
                var defer = this.$q.defer();
                this.$http.post('api/retweet/', { StatusId: statusId })
                    .success(defer.resolve)
                    .error(defer.reject);
                return defer.promise;
            };
            StatusService.prototype.save = function (statusId) {
                var defer = this.$q.defer();
                this.$http.post('api/statusStore/', { StatusId: statusId })
                    .success(defer.resolve)
                    .error(defer.reject);
                return defer.promise;
            };
            StatusService.prototype.unsave = function (statusId) {
                var defer = this.$q.defer();
                var url = 'api/statusStore/?statusId=' + statusId;
                this.$http.delete(url)
                    .success(defer.resolve)
                    .error(defer.reject);
                return defer.promise;
            };
            return StatusService;
        }());
        Services.StatusService = StatusService;
    })(Services = App.Services || (App.Services = {}));
})(App || (App = {}));
//# sourceMappingURL=statusService.js.map