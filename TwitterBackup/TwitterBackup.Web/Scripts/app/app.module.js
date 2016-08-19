var twitterBackupApp = angular.module('twitterbackup', ['ngRoute', 'angular-loading-bar']) // ['ngAnimate'])
// controllers
    .controller('friendsController', friendsController)
// values
	.value('toastr', toastr)
// services
    .factory('friendsService', ['$http', '$q', function($http, $q) {
            return new friendsService($http, $q);
        }
    ])
    .factory("notificationService", ["toastr", function(toastr) {
            return new notificationService(toastr);
        }
    ])
// plugins config
    .config(['cfpLoadingBarProvider', (cfpLoadingBarProvider) => {
        cfpLoadingBarProvider.includeSpinner = false;
    }])

    // TODO: move to separate file
.directive('tooltip', function tooltip(){
    return {
        restrict: 'A',
        link: function(scope, element, attrs){
            $(element).hover(function(){
                // on mouseenter
                $(element).tooltip('show');
            }, function(){
                // on mouseleave
                $(element).tooltip('hide');
            });
        }
    };
})

.run(function ($rootScope) {
    // Prevent two request at the same time by blocking the screen.
    $rootScope.$on('cfpLoadingBar:started', (evt, e, ee) => {
        $.blockUI({ message: null, overlayCSS: { opacity: 0 } });
    });
    $rootScope.$on('cfpLoadingBar:completed', (evt) => {
        $.unblockUI();
    });
});