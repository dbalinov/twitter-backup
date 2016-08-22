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
    }
}