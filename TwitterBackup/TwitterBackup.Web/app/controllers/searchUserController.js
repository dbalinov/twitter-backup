var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var App;
(function (App) {
    var Controllers;
    (function (Controllers) {
        var SearchUserController = (function (_super) {
            __extends(SearchUserController, _super);
            function SearchUserController($scope, $searchUserService) {
                _super.call(this, $scope);
                this.$searchUserService = $searchUserService;
                this.users = Array();
            }
            SearchUserController.prototype.search = function () {
                var _this = this;
                this.$searchUserService.search(this.query)
                    .then(function (users) { return _this.users = users; });
            };
            return SearchUserController;
        }(Controllers.BaseController));
        Controllers.SearchUserController = SearchUserController;
    })(Controllers = App.Controllers || (App.Controllers = {}));
})(App || (App = {}));
