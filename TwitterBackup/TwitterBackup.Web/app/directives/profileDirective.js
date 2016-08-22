var App;
(function (App) {
    var Directives;
    (function (Directives) {
        twitterBackupApp.directive("userProfile", ['$compile', function ($compile) {
                return {
                    restrict: "A",
                    scope: "@userProfile",
                    replace: true,
                    templateUrl: "app/templates/directives/userProfile.html",
                    link: function (scope, element, attributes) {
                        //console.log(attributes.myDirective); //literal string "{{some string}}", no interpolation
                        //console.log(attributes.anotherParam); //literally "another string"
                        attributes.$observe('userProfile', function (value) {
                            console.log(value);
                            scope.user = value;
                        });
                        //attributes.$observe('anotherParam', function (value) {
                        //    console.log(value);
                        //});
                    }
                };
            }]);
    })(Directives = App.Directives || (App.Directives = {}));
})(App || (App = {}));
