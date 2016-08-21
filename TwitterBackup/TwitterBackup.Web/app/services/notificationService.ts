/// <reference path="../app.ts" />
/// <reference path="../../scripts/typings/toastr/toastr.d.ts" />

module App.Services {
    export class NotificationService {
        constructor(private toastr: Toastr) {
             toastr.options.positionClass = "toast-bottom-left";
        }

        public success(msg) {
            this.toastr.success(msg);
        }

        public info(message) {
            this.toastr.info(message);
        }

        public error(msg) {
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
        }
    }
}