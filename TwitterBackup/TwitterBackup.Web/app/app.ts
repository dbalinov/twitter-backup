var twitterBackupApp = angular.module('twitterbackup', [
    'ngRoute',
    'ngAnimate',
    'angular-loading-bar',
    'infinite-scroll'])

    // controllers
    .controller("baseController", App.Controllers.BaseController)
    .controller("favoriteUserController", App.Controllers.FavoriteUserController)
    .controller("timelineController", App.Controllers.TimelineController)
    .controller("searchUserController", App.Controllers.SearchUserController)

    // values
    .value("toastr", toastr)

    // services
    .factory("$notificationService", ["toastr", (toastr) => new App.Services.NotificationService(toastr)])
    .factory("$favoriteUserService", ["$http", "$q", ($http, $q) => new App.Services.FavoriteUserService($http, $q)])
    .factory("$searchUserService", ["$http", "$q",($http, $q) => new App.Services.SearchUserService($http, $q)])
    .factory("$timelineService", ["$http", "$q", ($http, $q) => new App.Services.TimelineService($http, $q)])
    
    // plugins config
    .config(['cfpLoadingBarProvider', (cfpLoadingBarProvider) => {
        cfpLoadingBarProvider.includeSpinner = false;
    }])

    // TODO: move to separate file
    .directive('tooltip', function tooltipDirective() {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                $(element).hover(
                    () => $(element).tooltip('show'),
                    () => $(element).tooltip('hide'));
            }
        };
    })

    .run($rootScope => {
        // Prevent two request at the same time by blocking the screen.
        $rootScope.$on('cfpLoadingBar:started', (evt, e, ee) => {
            $.blockUI({ message: null, overlayCSS: { opacity: 0 } });
        });
        $rootScope.$on('cfpLoadingBar:completed', (evt) => {
            $.unblockUI();
        });
    });