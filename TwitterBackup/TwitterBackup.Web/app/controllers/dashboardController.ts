module App.Controllers {
    export class DashboardController extends BaseController {
        public downloadsCount: number;
        public retweetsCount: number;
        public retweetsCountIsAccurate: boolean;
        public users: Array<any>;

        constructor($scope: IScope<SearchUserController>,
            private $dashboardService : App.Services.DashboardService) {
            super($scope);

            $dashboardService.getData()
                .then(data => {
                    this.downloadsCount = data.DownloadsCount;
                    this.retweetsCount = data.RetweetsCount;
                    this.retweetsCountIsAccurate = data.RetweetsCountIsAccurate;
                    this.users = data.Users;
                },
                error => console.log(error));
        }
    }
}