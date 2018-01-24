<?php
session_start();
	if (!isset($_SESSION['username'])) {
		$username = $_SESSION['username'];
		header("Location: sql/logout.php");
	}
?>
<!DOCTYPE html>
<html ng-app="app">
	<head>
		<title>coft</title>

		<meta name="viewport" content="width=device-width, initial-scale=1">
		<meta http-equiv="Content-Language" content="sk" />
		<meta http-equiv="content-type" content="text/html; charset=UTF-8" />
		<meta name="keywords" content="" />

		<link rel="shortcut icon" href="img/fav.ico">
		<link rel="stylesheet" href="../bower_components/bootstrap/dist/css/bootstrap.css" />
		<!-- bower:css -->
		<link rel="stylesheet" href="../bower_components/angular-material/angular-material.css" />
		<!-- endbower -->
		<link href="css/style.min.css" rel="stylesheet" type="text/css">
	</head>
	<body class="bg" data-ng-controller="MainController">
    <div ng-http-loader>
        <div class="splash trans">
            <div>Načítava sa obsah databáz.</div>
            <div class="spinner">
                <div class="dot1"></div>
                <div class="dot2"></div>
            </div>

        </div>
    </div>

		<div class="animate-container">
            <div data-ng-view ng-class="{slide: true, left: isDownwards, right: !isDownwards}"></div>
		</div>
		
		<!-- bower:js -->
		<script src="../bower_components/jquery/dist/jquery.min.js"></script>
		<script src="../bower_components/angular/angular.min.js"></script>
		<script src="../bower_components/angular-animate/angular-animate.min.js"></script>
		<script src="../bower_components/angular-aria/angular-aria.min.js"></script>
		<script src="../bower_components/angular-messages/angular-messages.min.js"></script>
		<script src="../bower_components/angular-material/angular-material.min.js"></script>
		<script src="../bower_components/angular-route/angular-route.min.js"></script>
		<script src="../bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
		<script src="../bower_components/webcomponentsjs/webcomponents.min.js"></script>
		<script src="../bower_components/promise-polyfill/Promise.min.js"></script>
		<script src="../bower_components/moment/moment.js"></script>
		<script src="../bower_components/d3/d3.min.js"></script>
		<script src="../bower_components/n3-line-chart/build/line-chart.min.js"></script>
		<script src="../bower_components/angular-http-loader/app/package/js/angular-http-loader.min.js"></script>
		<!-- endbower -->
		<script src="../bower_components/moment/locale/sk.js"></script>
		<script type="text/javascript">moment.locale('sk');</script>

		<script src="js/app.js"></script>
        <script src="js/controlers.js"></script>
        <script src="js/directives.js"></script>
   		<script src="js/services.js"></script>
   	</body>
</html>