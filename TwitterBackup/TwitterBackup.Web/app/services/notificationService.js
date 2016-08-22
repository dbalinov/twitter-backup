/// <reference path="../app.ts" />
/// <reference path="../../scripts/typings/toastr/toastr.d.ts" />
var App;
(function (App) {
    var Services;
    (function (Services) {
        var NotificationService = (function () {
            function NotificationService(toastr) {
                this.toastr = toastr;
                toastr.options.positionClass = "toast-bottom-left";
            }
            NotificationService.prototype.success = function (msg) {
                this.toastr.success(msg);
            };
            NotificationService.prototype.info = function (message) {
                this.toastr.info(message);
            };
            NotificationService.prototype.error = function (msg) {
                if (msg.modelState) {
                    for (var key in msg.modelState) {
                        if (msg.modelState.hasOwnProperty(key)) {
                            this.toastr.error(msg.modelState[key]);
                        }
                    }
                }
                else if (msg.message) {
                    this.toastr.error(msg.message);
                }
                else {
                    this.toastr.error(msg);
                }
            };
            return NotificationService;
        }());
        Services.NotificationService = NotificationService;
    })(Services = App.Services || (App.Services = {}));
})(App || (App = {}));
//# sourceMappingURL=notificationService.js.map