var App;
(function (App) {
    var Directives;
    (function (Directives) {
        twitterBackupApp.directive("status", ["$compile", "$statusService", "$notificationService",
            function ($compile, $statusService, $notificationService) {
                return {
                    restrict: "A",
                    replace: true,
                    templateUrl: "app/templates/directives/status.html",
                    scope: { status: "=" },
                    controller: function ($scope, $element) {
                        $scope.retweet = function (status) {
                            if (!status.Retweeted) {
                                $statusService.retweet(status.Id)
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
                                $statusService.save(status.Id)
                                    .then(function () {
                                    status.IsSaved = true;
                                    $notificationService.info("The status has been saved.");
                                });
                            }
                            else {
                                $statusService.unsave(status.Id)
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
