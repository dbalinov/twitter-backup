var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var App;
(function (App) {
    var Controllers;
    (function (Controllers) {
        var TimelineController = (function (_super) {
            __extends(TimelineController, _super);
            function TimelineController($scope, $routeParams, $timelineService) {
                _super.call(this, $scope, $routeParams, $timelineService);
                this.savedOnly = false;
            }
            return TimelineController;
        }(Controllers.TimelineBaseController));
        Controllers.TimelineController = TimelineController;
    })(Controllers = App.Controllers || (App.Controllers = {}));
})(App || (App = {}));
//# sourceMappingURL=timelineController.js.map