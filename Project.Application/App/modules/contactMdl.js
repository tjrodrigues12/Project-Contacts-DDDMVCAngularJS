var contactMdl = angular.module('contactMdl', ['globalMdl']);

contactMdl.config(['$routeProvider', '$locationProvider',
    function ($routeProvider, $locationProvider) {

        $locationProvider.hashPrefix('');

        var baseUrl = '/Contact/';

        $routeProvider
            .when('/Index', {
                templateUrl: baseUrl + 'Index',
                controller: 'indexCtrl'
            })
            .when('/Inserir', {
                templateUrl: baseUrl + 'Add',
                controller: 'addCtrl'
            })
            .when('/Editar', {
                templateUrl: baseUrl + 'Edit',
                controller: 'editCtrl'
            })
            .otherwise({
                templateUrl: baseUrl + 'Index',
                controller: 'indexCtrl'
            });
    }
]);

angular.element(document).ready(function () {
    angular.bootstrap(document.getElementById("app"), ['contactMdl']);
});