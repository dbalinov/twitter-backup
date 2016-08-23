module App.Services {
    export class DashboardService {
        constructor(private $http: ng.IHttpService,
            private $q: ng.IQService) {
        }

        public getData(): ng.IPromise<DashboardResponse>  {
            var defer = this.$q.defer<DashboardResponse>();

            this.$http.get('api/dashboard')
                .success(defer.resolve)
                .error(defer.reject);

            return defer.promise;
        }
    }
}