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
                this.items = [];
                this.busy = false;
                this.userId = this.$routeParams["userId"];
                this.getNext();
            }
            TimelineController.prototype.getNext = function () {
                var _this = this;
                if (this.busy)
                    return;
                this.busy = true;
                var trimUser = !!this.user;
                this.$timelineService.getNext(this.userId, trimUser)
                    .then(function (data) {
                    if (data.User) {
                        _this.user = data.User;
                    }
                    var items = data.Statuses;
                    for (var i = 0; i < items.length; i++) {
                        _this.items.push(items[i]);
                    }
                    _this.busy = false;
                });
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
                var _this = this;
                if (!status.IsSaved) {
                    this.$timelineService.save(status.Id)
                        .then(function () {
                        status.IsSaved = true;
                        _this.$notificationService.info("The status has been saved.");
                    });
                }
                else {
                    this.$timelineService.unsave(status.Id)
                        .then(function () {
                        status.IsSaved = false;
                        _this.$notificationService.info("The status has been unsaved.");
                    });
                }
            };
            return TimelineController;
        }(Controllers.BaseController));
        Controllers.TimelineController = TimelineController;
    })(Controllers = App.Controllers || (App.Controllers = {}));
})(App || (App = {}));
//# sourceMappingURL=timelineController.js.map