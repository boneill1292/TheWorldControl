// tripsController.js

(function () {

  "use strict";

  //Getting the exising module
  angular.module("app-trips")
    .controller("tripsController", tripsController);


  function tripsController($http) {

    var vm = this;
    vm.trips = [];
    //Hardcode a trips object before we actually get the data from the database.
    //vm.trips = [
    //{
    //  name: "US Trip",
    //  created: new Date()
    //}, {
    //  name: "World Trip",
    //  created: new Date()
    //}];


    //A new trip object
    vm.newTrip = {}

    //Error message
    vm.errorMessage = "";

    //a busy bool
    vm.isBusy = true;

    $http.get("/api/trips")
    .then(function (response) {
      //Success
      angular.copy(response.data, vm.trips);
    },
      function () {
        //Failure
        vm.errorMessage = "Failed to load dagta: " + error;
      })
    .finally(function () {
      vm.isBusy = false;
    });


    //Add Trip Function
    vm.addTrip = function () {
      vm.isBusy = true;
      vm.errorMessage = "";

      $http.post("/api/trips", vm.newTrip)
        .then(function (response) {
          //success
          vm.trips.push(response.data);
          vm.newTrip = {};

        },
          function () {
            //Failure
            vm.errorMessage = "failed to save new trip";
          })
        .finally(function () {
          vm.isBusy = false;
        });

    }; // End add trip function








  }// closes tripsController function

})(); //closes the whole page function