module App.Controllers {
    export class SavedStatusController extends TimelineBaseController {
        constructor($scope: IScope<TimelineController>,
            $routeParams: ng.RouteData,
            $timelineService: App.Services.TimelineService) {

            super($scope, $routeParams, $timelineService);
            this.savedOnly = true;
        }
    }
}
