var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var App;
(function (App) {
    var Controllers;
    (function (Controllers) {
        var SavedStatusController = (function (_super) {
            __extends(SavedStatusController, _super);
            function SavedStatusController($scope, $routeParams, $timelineService) {
                _super.call(this, $scope, $routeParams, $timelineService);
                this.savedOnly = true;
            }
            return SavedStatusController;
        }(Controllers.TimelineBaseController));
        Controllers.SavedStatusController = SavedStatusController;
    })(Controllers = App.Controllers || (App.Controllers = {}));
})(App || (App = {}));
//# sourceMappingURL=savedStatusController.js.map