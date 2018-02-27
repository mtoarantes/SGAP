WebApp.controller("ConfigCentroResultadoCtrl",
        ['$rootScope',
        '$scope',
        '$state',
        'CentroResultadoService',
        'NgTableParams',
    function ($rootScope, $scope, $state, CentroResultadoService, NgTableParams) {

        $scope.init = function () {
            $scope.BuscaCentroCusto();
        };

        $scope.configCentroCusto = {};
        $scope.listCentroCusto = [];

        $scope.BuscaCentroCusto = function () {
            CentroResultadoService.getCentroResultado().then(function (response) {
                $scope.listCentroCusto = response.data;
                $scope.ngParametros = $scope.getNgTableParametros($scope.listCentroCusto);
            })
        }

        $scope.ngParametros = new NgTableParams();
        $scope.getNgTableParametros = function (data) {
            var initialParams = {
                count: 6 // Registro por página
            };
            var initialSettings = {
                // page size buttons (right set of buttons in demo)
                counts: [],
                // determines the pager buttons (left set of buttons in demo)
                paginationMaxBlocks: 13,
                paginationMinBlocks: 2,
                dataset: data
            };
            return new NgTableParams(initialParams, initialSettings);
        }


        $scope.InsertCentroCusto = function (form) {
            CentroResultadoService.postCentroResultado(form).then(function (response) {
                var msg = JSON.stringify(response.data);
                console.log(msg);
                $scope.resetForm(form);
                MsgSucesso(msg);
                $scope.BuscaCentroCusto();
            }).catch(function (error) {
                var msg = error.data.Message;
                console.log(msg);
                MsgFalha(msg);
            });
        };

        $scope.resetForm = function (form) {
            angular.copy({}, form);
        };

        function MsgSucesso(msg) {
            alertify.set('notifier', 'position', 'bottom-right');
            alertify.success(msg);
        };

        function MsgFalha(msg) {
            alertify.set('notifier', 'position', 'bottom-right  ');
            alertify.error(msg);
        };
    }]);

//        $scope.tabs = [
//            { heading: "Empresas", icon: "glyphicon glyphicon-list-alt", route: "empresa.empresas", active: true },
//            { heading: "Cadastro", icon: "glyphicon glyphicon-plus-sign", route: "empresa.cadastro", active: true },
//            { heading: "Editar/Excluir", icon: "glyphicon glyphicon-trash", route: "empresa.editar", active: true },
//        ];

//        $scope.ngParametros = ngTabelaEmpresa();         

//        function ngTabelaEmpresa() {
//            var initialParams = {
//                count: 10 // Registro por página
//            };
//            var initialSettings = {
//                // page size buttons (right set of buttons in demo)
//                counts: [],
//                // determines the pager buttons (left set of buttons in demo)
//                paginationMaxBlocks: 13,
//                paginationMinBlocks: 2,
//                dataset: $scope.empresas
//            };
//            return new NgTableParams(initialParams, initialSettings);
//        }

//        $scope.go = function (route) {
//            $state.go(route);
//        };

//        $scope.active = function (route) {
//            return $state.is(route);
//        };

//        $scope.$on("$stateChangeSuccess", function () {
//            $scope.tabs.forEach(function (tab) {
//                tab.active = $scope.active(tab.route);
//            });
//        });

//        var retornoEmpresa = EmpresaService.getEmpresas();
//        retornoEmpresa.then(function (response) {
//            $scope.empresas = response.data;
//        })

//        $scope.resetForm = function (form) {
//            angular.copy({}, form);
//        };

//        $scope.empresa = {};
//        $scope.lista = {};
//        $scope.InsertEmpresa = function (form) {
//            var retorno = EmpresaService.postEmpresa(form);
//            retorno.then(function (response) {
//                var msg = JSON.stringify(response.data);
//                $scope.resetForm(form);
//                MsgSucesso(msg);
//            }).catch(function (error) {
//                var msg = error.data.Message;
//                MsgFalha(msg);
//            });
//        };

//        function MsgSucesso(msg) {
//            alertify.set('notifier', 'position', 'bottom-right');
//            alertify.success(msg);
//        };

//        function MsgFalha(msg) {
//            alertify.set('notifier', 'position', 'bottom-right  ');
//            alertify.error(msg);
//        };
//    }]);