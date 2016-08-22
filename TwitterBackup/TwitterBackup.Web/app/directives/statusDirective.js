var App;
(function (App) {
    var Directives;
    (function (Directives) {
        twitterBackupApp.directive("status", ["$compile", "$timelineService", "$notificationService",
            function ($compile, $timelineService, $notificationService) {
                return {
                    restrict: "A",
                    replace: true,
                    templateUrl: "app/templates/directives/status.html",
                    scope: { status: "=" },
                    controller: function ($scope, $element) {
                        $scope.retweet = function (status) {
                            if (!status.Retweeted) {
                                $timelineService.retweet(status.Id)
                                    .then(function () {
                                    status.Retweeted = true;
                                    $notificationService.info("The status has been retweeted.");
                                });
                            }
                            else {
                                $notificationService.info("The status is alredy retweeted.");
                            }
                        };
                        $scope.save = function (status) {
                            if (!status.IsSaved) {
                                $timelineService.save(status.Id)
                                    .then(function () {
                                    status.IsSaved = true;
                                    $notificationService.info("The status has been saved.");
                                });
                            }
                            else {
                                $timelineService.unsave(status.Id)
                                    .then(function () {
                                    status.IsSaved = false;
                                    $notificationService.info("The status has been unsaved.");
                                });
                            }
                        };
                    }
                };
            }
        ]);
    })(Directives = App.Directives || (App.Directives = {}));
})(App || (App = {}));
