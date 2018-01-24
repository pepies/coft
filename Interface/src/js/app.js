'use strict';

var app = angular.module('app', ['ngRoute', 'ngMaterial', 'ngAnimate', 'n3-line-chart', 'ng.httpLoader']); //'n3-line-chart'

app.config(['$routeProvider',
 function($routeProvider) {
  $routeProvider
  .when('/',
  {
    controller: 'MainController',
    templateUrl: 'views/first.php'
  })
  .when('/:id',
  {
      controller: 'StrediskoController',
      templateUrl: 'views/table.html'
  })
  .otherwise({ redirectTo: '/' });
}]);
//mainController have to be parent for subviews (background - class).