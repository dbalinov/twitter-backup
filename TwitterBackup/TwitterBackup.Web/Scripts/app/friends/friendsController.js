function friendsController($scope, friendsService, notificationService) {
    "use strict";
    $scope.friends = [];
    
    $scope.filterTypes = {
        "favorites": 1,
        "friends": 2
    };

    $scope.filterType = $scope.filterTypes.favorites;

    $scope.addToFavorites = function (friend) {
        friendsService.addToFavorites(friend)
            .then(function() {
                notificationService.info(friend.Name + " is added to favorites.");
            });
    };

    $scope.removeFromFavorites = function (friend) {
        friendsService.removeFromFavorites(friend, false)
            .then(function () {
                notificationService.info(friend.Name + " is remoevd from favorites.");
            });
    };

    $scope.friendFilter = function (friend) {
        if ($scope.filterType === $scope.filterTypes.favorites) {
            return friend.IsFavorite;
        }

        return true;
    };

    friendsService.getFriends().then(function (friends) {
        $scope.friends = friends;
    }, function (error) {
        console.log(error);
    });
}