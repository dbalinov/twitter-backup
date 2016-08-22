module App.Directives {
    twitterBackupApp.directive("status", ["$compile", "$statusService", "$notificationService",
        ($compile: ng.ICompileService,
         $statusService: App.Services.StatusService,
         $notificationService: App.Services.NotificationService) => {
            return {
                restrict: "A",
                replace: true,
                templateUrl: "app/templates/directives/status.html",
                scope: { status: "=" },
                controller: ($scope, $element) => {
                    $scope.retweet = (status) => {
                        if (!status.Retweeted) {
                            $statusService.retweet(status.Id)
                                .then(() => {
                                    status.Retweeted = true;
                                    $notificationService.info("The status has been retweeted.");
                                });
                        } else {
                            $notificationService.info("The status is alredy retweeted.");
                        }
                    }

                    $scope.save = (status) => {
                        if (!status.IsSaved) {
                            $statusService.save(status.Id)
                                .then(() => {
                                    status.IsSaved = true;
                                    $notificationService.info("The status has been saved.");
                                });
                        } else {
                            $statusService.unsave(status.Id)
                                .then(() => {
                                    status.IsSaved = false;
                                    $notificationService.info("The status has been unsaved.");
                                });
                        }
                    }
                }
            };
        }
    ]);
}