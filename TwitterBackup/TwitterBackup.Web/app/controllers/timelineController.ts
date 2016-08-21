module App.Controllers {
    export class TimelineController extends BaseController {
        public user: User;
        private busy = false;

        constructor($scope: IScope<TimelineController>,
            private $routeParams,
            private $timelineService: App.Services.TimelineService,
            private $notificationService: App.Services.NotificationService) {
            super($scope);
        }

//    var screenName = $routeParams["screenName"];

//    $scope.items = [];

        public getNext() {
            if (this.busy) return;

            this.busy = true;
            //this.$timelineService.getNext(screenName)
            //    .then(data => {

//                if (data.User) {
//                    $scope.user = data.User;
//                }

//                var items = data.Statuses;
//                for (var i = 0; i < items.length; i++) {
//                    $scope.items.push(items[i]);
//                }

//                $scope.busy = false;
//            });
        }

        public retweet(status) {
            if (!status.Retweeted) {
                this.$timelineService.retweet(status.Id)
                    .then(() => {
                        status.Retweeted = true;
                        this.$notificationService.info("The status has been retweeted.");
                    });
            } else {
                this.$notificationService.info("The status is alredy retweeted.");
            }
        }

        public save(status) {
            if (!status.IsSaved) {
//            timelineService.save(status.Id)
//                .then(() => {
//                    status.IsSaved = true;
//                    notificationService.info("The status has been saved.");
                //                });
            } else {
                //this.$timelineService.unsave(status.Id)
//                .then(() => {
//                    status.IsSaved = false;
//                    notificationService.info("The status has been unsaved.");
                //                });
            }
        }
    }
}
