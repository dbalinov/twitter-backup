module App.Controllers {
    export class SavedStatusController extends BaseController {
        public user: User;
        public items = [];
        public userId;

        private busy = false;
        private maxId = null;
        private noMorePosts = false;

        constructor($scope: IScope<TimelineController>,
            private $routeParams: ng.RouteData,
            private $savedStatusService: App.Services.SavedStatusService) {
            super($scope);

            this.userId = this.$routeParams["userId"];
            this.getNext();
        }

        public getNext() {
            if (this.busy) return;

            this.busy = true;
            var trimUser = !!this.user;

            if (this.noMorePosts) {
                return;
            }

            this.$savedStatusService.getNext(this.userId, this.maxId, trimUser)
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
                    } else {
                        this.noMorePosts = true;
                    }

                    this.busy = false;
                });
        }
    }
}