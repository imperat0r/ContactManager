contactManager.controller("AddContactController", ['$scope', 'contactsService', function ($scope, contactsService) {
    $scope.contactToAdd = { name: '', surname: '', emails: [], telephones: [], tags: [] };
    $scope.contactToAdd.emails.push({});
    $scope.contactToAdd.telephones.push({});

    $scope.submitForm = function (isValid) {
        if (isValid) {
            console.log($scope.contactToAdd);
            contactsService.addContact($scope.contactToAdd);
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

}]);