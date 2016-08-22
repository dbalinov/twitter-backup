var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var App;
(function (App) {
    var Controllers;
    (function (Controllers) {
        var FavoriteUserController = (function (_super) {
            __extends(FavoriteUserController, _super);
            function FavoriteUserController($scope, $favoriteUserService, $notificationService) {
                var _this = this;
                _super.call(this, $scope);
                this.$favoriteUserService = $favoriteUserService;
                this.$notificationService = $notificationService;
                this.users = new Array();
                $favoriteUserService.getUsers()
                    .then(function (users) { return _this.users = users; }, function (error) { return console.log(error); });
            }
            FavoriteUserController.prototype.addToFavorites = function (user) {
                var _this = this;
                this.$favoriteUserService.addToFavorites(user)
                    .then(function () { return _this.$notificationService.info(user.Name + " is added to favorites."); });
            };
            FavoriteUserController.prototype.removeFromFavorites = function (user) {
                var _this = this;
                this.$favoriteUserService.removeFromFavorites(user)
                    .then(function () { return _this.$notificationService.info(user.Name + " is remoevd from favorites."); });
            };
            return FavoriteUserController;
        }(Controllers.BaseController));
        Controllers.FavoriteUserController = FavoriteUserController;
    })(Controllers = App.Controllers || (App.Controllers = {}));
})(App || (App = {}));
