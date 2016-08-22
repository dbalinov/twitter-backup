module App.Directives {
    twitterBackupApp.directive("status", ["$compile", "$timelineService", "$notificationService",
        ($compile: ng.ICompileService,
         $timelineService: App.Services.TimelineService,
         $notificationService: App.Services.NotificationService) => {
            return {
                restrict: "A",
                replace: true,
                templateUrl: "app/templates/directives/status.html",
                scope: { status: "=" },
                controller: ($scope, $element) => {
                    $scope.retweet = (status) => {
                        if (!status.Retweeted) {
                            $timelineService.retweet(status.Id)
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
                            $timelineService.save(status.Id)
                                .then(() => {
                                    status.IsSaved = true;
                                    $notificationService.info("The status has been saved.");
                                });
                        } else {
                            $timelineService.unsave(status.Id)
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