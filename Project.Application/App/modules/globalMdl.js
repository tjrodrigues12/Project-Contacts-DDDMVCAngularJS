var globalMdl = angular.module('globalMdl', ['ngRoute',
    'ui.grid',                  //data grid for AngularJS
    'ui.grid.pagination',       //data grid Pagination
    'ui.grid.resizeColumns',    //data grid Resize column
    'ui.grid.moveColumns',      //data grid Move column
    'ui.grid.pinning',          //data grid Pin column Left/Right
    'ui.grid.selection',        //data grid Select Rows
    'ui.grid.autoResize',       //data grid Enabled auto column Size
    'ui.grid.exporter']);

globalMdl.config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);
}]);

globalMdl.config(['$provide','$locationProvider',
    function ($provide,$locationProvider) {
        $provide.decorator('GridOptions', ['$delegate', 'i18nService',
            function ($delegate, i18nService) {
                var gridOptions = angular.copy($delegate);
                gridOptions.initialize = function (options) {
                    var initOptions = $delegate.initialize(options);
                    return initOptions;
                };
                i18nService.setCurrentLang('pt-br');
                return gridOptions;
            }]);

        $locationProvider.hashPrefix('');        
    }
]);

globalMdl.filter('filterDate', ['$filter',
    function ($filter) {
        /* A propriedade valor tem que ser do tipo DateTime ou DateTime? */
        return function (valor, formato) {
            return (!!valor) ? $filter('date')(valor, formato || 'MMMM dd, yyyy') : '-';
        };
    }
]);

