WebApp.factory("CentroResultadoService", ['$http', function ($http) {
    var url = config.server + 'api/ConfiguracaoCentroResultado';
    return {
        getCentroResultado: function () {
            return $http.get(url)
        },

        postCentroResultado: function (form) {
            return $http.post(url, form);
        }
    }
}])
