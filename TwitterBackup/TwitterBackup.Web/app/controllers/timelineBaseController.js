var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var App;
(function (App) {
    var Controllers;
    (function (Controllers) {
        var TimelineBaseController = (function (_super) {
            __extends(TimelineBaseController, _super);
            function TimelineBaseController($scope, $routeParams, $timelineService) {
                _super.call(this, $scope);
                this.$routeParams = $routeParams;
                this.$timelineService = $timelineService;
                this.items = [];
                this.busy = false;
                this.maxId = null;
                this.noMorePosts = false;
                this.userId = this.$routeParams["userId"];
            }
            TimelineBaseController.prototype.getNext = function () {
                var _this = this;
                if (this.busy || this.noMorePosts) {
                    return;
                }
                this.busy = true;
                var trimUser = !!this.user;
                this.$timelineService.getNext(this.userId, this.maxId, trimUser, this.savedOnly)
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
                    _this.busy = false;
                    _this.noMorePosts = items.length !== 5;
                });
            };
            return TimelineBaseController;
        }(Controllers.BaseController));
        Controllers.TimelineBaseController = TimelineBaseController;
    })(Controllers = App.Controllers || (App.Controllers = {}));
})(App || (App = {}));
