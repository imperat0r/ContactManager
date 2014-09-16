contactManager.controller("HomeController", ['$scope', 'contactsService','$timeout','$filter','$modal', function ($scope, contactsService,$timeout,$filter,$modal) {

    //PAGINATION AND SORTING
    $scope.currentPage = 0;
    $scope.pageSize = 2;
    $scope.predicate = "Id";
    $scope.reverse = true;
    $scope.calculateNumOfPages = function () {
        $scope.noOfPages = Math.ceil($scope.contacts.length / $scope.pageSize);
    }

    //GET SERVICE
    contactsService.getAllContacts().then(function (results) {
        angular.forEach(results, function (obj, index) {
            obj.checked = false;
        });
        $scope.contacts = results;
        $scope.calculateNumOfPages();    
    });

    //DEBOUNCE
    $scope.limit = function () {
        $timeout(function () {
            $scope.currentPage = 0;
            $scope.calculateNumOfPages();
        }, 100);
    };
    
    $scope.deletingIsReady = function () {
        $timeout(function () {
            if ($filter('filter')($scope.contacts, { checked: true }).length > 0 && $scope.contacts.length > 0)
                $scope.ShowDeletingButton = true;
            else
                $scope.ShowDeletingButton = false;
        }, 100);
    }
    
    $scope.deleteChecked = function () {

        var contactForDeleting = $filter('filter')($scope.contacts, { checked: true });
        var arrayOfContacts = [];
        angular.forEach(contactForDeleting, function (obj, index) {
            arrayOfContacts.push(obj.Id);
        });
        //OPEN MODAL AND PASS VALUES TO IT(resolve),DELETE ON SERVER
        var modalInstance = $modal.open({
            templateUrl: 'Scripts/app/templates/modalDeleteContacts.html',
            controller: ModalInstanceCtrl,
            resolve: {
                arrayOfContacts: function () { return arrayOfContacts;},
                numberOfContactsToDelete: function () {return arrayOfContacts.length;}
            }
        });
        //MODAL IS CLOSED WITH OK BUTTON, DELETE ON CLIENT
        modalInstance.result.then(function () {
            $timeout(function () {
                var conCount=0;
                angular.forEach(arrayOfContacts, function (idInArray) {
                    conCount++;
                    angular.forEach($scope.contacts, function (obj, index) {
                        if(obj.Id==idInArray)
                            $scope.contacts.splice(index, 1);
                        if (arrayOfContacts.length == conCount)
                            $scope.deletingIsReady();
                    })            
                });
                $scope.calculateNumOfPages();
                $scope.currentPage = 0;
            }, 100);
            angular.forEach($scope.contacts, function (obj, index) {
                obj.checked = false;
            });
            
        }, function () {

        });
    };
    

}]);