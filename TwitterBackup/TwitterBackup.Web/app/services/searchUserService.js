var App;
(function (App) {
    var Services;
    (function (Services) {
        var SearchUserService = (function () {
            function SearchUserService($http, $q) {
                this.$http = $http;
                this.$q = $q;
            }
            SearchUserService.prototype.search = function (query) {
                var defer = this.$q.defer();
                this.$http.post('api/searchUser', { Query: query })
                    .success(defer.resolve)
                    .error(defer.reject);
                return defer.promise;
            };
            return SearchUserService;
        }());
        Services.SearchUserService = SearchUserService;
    })(Services = App.Services || (App.Services = {}));
})(App || (App = {}));
