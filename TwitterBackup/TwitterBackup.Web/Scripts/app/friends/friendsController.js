function friendsController($scope, friendsServices) {
    $scope.friends = [];

    $scope.message = friendsServices.getFriends();
}