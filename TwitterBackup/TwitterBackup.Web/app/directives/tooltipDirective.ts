module App.Directives {
    twitterBackupApp.directive('tooltip',
    () => {
        return {
            restrict: 'A',
            link: (scope, element, attrs) => {
                $(element)
                    .hover(
                    () => $(element).tooltip('show'),
                    () => $(element).tooltip('hide'));
            }
        };
    });
}