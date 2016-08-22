module App.Controllers {
    export class FavoriteUserController extends BaseController {
        users = new Array<User>();
        loaded = false;

        constructor($scope: IScope<FavoriteUserController>,
            private $favoriteUserService: App.Services.FavoriteUserService) {
            super($scope);

            $favoriteUserService.getUsers()
                .then(users => {
                    this.users = users;
                    this.loaded = true;
                },
                error => console.log(error));
        }
    }
}