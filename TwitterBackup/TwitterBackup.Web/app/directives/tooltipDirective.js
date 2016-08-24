var App;
(function (App) {
    var Directives;
    (function (Directives) {
        twitterBackupApp.directive('tooltip', function () {
            return {
                restrict: 'A',
                link: function (scope, element, attrs) {
                    $(element)
                        .hover(function () { return $(element).tooltip('show'); }, function () { return $(element).tooltip('hide'); });
                }
            };
        });
    })(Directives = App.Directives || (App.Directives = {}));
})(App || (App = {}));
