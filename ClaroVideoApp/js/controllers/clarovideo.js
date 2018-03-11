'use strict';

var app = angular.module('ClaroVideoApp', []);

app.controller('getData', ["$scope", "$http", function ($scope, $http) {

    var url = "http://localhost:52405/api/VCards";
    var value = "";
    $scope.loadContent = true;

    function GetData (name, params, page) {
        $scope.loadContent = true;
        var options = {
            method: "GET",
            dataType: "json",
            url: url
        };
        params && (options.params = params);
        $http(options).then(function (response) {
            $scope[name] = response.data;
            page != undefined && ($scope.page = page);
            $scope.loadContent = false;
        });
    }

    this.$onInit = function () {
        GetData("items");
        $scope.page = 0;
    };

    $scope.selectPaga = function (page) {
        $scope.page = 0;
        console.info(value);
        $scope.searchvalue = value;
    };

    $scope.showDetail = function (id) {
        GetData("detailItem", { Id: id }, 1);
    };

    $scope.search = function (e) {
        value = angular.element(e.target).val();
        (e.keyCode === 13 || !value) && GetData("items", value ? { text: value } : null);
    };

}]);