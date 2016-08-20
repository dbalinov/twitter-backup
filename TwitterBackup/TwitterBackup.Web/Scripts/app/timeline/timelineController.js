function timelineController($scope, $routeParams, timelineService, notificationService) {
    "use strict";

    var screenName = $routeParams["screenName"];

    $scope.items = [];
    $scope.busy = false;

    $scope.getNext = function () {
        if ($scope.busy) return;

        $scope.busy = true;

        timelineService.getNext1(screenName)
            .then(function (items) {
                for (var i = 0; i < items.length; i++) {
                    $scope.items.push(items[i]);
                }

                $scope.busy = false;
            });
    };

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

    $scope.save = function (status) {
        timelineService.unsave(status.Id)
            .then(function () {
               // status.Retweeted = true;
                notificationService.info("The status has been saved.");
            });
        console.log('save', status);
    };
};