app.factory('dataFactory', ['$http', '$route', function($http, $route){
    return {
        getData: function() {
            return $http.get('sql/data.php?table='+$route.current.params.id)
                .then(function (response) {
                    return response.data;
                });
        }
    }
}]);

app.factory('rawFactory', ['$http', '$route', function($http, $route){
    return {
        getData: function() {
            return $http.get('sql/raw.php?table='+$route.current.params.id)
                .then(function (response) {
                    return response.data;
                });
        }
    }
}]);
/*
app.filter('sumOfValue', function () {
    return function (data, key) {
        if (angular.isUndefined(data) && angular.isUndefined(key))
            return 0;        
        var sum = 0;
        
        angular.forEach(data,function(v,k){
            sum = sum + parseInt(v[key]);
        });  
        return sum;
    }
});*/