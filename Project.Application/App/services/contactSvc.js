contactMdl.service("contactSrv", ['$http', 'globalSvc',
    function ($http, globalSvc ) {

        var baseUrl = "http://localhost:52367/api/Contact";

        var _getAll = function (customGrid) {
            return $http.get(baseUrl, { params: customGrid })
                .then(function (response) {
                    return response; //globalSvc.getData(response);
                }, function (error) {
                    globalSvc.showMessage.set(error, 'danger')
                });
        };
       
        var _save = function (contact) {
            return $http.post(baseUrl, contact)
        };

        return {
            getAll: _getAll,
            save: _save
        };
}]);