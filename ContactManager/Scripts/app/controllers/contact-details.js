contactManager.controller("ContactDetailsController", ['$scope', 'contactsService', '$routeParams','toaster' , function ($scope, contactsService, $routeParams,toaster) {

    var currentId = $routeParams.ContactId;
    contactsService.getContact(currentId).then(function (result) {
        $scope.contact = result;
    });
    $scope.submitForm = function (isValid) {
        if (isValid) {
            contactsService.updateContact($scope.contact).then(function (result) {
                toaster.pop('success', "Spremljeno", "Kontakt ažuriran");
            });
        }
    }
    $scope.add = function () {
        $scope.contact.Emails.push({});
    };
    $scope.remove = function (index) {
        $scope.contact.Emails.splice(index, 1);
    }
    $scope.addTelephone = function () {
        $scope.contact.Telephones.push({});
    };
    $scope.removeTelephone = function (index) {
        $scope.contact.Telephones.splice(index, 1);
    };
    $scope.loadTags = function (query) {
        return contactsService.getTags();
    };
    

}]);