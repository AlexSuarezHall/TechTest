(function () {
    'use strict';

    angular
        .module('techTestModule')
        .filter('ColourStringFilter', ColourStringFilter);

    function ColourStringFilter() {
        return function (data) {
            if (data.length === 0) {
                return "No colours selected";
            }

            var colours = data.map(item => item.Name);
            return colours.join(", ");
        };
    }

})();