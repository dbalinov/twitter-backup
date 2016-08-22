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
                this.maxId = null;
                this.noMorePosts = false;
                this.userId = this.$routeParams["userId"];
                this.getNext();
            }
            TimelineController.prototype.getNext = function () {
                var _this = this;
                if (this.busy)
                    return;
                this.busy = true;
                var trimUser = !!this.user;
                if (this.noMorePosts) {
                    return;
                }
                this.$timelineService.getNext(this.userId, this.maxId, trimUser)
                    .then(function (data) {
                    if (data.User) {
                        _this.user = data.User;
                    }
                    var items = data.Statuses;
                    if (items.length > 0) {
                        for (var i = 0; i < items.length; i++) {
                            _this.items.push(items[i]);
                        }
                        _this.maxId = items[items.length - 1].Id;
                    }
                    else {
                        _this.noMorePosts = true;
                    }
                    _this.busy = false;
                });
            };
            return TimelineController;
        }(Controllers.BaseController));
        Controllers.TimelineController = TimelineController;
    })(Controllers = App.Controllers || (App.Controllers = {}));
})(App || (App = {}));
//# sourceMappingURL=timelineController.js.map