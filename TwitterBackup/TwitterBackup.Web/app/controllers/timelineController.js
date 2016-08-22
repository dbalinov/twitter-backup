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
            function TimelineController($scope, $routeParams, $timelineService, $notificationService) {
                _super.call(this, $scope);
                this.$routeParams = $routeParams;
                this.$timelineService = $timelineService;
                this.$notificationService = $notificationService;
                this.busy = false;
            }
            //var screenName = this.$routeParams["screenName"];
            //$scope.items = [];
            TimelineController.prototype.getNext = function () {
                if (this.busy)
                    return;
                this.busy = true;
                //this.$timelineService.getNext(screenName)
                //    .then(data => {
                //                if (data.User) {
                //                    $scope.user = data.User;
                //                }
                //                var items = data.Statuses;
                //                for (var i = 0; i < items.length; i++) {
                //                    $scope.items.push(items[i]);
                //                }
                //                $scope.busy = false;
                //            });
            };
            TimelineController.prototype.retweet = function (status) {
                var _this = this;
                if (!status.Retweeted) {
                    this.$timelineService.retweet(status.Id)
                        .then(function () {
                        status.Retweeted = true;
                        _this.$notificationService.info("The status has been retweeted.");
                    });
                }
                else {
                    this.$notificationService.info("The status is alredy retweeted.");
                }
            };
            TimelineController.prototype.save = function (status) {
                if (!status.IsSaved) {
                }
                else {
                }
            };
            return TimelineController;
        }(Controllers.BaseController));
        Controllers.TimelineController = TimelineController;
    })(Controllers = App.Controllers || (App.Controllers = {}));
})(App || (App = {}));
//# sourceMappingURL=timelineController.js.map