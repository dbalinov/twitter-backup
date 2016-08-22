module App.Controllers {
    export class SearchUserController extends BaseController {
        public query: string;
        public users = Array<User>();

        constructor($scope: IScope<SearchUserController>,
          private $searchUserService: App.Services.SearchUserService) {
            super($scope);
        }
        
        public search() {
            this.$searchUserService.search(this.query)
                .then(users => this.users = users);

        }
    }
}