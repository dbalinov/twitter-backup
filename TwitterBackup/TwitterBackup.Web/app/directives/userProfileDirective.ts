module App.Directives {
    twitterBackupApp.directive("userProfile", [ "$compile", "$favoriteUserService", "$notificationService",
        ($compile: ng.ICompileService,
         $favoriteUserService: App.Services.FavoriteUserService,
         $notificationService: App.Services.NotificationService) => {
            return {
                restrict: "A",
                replace: true,
                templateUrl: "app/templates/directives/userProfile.html",
                scope: { user: "=userProfile" },
                controller: ($scope, $element) => {
                    $scope.addToFavorites = (user: User) => {
                        $favoriteUserService.addToFavorites(user)
                            .then(() => $notificationService.info(user.Name + " is added to favorites."));
                    };

                    $scope.removeFromFavorites = (user: User) => {
                        $favoriteUserService.removeFromFavorites(user)
                            .then(() => $notificationService.info(user.Name + " is remoevd from favorites."));
                    }
                }
            };
    }]);
}