function friendsController($scope, friendsService) {
    "use strict";
    $scope.friends = [];
    
    $scope.filterTypes = {
        "favorites": 1,
        "friends": 2
    };

    $scope.filterType = $scope.filterTypes.favorites;

    $scope.addToFavorites = function (friend) {
        friendsService.updateFavorite(friend, true);
    };

    $scope.removeFromFavorites = function (friend) {
        friendsService.updateFavorite(friend, false);
    };

    $scope.friendFilter = function (friend) {
        if ($scope.filterType === $scope.filterTypes.favorites) {
            return friend.Notifications;
        }

        return true;
    };

    friendsService.getFriends(function (friends) {
        $scope.friends = friends;
    });
}