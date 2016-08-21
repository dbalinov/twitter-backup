module App.Services {
    export class FavoriteUserService {
        constructor(private $http: ng.IHttpService,
            private $q: ng.IQService) {
        }

        public getUsers(): ng.IPromise<User[]> {
            var defer = this.$q.defer<User[]>();

            this.$http.get<User[]>('api/favoriteUser')
                .success(defer.resolve)
                .error(defer.reject);
            return defer.promise;
        }

        public addToFavorites(friend) : ng.IPromise<any> {
            var defer = this.$q.defer();

            var data = { UserId: friend.Id };

            this.$http.put('api/favoriteUser', data)
                .success(response => {
                    friend.IsSaved = true;
                    defer.resolve(response);
                })
                .error(defer.reject);

            return defer.promise;
        }

        public removeFromFavorites(friend) : ng.IPromise<any> {
            var defer = this.$q.defer<any>();

            this.$http.delete<any>('api/friendship?userId=' + friend.Id)
                .success(response => {
                    friend.IsSaved = false;
                    defer.resolve(response);
                })
                .error(defer.reject);

             return defer.promise;
        }
    }
}