WebApp.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {

    $urlRouterProvider.otherwise('/');
    $stateProvider
    .state('configCentroResultado', {
        url: "/configuracao/centro-de-resultado",
        templateUrl: "/Views/Configuracao/CentroResultado.html"
        // controller: "empresaCtrl",
    });

    $stateProvider
    .state('cadastroUsuario', {
        url: "/Lancamentos/cadastro-de-usuario",
        templateUrl: "/Views/Lançamentos/CadastroUsuario.html"
        // controller: "empresaCtrl",
    });
});
