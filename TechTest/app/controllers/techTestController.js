(function () {
    'use strict';

    angular
        .module('techTestModule')
        .controller('TechTestController', TechTestController)
        .filter('ColourStringFilter');

    TechTestController.$inject = ['$scope', '$http'];

    function TechTestController($scope, $http) {

        $scope.init = function init() {
            $scope.formSubmitted = false;
            $scope.showEdit = false;
            $scope.person = {};
            $scope.Colours = [];

            $('#Loading').modal('show');

            $http.get('/api/People/GetPeople')
                .then(function (response, status, header, config) {
                    $scope.people = response.data;
                    $('#Loading').modal('hide');
                }).catch(function (response) {
                    $('#Loading').modal('hide');
                    console.log(response.data.Message);
                })

            $http.get('/api/Colours/GetColour')
                .then(function (response, status, headers, config) {
                    $scope.colours = response.data;
                }).catch(function (response) {
                    console.log(response.data.Message);
                })
        }

        $scope.delete = function (personId) {
            var config = {
                params: { id: personId },
                headers: { 'Accept': 'application/json' }
            };

            $http.get('/api/People/DeletePerson', config)
                .then(function (response, status, headers, config) {
                    $scope.init();
                }).catch(function (response) {
                    console.log(response.data.Message);
                })
        }

        $scope.toggleCheckBox = function (id) {
            var index = $scope.Colours.indexOf(id);
            if (index > -1) {
                $scope.Colours.splice(index, 1);
            }
            else {
                $scope.Colours.push(id);
            }
        }

        $scope.saveUpdatePerson = function (person) {
            $scope.formSubmitted = true;

            if ($scope.personForm.$valid) {

                var model = {
                    Person: person,
                    ColourIds: $scope.Colours
                };

                return $http.post('/api/People/SavePerson', model)
                    .then(function () {
                        $scope.showEdit = false;
                        $scope.init();
                    }).catch(function (response) {
                        console.log(response.data.Message);
                    })
            }
        }

        $scope.editPerson = function (personId) {
            $scope.title = 'Edit';
            $scope.clearValues();
            $scope.formSubmitted = false;

            var config = {
                params: { id: personId },
                headers: { 'Accept': 'application/json' }
            };

            $http.get('/api/People/GetPerson', config)
                .then(function (response, status, headers, config) {
                    $scope.person = response.data;
                    $scope.person.DOB = new Date(Date.parse($scope.person.DOB));
                    angular.forEach($scope.person.ColourIds, function (value) { $scope.Colours.push(value); });
                    $scope.showEdit = true;
                }).catch(function (response) {
                    console.log(response.data.Message);
                })
        }

        $scope.createNew = function () {
            $scope.title = 'Create';
            $scope.showEdit = true;
            $scope.clearValues();
        }

        $scope.clearValues = function () {
            $scope.Colours = [];
            $scope.person = {};
            $scope.formSubmitted = false;
        }
    }

})();

