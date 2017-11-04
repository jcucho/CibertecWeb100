(function () {
    'use strict';
    angular.module('app').controller('applicationController', applicationController);

    function applicationController() {
        var vm = this;
        vm.message = "Hola Angular";
    }

})();