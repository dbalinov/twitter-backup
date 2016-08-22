var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var App;
(function (App) {
    var Controllers;
    (function (Controllers) {
        var DashboardController = (function (_super) {
            __extends(DashboardController, _super);
            function DashboardController($scope //,
                ) {
                _super.call(this, $scope);
            }
            return DashboardController;
        }(Controllers.BaseController));
        Controllers.DashboardController = DashboardController;
    })(Controllers = App.Controllers || (App.Controllers = {}));
})(App || (App = {}));
//# sourceMappingURL=dashboardController.js.map