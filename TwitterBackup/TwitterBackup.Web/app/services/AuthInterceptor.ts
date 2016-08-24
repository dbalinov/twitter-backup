module App.Services {
    export class AuthInterceptor implements ng.IHttpInterceptor {
        public responseError;

        public constructor(
            private $q: ng.IQService,
            private $location: ng.ILocationService,
            private $notificationService: App.Services.NotificationService) {
            this.responseError = this._responseError.bind(this);
        }

        private _responseError(rejection) {
            if (rejection.status === 401) {
                this.$notificationService.error('Not authorizated.');
                this.$location.path("/unauthorized");
            } else if (rejection.status === 404) {
                this.$notificationService.error('Not found.');
            }
            
            return this.$q.reject(rejection);
        }
    }
}