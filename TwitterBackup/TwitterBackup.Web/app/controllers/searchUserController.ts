module App.Controllers {
    export class SearchUserController extends BaseController {
        public query: string;
        public users = Array<User>();
        public recommendedUsers = Array<User>();

        constructor($scope: IScope<SearchUserController>,
          private $searchUserService: App.Services.SearchUserService) {
            super($scope);

            this.$searchUserService.getRecommendedUsers()
                .then(users => this.recommendedUsers = users);
        }
        
        public search() {
            this.$searchUserService.search(this.query)
                .then(users => this.users = users);

        }
    }
}