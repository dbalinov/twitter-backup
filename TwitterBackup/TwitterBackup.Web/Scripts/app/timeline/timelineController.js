function timelineController($scope, $routeParams, timelineService) {
    "use strict";
    $scope.statuses = [];

    var screenName = $routeParams["screenName"];

    timelineService.getStatuses(screenName)
        .then(function (statuses) {
            $scope.statuses = statuses;
         });
};