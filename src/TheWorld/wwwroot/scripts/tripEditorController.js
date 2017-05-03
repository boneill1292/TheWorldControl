// tripEditorController.js

(function () {
  "use strict";

  angular.module("app-trips")
    .controller("tripEditorController", tripEditorController);


  function tripEditorController($routeParams, $http) {
    var vm = this;

    vm.tripName = $routeParams.tripName;
    vm.Stops = [];
    vm.errorMessage = "";
    vm.isBusy = true;

    $http.get("/api/trips/" + vm.tripName + "/stops")
      .then(function (response) {
        //success
        angular.copy(response.data, vm.Stops);
      },
        function (err) {
          //fail
          vm.errorMessage = "Failed to load stops";
        })
      .finally(function () {
        vm.isBusy = false;
      });


  }//Close trip editor controller function

})(); //Close top level function