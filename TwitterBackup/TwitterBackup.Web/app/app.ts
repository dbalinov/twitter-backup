﻿var twitterBackupApp = angular.module('twitterbackup', [
    'ngRoute',
    'ngAnimate',
    'angular-loading-bar',
    'infinite-scroll'])

    // controllers
    .controller("baseController", App.Controllers.BaseController)
    .controller("favoriteUserController", App.Controllers.FavoriteUserController)
    .controller("timelineController", App.Controllers.TimelineController)
    .controller("searchUserController", App.Controllers.SearchUserController)
    .controller("dashboardController", App.Controllers.DashboardController)
    .controller("savedStatusController", App.Controllers.SavedStatusController)

    // values
    .value("toastr", toastr)

    // services
    .factory("$notificationService", ["toastr", (toastr) => new App.Services.NotificationService(toastr)])

    // data services
    .factory("$favoriteUserService", ["$http", "$q", ($http, $q) => new App.Services.FavoriteUserService($http, $q)])
    .factory("$searchUserService", ["$http", "$q",($http, $q) => new App.Services.SearchUserService($http, $q)])
    .factory("$statusService", ["$http", "$q", ($http, $q) => new App.Services.StatusService($http, $q)])
    .factory("$timelineService", ["$http", "$q", ($http, $q) => new App.Services.TimelineService($http, $q)])
    .factory("$savedStatusService", ["$http", "$q", ($http, $q) => new App.Services.SavedStatusService($http, $q)])

    // plugins config
    .config(['cfpLoadingBarProvider', (cfpLoadingBarProvider) => {
        cfpLoadingBarProvider.includeSpinner = false;
    }])

    .run($rootScope => {
        // Prevent two request at the same time by blocking the screen.
        $rootScope.$on('cfpLoadingBar:started', (evt, e, ee) => {
            $.blockUI({ message: null, overlayCSS: { opacity: 0 } });
        });
        $rootScope.$on('cfpLoadingBar:completed', (evt) => {
            $.unblockUI();
        });
    });