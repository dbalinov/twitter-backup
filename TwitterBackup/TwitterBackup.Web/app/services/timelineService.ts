module App.Services {
    export class TimelineService {
        constructor(private $http: ng.IHttpService,
            private $q: ng.IQService) {
        }

        public getNext(userId, maxId, trimUser): ng.IPromise<TimelineResponse> {
            var defer = this.$q.defer<TimelineResponse>();
            
            var url = "api/timeline?trimUser=" + trimUser +
                "&userId=" + userId;
            if (maxId) {
                url += "&maxId=" + maxId;
            }

            this.$http.get<TimelineResponse>(url)
                .success(defer.resolve)
                .error(defer.reject);

            return defer.promise;
        }

        public retweet(statusId): ng.IPromise<any>  {
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