contactMdl.controller('addCtrl', ['$scope', 'contactSrv',
    function ($scope, service) {

       $scope.contact = {}

        $scope.save = function () {           

            var valido = true;            

            if (valido) {
                service.save($scope.contact).then(function (response) {
                    if (response.contact == true) $scope.return();
                })
            }
        }

        $scope.return = function () {           
            return $location.path("/Index");
        };

    }
]);