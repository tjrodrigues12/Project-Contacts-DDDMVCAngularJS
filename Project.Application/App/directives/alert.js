globalMdl.directive('alert', function () {

    return {

        restrict: 'E',
        templateUrl: '/app/Diretives/alert-template.html',
        transclude: true,
        scope: {

            style: '@',
            show: '@'

        }
    }

});