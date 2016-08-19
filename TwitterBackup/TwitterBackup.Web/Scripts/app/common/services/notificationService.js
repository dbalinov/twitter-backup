function notificationService(toastr) {
    "use strict";

    var self = this;
    self.toastr = toastr;
    self.toastr.options.positionClass = "toast-bottom-left";

    self.success = function (message) {
        self.toastr.success(message);
    };

    self.info = function (message) {
        self.toastr.info(message);
    };


    self.error = function(messageOptions) {
        if (messageOptions.modelState) {
            for (var key in messageOptions.modelState) {
                if (messageOptions.modelState.hasOwnProperty(key)) {
                    self.toastr.error(messageOptions.modelState[key]);
                }
            }
        } else if (messageOptions.message) {
            self.toastr.error(messageOptions.message);
        } else {
            var message = messageOptions;
            self.toastr.error(message);
        }
    };
};