module App.Controllers {
    export class DashboardController extends BaseController {
        constructor($scope: IScope<SearchUserController>,
            private $dashboardService : App.Services.DashboardService) {
            super($scope);

            $dashboardService.getData()
                .then(data => {
                },
                error => console.log(error));
        }
    }
}