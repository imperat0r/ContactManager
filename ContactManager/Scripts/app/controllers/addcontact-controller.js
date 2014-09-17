contactManager.controller("AddContactController", ['$scope', 'contactsService','toaster', function ($scope, contactsService,toaster) {
    $scope.contactToAdd = { name: '', surname: '', emails: [], telephones: [], tags: [] };
    $scope.contactToAdd.emails.push({});
    $scope.contactToAdd.telephones.push({});

    $scope.submitForm = function (isValid) {
        if (isValid) {
            contactsService.addContact($scope.contactToAdd);
            toaster.pop('success', "Spremljeno", "Kontakt ažuriran");
            $scope.contactToAdd = { name: '', surname: '', emails: [], telephones: [], tags: [] };
        }
    }

    $scope.add = function () {
        $scope.contactToAdd.emails.push({});
    };
    $scope.remove = function (index) {
        $scope.contactToAdd.emails.splice(index, 1);
    };
    $scope.addTelephone = function () {
        $scope.contactToAdd.telephones.push({});
    };
    $scope.removeTelephone = function (index) {
        $scope.contactToAdd.telephones.splice(index, 1);
    };
    $scope.loadTags = function (query) {
        return contactsService.getTags();
    };
}]);