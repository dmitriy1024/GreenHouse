﻿(function () {
    'use strict';

    angular.module("internshipApp").controller("roomsCtrl", roomsCtrl);

    function roomsCtrl($scope, $filter, roomsService) {
        roomsService.getRooms().then(function (response) {
            $scope.rooms = response.data;
        });

        $scope.selectedRoom = null;

        $scope.selectRoom = function (roomNumber) {
            $scope.selectedRoom = $filter('filter')($scope.rooms, { number: roomNumber })[0];
        }

        
        //$scope.filtering = function (x) {
        //    //$scope.filteredRooms = $filter('filter')($scope.rooms, { places: x });
        //    $scope.filteredRooms = [];
        //    for (var i = 0; i < $scope.rooms.length; i++) {
        //        if ($scope.rooms[i].places >= x) {
        //            $scope.filteredRooms.push($scope.rooms[i]);
        //        }
        //    }
        //}

        $scope.filtering = function (x) {
            if (x == 0) x = 10;
            if (x == 25) x = 30;
            if (x == 50) x = 70;
            if (x == 75) x = 100;
            else if (x == 100) x = 200;

            $scope.filteredRooms = [];
            var wifi = $('#wifi').is(':checked');
            var projector = $('#projector').is(':checked');
            var monitor = $('#monitor').is(':checked');
            var microphone = $('#microphone').is(':checked');
            for (var i = 0; i < $scope.rooms.length; i++) {
                if ($scope.rooms[i].places >= x) {
                    $scope.filteredRooms.push($scope.rooms[i]);
                }
            }
            if (wifi == true) {
                $scope.filteredRooms = $filter('filter')($scope.filteredRooms, { wifi: true });
            }
            if (projector == true) {
                $scope.filteredRooms = $filter('filter')($scope.filteredRooms, { projector: true });
            }
            if (monitor == true) {
                $scope.filteredRooms = $filter('filter')($scope.filteredRooms, { monitor: true });
            }
            if (microphone == true) {
                $scope.filteredRooms = $filter('filter')($scope.filteredRooms, { microphone: true });
            }
        }
    }
})()