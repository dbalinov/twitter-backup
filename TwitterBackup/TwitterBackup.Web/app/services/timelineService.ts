module App.Services {
    export class TimelineService {
        private maxId = null;
        private noMorePosts = false;

        constructor(private $http: ng.IHttpService,
            private $q: ng.IQService) {
        }

        public getNext(userId, trimUser): ng.IPromise<TimelineResponse> {
            var defer = this.$q.defer<TimelineResponse>();

            if (this.noMorePosts) {
                defer.resolve({ Statuses: [] });
            } else {
                var url = "api/timeline?trimUser=" + trimUser +
                    "&userId=" + userId;
                if (this.maxId) {
                    url += "&maxId=" + this.maxId;
                }

                this.$http.get<TimelineResponse>(url)
                    .success(data => {
                        defer.resolve(data);
                        var items = data.Statuses;
                        if (items.length > 0) {
                            this.maxId = items[items.length - 1].Id;
                        } else {
                            this.noMorePosts = true;
                        }
                    })
                    .error(defer.reject);
            }

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