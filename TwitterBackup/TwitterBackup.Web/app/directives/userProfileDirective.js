var App;
(function (App) {
    var Directives;
    (function (Directives) {
        twitterBackupApp.directive("userProfile", ['$compile', function ($compile) {
                return {
                    restrict: "A",
                    replace: true,
                    templateUrl: "app/templates/directives/userProfile.html",
                    link: function (scope, element, attributes) {
                        attributes.$observe('userProfile', function (value) {
                            scope.user = scope.$eval(value);
                            // TODO: add/remove from favorites.
                        });
                    }
                };
            }]);
    })(Directives = App.Directives || (App.Directives = {}));
})(App || (App = {}));
