var instituicoesTiposMdl = angular.module('homeMdl', ['globalMdl']);


angular.module('homeMdl').controller("globalCtrl", ['$scope',
    function ($scope) {
        //Informar o Título da Página aqui
        $scope.tituloPagina = "Página Inicial";       

    }]);

angular.element(document).ready(function () {
    angular.bootstrap(document.getElementById("app"), ['homeMdl']);
});