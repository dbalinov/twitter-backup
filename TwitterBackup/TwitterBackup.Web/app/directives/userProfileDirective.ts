module App.Directives {

    twitterBackupApp.directive("userProfile", [
        '$compile',
        '$favoriteUserService',
        '$notificationService',
        function ($compile , $favoriteUserService, $notificationService: App.Services.NotificationService) {
        return {
            restrict: "A",
            replace: true,
            templateUrl: "app/templates/directives/userProfile.html",
            link: function (scope, element: ng.IAugmentedJQuery, attributes) {



                    // TODO: add/remove from favorites.
                attributes.$observe('userProfile', function (value) {
                    scope.user = scope.$eval(value);

                    

                });

       

            },
            controller: function ($scope, $element) {
                $scope.addToFavorites = function (user: User) {
                    $favoriteUserService.addToFavorites(user)
                        .then(() => $notificationService.info(user.Name + " is added to favorites."));
                };

                $scope.removeFromFavorites = function (user: User) {
                    $favoriteUserService.removeFromFavorites(user)
                        .then(() => $notificationService.info(user.Name + " is remoevd from favorites."));
                }
            }
        };
    }]);
}