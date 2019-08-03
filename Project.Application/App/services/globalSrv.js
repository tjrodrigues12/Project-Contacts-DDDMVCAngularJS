angular.module('globalMdl').service('globalSvc', ['$http', '$filter', 
    function ($http, $filter) {

        var msg = {
            text: '',
            style: 'info',
            visible: false
        };

        function getData (response) {
            foundMessage(response);
            var retorno = {};
            retorno.data.result = response.data.result;
            retorno.count = response.data.count;
            return retorno;
        };

        function foundMessage (response) {
            if (response) {
                switch (response.status) {
                    case 401:
                        window.location = "/Default.aspx";
                        break;
                    case 403:
                        showMessage.set("Você não possui permissão para a ação solicitada.", 'error');
                        break;
                    case 404:
                        showMessage.set("Solicitação não localizada.", 'error');
                        break;
                    default:
                        if (response.data.message != "") {
                            showMessage.set(response.data.message, response.data.messageType);
                        }
                        break;
                }
            }
        };

        var showMessage = {

            set: function (text, style) {
                msg.text = text;
                msg.style = style;
                msg.visible = (text != '' || text != null);
            },

            get: function () {
                return msg;
            }

        };

        function clearMessage() {
            showMessage.set(null, 'info');
        };

        return {
            getData: getData,
            showMessage: showMessage,
            clearMessage: clearMessage
        };

    }]);