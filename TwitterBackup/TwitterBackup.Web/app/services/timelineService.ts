module App.Services {
    export class TimelineService {
        private maxId = null;
        private trimUser = false;
        private noMorePosts = false;

        constructor(private $http: ng.IHttpService,
            private $q: ng.IQService) {
        }

        public getNext(screenName) : ng.IPromise<any> {
            var defer = this.$q.defer<{ Statuses: any }>();

            if (this.noMorePosts) {
                defer.resolve({ Statuses: [] });
            } else {
                var url = "api/timeline?trimUser=" + this.trimUser +
                    "&screenName=" + screenName;
                if (this.maxId) {
                    url += "&maxId=" + this.maxId;
                }

                this.$http.get<{ Statuses: any }>(url)
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

                this.trimUser = true;
            }

            return defer.promise;
        }

        public retweet(statusId) : ng.IPromise<any>  {
            var defer = this.$q.defer<any>();

            this.$http.post<any>('api/retweet/', { StatusId: statusId })
                .success(defer.resolve)
                .error(defer.reject);

            return defer.promise;
        }

        //self.save = function (statusId): ng.IPromise<any>  {
    //    var defer = $q.defer();

    //    $http.post('api/statusStore/', { StatusId: statusId })
    //        .success(defer.resolve)
    //        .error(defer.reject);

    //    return defer.promise;
    //};

    //self.unsave = function (statusId) : ng.IPromise<any> {
    //    var defer = $q.defer();
    //    var url = 'api/statusStore/?statusId=' + statusId;
    //    $http.delete(url)
    //        .success(defer.resolve)
    //        .error(defer.reject);
    //    return defer.promise;
    //};
    }
}