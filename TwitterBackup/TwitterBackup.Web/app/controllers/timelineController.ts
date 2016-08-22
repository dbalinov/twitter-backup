module App.Controllers {
    export class TimelineController extends BaseController {
        public user: User;
        public items = [];

        private busy = false;
        private userId;

        constructor($scope: IScope<TimelineController>,
            private $routeParams: ng.RouteData,
            private $timelineService: App.Services.TimelineService,
            private $notificationService: App.Services.NotificationService) {
            super($scope);

            this.userId = this.$routeParams["userId"];
            this.getNext();
        }

        public getNext() {
            if (this.busy) return;

            this.busy = true;
            var trimUser = !!this.user;

            this.$timelineService.getNext(this.userId, trimUser)
                .then(data => {
                    if (data.User) {
                        this.user = data.User;
                    }

                    var items = data.Statuses;
                    for (var i = 0; i < items.length; i++) {
                        this.items.push(items[i]);
                    }

                    this.busy = false;
                });
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
                this.$timelineService.save(status.Id)
                    .then(() => {
                        status.IsSaved = true;
                        this.$notificationService.info("The status has been saved.");
                    });
            } else {
                this.$timelineService.unsave(status.Id)
                    .then(() => {
                        status.IsSaved = false;
                        this.$notificationService.info("The status has been unsaved.");
                    });
            }
        }
    }
}
