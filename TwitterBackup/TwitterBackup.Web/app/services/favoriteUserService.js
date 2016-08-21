var App;
(function (App) {
    var Services;
    (function (Services) {
        var FavoriteUserService = (function () {
            function FavoriteUserService($http, $q) {
                this.$http = $http;
                this.$q = $q;
            }
            FavoriteUserService.prototype.getUsers = function () {
                var defer = this.$q.defer();
                this.$http.get('api/favoriteUser')
                    .success(defer.resolve)
                    .error(defer.reject);
                return defer.promise;
            };
            FavoriteUserService.prototype.addToFavorites = function (friend) {
                var defer = this.$q.defer();
                var data = { UserId: friend.Id };
                this.$http.put('api/favoriteUser', data)
                    .success(function (response) {
                    friend.IsSaved = true;
                    defer.resolve(response);
                })
                    .error(defer.reject);
                return defer.promise;
            };
            FavoriteUserService.prototype.removeFromFavorites = function (friend) {
                var defer = this.$q.defer();
                this.$http.delete('api/friendship?userId=' + friend.Id)
                    .success(function (response) {
                    friend.IsSaved = false;
                    defer.resolve(response);
                })
                    .error(defer.reject);
                return defer.promise;
            };
            return FavoriteUserService;
        }());
        Services.FavoriteUserService = FavoriteUserService;
    })(Services = App.Services || (App.Services = {}));
})(App || (App = {}));
//# sourceMappingURL=favoriteUserService.js.map