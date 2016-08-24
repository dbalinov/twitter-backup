module App.Controllers {
    export abstract class TimelineBaseController extends BaseController {
        public user: User;
        public items = [];
        public userId;

        protected savedOnly;

        private busy = false;
        private maxId = null;
        private noMorePosts = false;

        constructor($scope: IScope<TimelineController>,
            private $routeParams: ng.RouteData,
            private $timelineService: App.Services.TimelineService) {
            super($scope);

            this.userId = this.$routeParams["userId"];
        }

        public getNext() {
            if (this.busy || this.noMorePosts) {
                return;
            }

            this.busy = true;
            var trimUser = !!this.user;

            this.$timelineService.getNext(this.userId, this.maxId, trimUser, this.savedOnly)
                .then(data => {
                    if (data.User) {
                        this.user = data.User;
                    }

                    var items = data.Statuses;

                    if (items.length > 0) {
                        for (var i = 0; i < items.length; i++) {
                            this.items.push(items[i]);
                        }

                        this.maxId = items[items.length - 1].Id;
                    }

                    this.busy = false;
                    this.noMorePosts = items.length !== 5;
                });
        }
    }
}