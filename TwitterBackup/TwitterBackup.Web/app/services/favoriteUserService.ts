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

        public addToFavorites(user: User): ng.IPromise<any> {
            var defer = this.$q.defer();

            var data = { UserId: user.Id };

            this.$http.put('api/favoriteUser', data)
                .success(response => {
                    user.IsFavorite = true;
                    defer.resolve(response);
                })
                .error(defer.reject);

            return defer.promise;
        }

        public removeFromFavorites(user: User) : ng.IPromise<any> {
            var defer = this.$q.defer<any>();

            this.$http.delete<any>('api/favoriteUser?userId=' + user.Id)
                .success(response => {
                    user.IsFavorite = false;
                    defer.resolve(response);
                })
                .error(defer.reject);

             return defer.promise;
        }
    }
}