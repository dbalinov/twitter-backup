var twitterBackupApp = angular.module('twitterbackup', [
    'ngRoute',
    'ngAnimate',
    'angular-loading-bar',
    'infinite-scroll'])
    .controller("baseController", App.Controllers.BaseController)
    .controller("favoriteUserController", App.Controllers.FavoriteUserController)
    .controller("timelineBaseController", App.Controllers.TimelineBaseController)
    .controller("timelineController", App.Controllers.TimelineController)
    .controller("savedStatusController", App.Controllers.SavedStatusController)
    .controller("searchUserController", App.Controllers.SearchUserController)
    .controller("dashboardController", App.Controllers.DashboardController)
    .value("toastr", toastr)
    .factory("$notificationService", ["toastr", function (toastr) { return new App.Services.NotificationService(toastr); }])
    .factory("$favoriteUserService", ["$http", "$q", function ($http, $q) { return new App.Services.FavoriteUserService($http, $q); }])
    .factory("$searchUserService", ["$http", "$q", function ($http, $q) { return new App.Services.SearchUserService($http, $q); }])
    .factory("$statusService", ["$http", "$q", function ($http, $q) { return new App.Services.StatusService($http, $q); }])
    .factory("$timelineService", ["$http", "$q", function ($http, $q) { return new App.Services.TimelineService($http, $q); }])
    .factory("$dashboardService", ["$http", "$q", function ($http, $q) { return new App.Services.DashboardService($http, $q); }])
    .config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
        cfpLoadingBarProvider.includeSpinner = false;
    }])
    .run(function ($rootScope) {
    // Prevent two request at the same time by blocking the screen.
    $rootScope.$on('cfpLoadingBar:started', function (evt, e, ee) {
        $.blockUI({ message: null, overlayCSS: { opacity: 0 } });
    });
    $rootScope.$on('cfpLoadingBar:completed', function (evt) {
        $.unblockUI();
    });
});
//# sourceMappingURL=app.js.map