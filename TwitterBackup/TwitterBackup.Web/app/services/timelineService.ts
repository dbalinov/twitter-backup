module App.Services {
    export class TimelineService {
        constructor(private $http: ng.IHttpService,
            private $q: ng.IQService) {
        }

        public getNext(userId, maxId, trimUser, savedOnly): ng.IPromise<TimelineResponse> {
            var defer = this.$q.defer<TimelineResponse>();
            
            var url = "api/timeline?trimUser=" + trimUser +
                "&userId=" + userId +
                "&savedOnly=" + savedOnly +
                "&count=" + 5;

            if (maxId) {
                url += "&maxId=" + maxId;
            }

            this.$http.get<TimelineResponse>(url)
                .success(defer.resolve)
                .error(defer.reject);

            return defer.promise;
        }
    }
}