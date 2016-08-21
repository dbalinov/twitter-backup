var App;
(function (App) {
    var Controllers;
    (function (Controllers) {
        var BaseController = (function () {
            function BaseController($scope) {
                this.$scope = $scope;
                $scope.model = this;
            }
            return BaseController;
        }());
        Controllers.BaseController = BaseController;
    })(Controllers = App.Controllers || (App.Controllers = {}));
})(App || (App = {}));
//# sourceMappingURL=baseController.js.map