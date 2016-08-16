var twitterBackupApp = angular.module("twitterbackup", []) // ['ngRoute', 'angular-loading-bar', 'ngAnimate'])

//    .config(['cfpLoadingBarProvider', (cfpLoadingBarProvider) => {
//        cfpLoadingBarProvider.includeSpinner = false;
//    }])

// Controllers
    .controller('friendsController', friendsController)
//  .controller('AlarmListController', App.Controllers.AlarmListController)

// Services

//    .factory('messageService', ['$q', ($q) => new App.Services.MessageService($q)])
//    .factory('dataService', ['$http', '$q', 'messageService', 'mapService',
//        ($http, $q, messageService, mapService) => new App.Services.DataService($http, $q, messageService, mapService)])
//    .factory('mapService', [() => new App.Services.MapService()])
.run(function() {

});
//    .run(($rootScope: ng.IRootScopeService) => {
//        // Prevent two request at the same time by blocking the screen.
//        $rootScope.$on('cfpLoadingBar:started', (evt, e, ee) => {
//            $.blockUI({ message: null, overlayCSS: { opacity: 0 } });
//        });
//        $rootScope.$on('cfpLoadingBar:completed', (evt) => {
//            $.unblockUI();
//        });
//    });