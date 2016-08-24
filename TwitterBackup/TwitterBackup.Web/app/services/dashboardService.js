var App;
(function (App) {
    var Services;
    (function (Services) {
        var DashboardService = (function () {
            function DashboardService($http, $q) {
                this.$http = $http;
                this.$q = $q;
            }
            DashboardService.prototype.getData = function () {
                var defer = this.$q.defer();
                this.$http.get('api/dashboard')
                    .success(defer.resolve)
                    .error(defer.reject);
                return defer.promise;
            };
            return DashboardService;
        }());
        Services.DashboardService = DashboardService;
    })(Services = App.Services || (App.Services = {}));
})(App || (App = {}));
