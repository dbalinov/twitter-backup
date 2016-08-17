function friendsController($scope, friendsService) {
    $scope.friends = [];

    friendsService.getFriends(function (friends) {
        $scope.friends = friends;
    });
}