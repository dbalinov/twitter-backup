module App.Controllers {
    export class FavoriteUserController extends BaseController {
        users = new Array<User>();

        constructor($scope: IScope<FavoriteUserController>,
            private $favoriteUserService: App.Services.FavoriteUserService,
            private $notificationService: App.Services.NotificationService) {
            super($scope);

            $favoriteUserService.getUsers()
                .then(users => this.users = users,
                      error => console.log(error));
        }
        
        public addToFavorites(user: User) {
            this.$favoriteUserService.addToFavorites(user)
                .then(() => this.$notificationService.info(user.Name + " is added to favorites."));
        }

        public removeFromFavorites(user: User) {
            this.$favoriteUserService.removeFromFavorites(user)
                .then(() => this.$notificationService.info(user.Name + " is remoevd from favorites."));
        }
    }
}