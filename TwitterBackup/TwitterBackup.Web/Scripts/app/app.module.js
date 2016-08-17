var twitterBackupApp = angular.module('twitterbackup', ['ngRoute']) // ['angular-loading-bar', 'ngAnimate'])
// controllers
    .controller('friendsController', friendsController)
// services
    .factory('friendsService', ['$http', function($http) {
            return new friendsService($http);
        }
    ])
//    .factory('messageService', ['$q', ($q) => new App.Services.MessageService($q)])
//    .factory('dataService', ['$http', '$q', 'messageService', 'mapService',
//        ($http, $q, messageService, mapService) => new App.Services.DataService($http, $q, messageService, mapService)])
//    .factory('mapService', [() => new App.Services.MapService()])

//    .config(['cfpLoadingBarProvider', (cfpLoadingBarProvider) => {
//        cfpLoadingBarProvider.includeSpinner = false;
//    }])
.run(function ($rootScope) {
    //// Prevent two request at the same time by blocking the screen.
    //$rootScope.$on('cfpLoadingBar:started', (evt, e, ee) => {
    //    $.blockUI({ message: null, overlayCSS: { opacity: 0 } });
    //});
    //$rootScope.$on('cfpLoadingBar:completed', (evt) => {
    //    $.unblockUI();
    //});
});