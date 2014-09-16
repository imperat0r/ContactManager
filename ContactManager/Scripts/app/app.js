var contactManager = angular.module("contactManager", ['ngRoute', 'ngAnimate','ui.bootstrap']);


contactManager.config(['$routeProvider',function ($routeProvider) {


    var templateFolder = ROOT + 'Scripts/app/templates/';
    $routeProvider
        .when('/', {
            templateUrl: templateFolder + "Index.html",
            controller: 'HomeController'
        })
        .when('/ContactDetails/:ContactId', {
            templateUrl: templateFolder + "ContactDetails.html",
            controller: 'ContactDetailsController'
        })
       .when('/AddContact', {
           templateUrl: templateFolder + "AddContact.html",
           controller: 'AddContactController'
       })


}]);