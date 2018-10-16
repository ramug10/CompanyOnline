//app.controller('companySystemController', function ($scope) {
//    $scope.Message = "Test Message";
//});


testApp = angular
    .module("demo", [])
    .controller("companySystemController", function ($scope, $http) {
        $scope.companies = [];

        $scope.loadCompanies = function () {
            $http.get('http://localhost:8080/api/companies/getcompanies').then(function (response) {
                $scope.companies = response.data;
            })
        }

        //call loadCompanies when controller initialized
        $scope.loadCompanies();


        //$http.get('http://rest-service.guides.spring.io/greeting').then(function (response) {
        //    $scope.test = response.data;
        //});
    }); 
