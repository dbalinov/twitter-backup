module App.Services {
    export class StatusService {
        constructor(private $http: ng.IHttpService,
            private $q: ng.IQService) {
        }

        public retweet(statusId): ng.IPromise<any> {
            var defer = this.$q.defer<any>();

            this.$http.post<any>('api/retweet/', { StatusId: statusId })
                .success(defer.resolve)
                .error(defer.reject);

            return defer.promise;
        }

        public save(statusId): ng.IPromise<any> {
            var defer = this.$q.defer();

            this.$http.post('api/statusStore/', { StatusId: statusId })
                .success(defer.resolve)
                .error(defer.reject);

            return defer.promise;
        }

        public unsave(statusId): ng.IPromise<any> {
            var defer = this.$q.defer();
            var url = 'api/statusStore/?statusId=' + statusId;

            this.$http.delete(url)
                .success(defer.resolve)
                .error(defer.reject);

            return defer.promise;
        }
    }
}