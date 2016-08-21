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
            function SearchUserController($scope //,
                ) {
                _super.call(this, $scope);
            }
            return SearchUserController;
        }(Controllers.BaseController));
        Controllers.SearchUserController = SearchUserController;
    })(Controllers = App.Controllers || (App.Controllers = {}));
})(App || (App = {}));
//# sourceMappingURL=searchUserController.js.map