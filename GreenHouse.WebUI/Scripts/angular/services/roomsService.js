(function() {
    'use strict';

    angular.module('internshipApp').service("roomsService", roomsService);

    function roomsService($http) {
        // Return public API
        return ({
            getRooms: getRooms
        });

        function getRooms() {
            var request = $http({
                method: "GET",
                url: '/Daily/GetRooms'
            });

            return request;
        }
    }
})()