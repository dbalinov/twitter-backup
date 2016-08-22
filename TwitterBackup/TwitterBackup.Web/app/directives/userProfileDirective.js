var App;
(function (App) {
    var Directives;
    (function (Directives) {
        twitterBackupApp.directive("userProfile", [
            '$compile',
            '$favoriteUserService',
            '$notificationService',
            function ($compile, $favoriteUserService, $notificationService) {
                return {
                    restrict: "A",
                    replace: true,
                    templateUrl: "app/templates/directives/userProfile.html",
                    link: function (scope, element, attributes) {
                        // TODO: add/remove from favorites.
                        attributes.$observe('userProfile', function (value) {
                            scope.user = scope.$eval(value);
                        });
                    },
                    controller: function ($scope, $element) {
                        $scope.addToFavorites = function (user) {
                            $favoriteUserService.addToFavorites(user)
                                .then(function () { return $notificationService.info(user.Name + " is added to favorites."); });
                        };
                        $scope.removeFromFavorites = function (user) {
                            $favoriteUserService.removeFromFavorites(user)
                                .then(function () { return $notificationService.info(user.Name + " is remoevd from favorites."); });
                        };
                    }
                };
            }]);
    })(Directives = App.Directives || (App.Directives = {}));
})(App || (App = {}));
