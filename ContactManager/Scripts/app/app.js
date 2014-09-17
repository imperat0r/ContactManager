var contactManager = angular.module("contactManager", ['ngRoute', 'ngAnimate', 'angular-loading-bar', 'ui.bootstrap', 'ngTagsInput', 'toaster']);


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