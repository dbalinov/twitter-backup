function timelineController($scope, $routeParams, timelineService, notificationService) {
    "use strict";
    $scope.statuses = [];

    var screenName = $routeParams["screenName"];

    timelineService.getStatuses(screenName)
        .then(function (statuses) {
            $scope.statuses = statuses;
        });

    $scope.retweet = function (status) {
        if (!status.Retweeted) {
            timelineService.retweet(status.Id)
                .then(function () {
                    status.Retweeted = true;
                    notificationService.info("The status has been retweeted.");
                });
        } else {
            notificationService.info("The status is alredy retweeted.");
        }
    };

    //$scope.favorite = function (status) {
    //    console.log('favorite', status);
    //};

    $scope.save = function (status) {
        console.log('save', status);
    };
};