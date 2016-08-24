module App.Directives {
    twitterBackupApp.directive("userProfile", ["$compile", "$location", "$favoriteUserService", "$notificationService",
        ($compile: ng.ICompileService,
         $location: ng.ILocationService,
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

                    $scope.openTimeline = (user: User) => {
                        if (user.IsFavorite) {
                            $location.path("/status/timeline/" + user.Id);
                        } else {
                            $notificationService.info("Please add user to favorites to view his statuses.");
                        }
                    }
                }
            };
    }]);
}