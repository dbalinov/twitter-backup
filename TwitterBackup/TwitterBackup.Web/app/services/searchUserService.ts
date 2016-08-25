module App.Services {
    export class SearchUserService {
        constructor(private $http: ng.IHttpService,
            private $q: ng.IQService) {
        }

        public getRecommendedUsers(): ng.IPromise<User[]> {
            var defer = this.$q.defer<User[]>();

            this.$http.get<User[]>('api/searchUser')
                .success(defer.resolve)
                .error(defer.reject);

            return defer.promise;
        }

        public search(query: string) : ng.IPromise<User[]> {
            var defer = this.$q.defer<User[]>();

            this.$http.post<User[]>('api/searchUser', { Query: query })
                .success(defer.resolve)
                .error(defer.reject);

            return defer.promise;
        }
    }
}