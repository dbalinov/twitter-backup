var App;
(function (App) {
    var Services;
    (function (Services) {
        var SavedStatusService = (function () {
            function SavedStatusService($http, $q) {
                this.$http = $http;
                this.$q = $q;
            }
            return SavedStatusService;
        }());
        Services.SavedStatusService = SavedStatusService;
    })(Services = App.Services || (App.Services = {}));
})(App || (App = {}));
//# sourceMappingURL=savedStatusService.js.map