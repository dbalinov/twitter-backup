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
            function FavoriteUserController($scope, $favoriteUserService) {
                var _this = this;
                _super.call(this, $scope);
                this.$favoriteUserService = $favoriteUserService;
                this.users = new Array();
                this.loaded = false;
                $favoriteUserService.getUsers()
                    .then(function (users) {
                    _this.users = users;
                    _this.loaded = true;
                }, function (error) { return console.log(error); });
            }
            return FavoriteUserController;
        }(Controllers.BaseController));
        Controllers.FavoriteUserController = FavoriteUserController;
    })(Controllers = App.Controllers || (App.Controllers = {}));
})(App || (App = {}));
//# sourceMappingURL=favoriteUserController.js.map