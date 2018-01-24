'use strict';

app.controller('MainController', function($scope, $location){
  var oldLocation = '';
  $scope.$on('$routeChangeStart', function(angularEvent, next) {
    var isDownwards = true;
    if (next && next.$$route) {
      var newLocation = next.$$route.originalPath;
      if (oldLocation !== newLocation && oldLocation.indexOf(newLocation) !== -1) {
        isDownwards = false;
      }
      oldLocation = newLocation;
    }
    $scope.isDownwards = isDownwards;
  });

//navigation functions
  $scope.back = function() {
    window.history.back();
  };
  $scope.go = function(view){
    $location.path(view);
  };


});

app.controller('StrediskoController', function($scope, $routeParams, $mdSidenav, $mdDialog, $timeout, dataFactory, rawFactory){
    $scope.id = $routeParams.id;
    $scope.day = new Date();
    $scope.loadingRight = true;
    $scope.loadingData = true;
    $timeout(function(){
        dataFactory.getData().then(function(value){
            $scope.loadingData = false;
            $scope.files = value;
        });
    }, 1000); //timeout for soft translation from prev. view



    /****  SIDE NAV *****/
    $scope.toggleRight = function() {
        $mdSidenav('right')
            .toggle()
            .then(function () {
                rawFactory.getData().then(function(value){
                    $scope.loadingRight = false;
                    $scope.rightData  = value;
                });
            });
    };
    $scope.close = function () {
        $mdSidenav('right').close();
    };
  $scope.showLog = function(ev, id) {
      $mdDialog.show({
      controller: DialogController,
      templateUrl: 'views/log.php?id='+id+'&s='+$scope.id,
      parent: angular.element(document.body),
      targetEvent: ev
      });
    };
  });

  function DialogController($scope, $mdDialog) {
    $scope.cancel = function() {
      $mdDialog.cancel();
    };
}

app.controller('GrafController', function($scope, dataFactory){
  dataFactory.getData(function(cb){
    $scope.data = cb; 
    $scope.data.forEach(function(row) {
      row.d_real_brutto = new Date(row.d_real_brutto);  
    });
    $scope.options = {
      axes: {
        x: {
          key: 'd_real_brutto',
          type: "date"
        }
      },
      series: [
      {
        y: "h_real_brutto",
        label: "Nameraná váha brutto",
        type: "line",
        color: "#17becf"
      }
      ],
      tooltip: {
        mode: "scrubber", formatter: function(x, d_real_brutto, series) {return d_real_brutto ;}
      }
    };
  });
});

app.controller('BottomSheetExample', function($scope, $mdBottomSheet) {
  $scope.showGridBottomSheet = function($event) {
    $mdBottomSheet.show({
      templateUrl: 'views/bottom.php'
    });
  };
});

app.controller('NewUserController',  function($scope, $http) {
                $scope.errors = [];
                $scope.msgs = [];
 
                $scope.Nahraj = function() {
 
                    $scope.errors.splice(0, $scope.errors.length); // remove all error messages
                    $scope.msgs.splice(0, $scope.msgs.length);
 
                    $http.post('sql/create_user.php',
                     {'new_user': $scope.new_user, 'pw': $scope.pw})
                      .success(function(data, status, headers, config) {
                        if (data.msg != '')
                        {
                            $scope.msgs.push(data.msg);
                        }
                        else
                        {
                            $scope.errors.push(data.error);
                        }
                    }).error(function(data, status) { 
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.
                        $scope.errors.push(status);
                    });
                }
            });
app.controller('ChangePasswordController', function($scope, $http) {
                $scope.errors = [];
                $scope.msgs = [];
 
                $scope.Nahraj = function() {
 
                    $scope.errors.splice(0, $scope.errors.length); // remove all error messages
                    $scope.msgs.splice(0, $scope.msgs.length);
 
                    $http.post('sql/change_password.php', {'pw': $scope.pw}
                    ).success(function(data, status, headers, config) {
                        if (data.msg != '')
                        {
                            $scope.msgs.push(data.msg);
                        }
                        else
                        {
                            $scope.errors.push(data.error);
                        }
                    }).error(function(data, status) { // called asynchronously if an error occurs
                                                      // or server returns response with an error status.
                        $scope.errors.push(status);
                    });
                }
});

app.controller('AddController',  function($scope, $http) {
                $scope.errors = [];
                $scope.msgs = [];
 
                $scope.Nahraj = function() {
 
                    $scope.errors.splice(0, $scope.errors.length); // remove all error messages
                    $scope.msgs.splice(0, $scope.msgs.length);
 
                    $http.post('sql/create_stredisko.php', {'nazov': $scope.nazov, 'strid': $scope.strid}
                    ).success(function(data, status, headers, config) {
                        if (data.msg != '')
                        {
                            $scope.msgs.push(data.msg);
                        }
                        else
                        {
                            $scope.errors.push(data.error);
                        }
                    }).error(function(data, status) { // called asynchronously if an error occurs
// or server returns response with an error status.
                        $scope.errors.push(status);
                    });
              }
});
app.controller('DeleteController',  function($scope, $http) {
                $scope.errors = [];
                $scope.msgs = [];
                
                $scope.Vymaz = function() {
 
                    $scope.errors.splice(0, $scope.errors.length); // remove all error messages
                    $scope.msgs.splice(0, $scope.msgs.length);
 
                    $http.post('sql/delete.php', {'strid': $scope.strid}
                    ).success(function(data, status, headers, config) {
                        if (data.msg != '')
                        {
                            $scope.msgs.push(data.msg);
                        }
                        else
                        {
                            $scope.errors.push(data.error);
                        }
                    }).error(function(data, status) { // called asynchronously if an error occurs
                            // or server returns response with an error status.
                        $scope.errors.push(status);
                    });
              }
});
