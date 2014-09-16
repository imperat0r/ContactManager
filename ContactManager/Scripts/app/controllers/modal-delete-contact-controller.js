var ModalInstanceCtrl = ['$scope', '$modalInstance', 'contactsService', 'arrayOfContacts', 'numberOfContactsToDelete', function ($scope, $modalInstance, contactsService, arrayOfContacts, numberOfContactsToDelete) {

    $scope.numberOfContactsToDelete = numberOfContactsToDelete;
    $scope.ok = function () {
        contactsService.deleteContacts(arrayOfContacts).then(function () {
            $modalInstance.close();
        });
    };
    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
}];