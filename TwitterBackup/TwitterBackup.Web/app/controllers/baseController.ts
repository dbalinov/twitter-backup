module App.Controllers {
    export class BaseController {
        constructor(public $scope: IScope<BaseController>) {
            $scope.model = this;
        }
    }
} 