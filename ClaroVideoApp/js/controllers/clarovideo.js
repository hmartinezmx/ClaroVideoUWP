'use strict';

var app = angular.module('ClaroVideoApp', []);

app.controller('getData', ["$scope", "$http", function ($scope, $http) {

    var url = "http://localhost:52405/api/VCards";
    var valueSearch = "";
    $scope.loadContent = true;
    
    //Una vez inicializados todos los componentes angular se cargan todos los item y muestra la pagina principal
    this.$onInit = function () {
        GetData("items");
        $scope.page = 0;
    };

    //Creacion de funciones para la vista
    //Patron de diseño Object Literals
    $scope.fns = {

        /**
            * Funcion para navegar entre paginas
            * @param {Number} page Numero de la pagina
        */
        selectPaga: function (page) {
            $scope.page = page;
            $scope.value = valueSearch;
        },

        /**
            * Obtiene la informacion detallada del item mediante id
            * @param {Number} id Id del vcard a obtener
        */
        showDetail: function (id) {
            GetData("detailItem", { Id: id }, 1);
        },

        /**
            * Obtiene los items que contengan en el titulo el string de busqueda cuando se presiona enter
            * @param {Object} e Objecto event handlers
        */
        search: function (e) {

            //Obtiene el texto de busqueda
            valueSearch = angular.element(e.target).val();

            //Si se presiona enter o el valor de busqueda esta vacio
            (e.keyCode === 13 || !valueSearch) && GetData("items", valueSearch ? { text: valueSearch } : null);
        }
    };

    /**
            * Funcion para obterner la informacion del WEB API
            * @param {String} name Nombre de la variable de $scope donde se almacenara el resultado
            * @param {Object} params Objeto con los parametros para realizar la consulta
            * @param {Number} page Pagina a la que se navegara cuando se realice la consulta
        */
    function GetData(name, params, page) {
        //Muestra el loader
        $scope.loadContent = true;
        var options = {
            method: "GET",
            dataType: "json",
            url: url
        };

        //Si hay parametros se agregan a las opciones del request
        params && (options.params = params);

        //Se realiza el request
        $http(options).then(function (response) {
            $scope[name] = response.data;
            page != undefined && ($scope.page = page);

            //Oculta el loager
            $scope.loadContent = false;
        });
    }

}]);