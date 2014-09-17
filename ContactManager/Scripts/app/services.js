contactManager.factory('contactsService',['$http','$q', function ($http, $q) {

    var _getAllContacts = function () {
        var deferred = $q.defer();
        $http.post(ROOT + 'Contact/GetAllContacts').
          then(function (data, status, headers, config) {
              deferred.resolve(data.data);
          }, function () {
              deferred.reject();
          });
        return deferred.promise;
    }
    var _deleteContacts = function (arrayOfContacts) {
        var deferred = $q.defer();
        var dataString = {
            arrayOfContacts: arrayOfContacts
        }

        $http.post(ROOT + 'Contact/DeleteContacts', dataString, { cache: false }).
           then(function (data, status, headers, config) {
               deferred.resolve();
           }, function () {
               deferred.reject();
           });
        return deferred.promise;

    }

    var _addContact = function (contactToAdd) {
        var deferred = $q.defer();
        var dataString = {
            contactToAdd: contactToAdd
        }
        $http.post(ROOT + 'Contact/AddContact', dataString, { cache: false }).
           then(function (data, status, headers, config) {
               deferred.resolve();
           }, function () {
               deferred.reject();
           });
        return deferred.promise;

    }

    var _getContact = function (id) {
        var deferred = $q.defer();
        var dataString = {
            id: id
        }
        $http.post(ROOT + 'Contact/GetContact', dataString, { cache: false }).
           then(function (data, status, headers, config) {
               deferred.resolve(data.data);
           }, function () {
               deferred.reject();
           });
        return deferred.promise;

    }
    var _updateContact = function (contact) {
        var deferred = $q.defer();
        var dataString = {
            contact: contact
        }
        $http.post(ROOT + 'Contact/UpdateContact', dataString, { cache: false }).
           then(function (data, status, headers, config) {
               deferred.resolve(data.data);
           }, function () {
               deferred.reject();
           });
        return deferred.promise;
    }
    var _getTags = function () {
        var deferred = $q.defer();
        $http.post(ROOT + 'Contact/GetTags', { cache: false }).
           then(function (data, status, headers, config) {
               deferred.resolve(data.data);
           }, function () {
               deferred.reject();
           });
        return deferred.promise;
    }
    var _getAllContactsWithTags = function (arrayOfTags) {
        var deferred = $q.defer();
        var dataString = {
            arrayOfTags: arrayOfTags
        }
        $http.post(ROOT + 'Contact/GetAllContactsWithTags', dataString, { cache: false }).
           then(function (data, status, headers, config) {
               deferred.resolve(data.data);
           }, function () {
               deferred.reject();
           });
        return deferred.promise;
    }


    return {
        getAllContacts: _getAllContacts,
        deleteContacts: _deleteContacts,
        addContact: _addContact,
        getContact: _getContact,
        updateContact: _updateContact,
        getTags: _getTags,
        getAllContactsWithTags: _getAllContactsWithTags
    }
      

}]);