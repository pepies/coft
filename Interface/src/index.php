<?php
session_start();
require_once "cron/class.Sql.php";

if(isset($_POST['username'])){
	$username = $_POST['username'];
	$password = $_POST['pass'];

	$username = htmlspecialchars($username);
	$password = htmlspecialchars($password);
	if (Sql::getInstance()->login($password, $username)) {
		$_SESSION['username'] = $username;
		header("location: home.php");
	}else {
		$error = "Zlé prihlasovacie meno alebo heslo.</br>";
	}
}
?>

<!DOCTYPE>
<head>
	<title>coft</title>
	<meta http-equiv="Content-Language" content="sk" />
	<meta http-equiv="content-type" content="text/html; charset=UTF-8" />
	<meta name="keywords" content="zasys, camsoft" />
	<link rel="icon" href="img/fav.ico" type="image/x-icon">
	<link href="../bower_components/bootstrap/dist/css/bootstrap.css" rel="stylesheet" type="text/css">
	<style type="text/css">
		
		img{
			border:none;
			margin-top: 50px;
			margin-bottom: 50px;
		}
		.vcenter{
			text-align: center;
			margin: auto auto;
		}
		.wraper{
			color: rgb(100,100,100);
			width: 450px;
			height: 100vh;
			margin: 0 auto;
			padding-left: 25px;
			padding-right: 25px;
			background-color: rgba(0,0,0,0.1);
			text-align: center;
		}
		.input-group{
			width: 100%;
		}
		.form-control{
			background-color: rgba(255, 255, 255, 0.7);
			border-radius: 5px !important;
		}
	</style>
</head>
<body>
<script src="../bower_components/jquery/dist/jquery.js"></script>
<script src="../bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
	<div class="wraper">
		<div class="vcenter">
			<img src="img/logo.svg" />
			<br/>
			<form action=<?php echo $_SERVER['PHP_SELF'] ?> method="post" name='login' id='login'>
				<div class="input-group input-group-lg">
					<input type="text" class="form-control" name="username" placeholder="Meno" id="id">
				</div>	
				<br/>
				<div class="input-group input-group-lg">
					<input type="password" class="form-control" name="pass" placeholder="Heslo" id="pass">
				</div>
				<br/>
				<div class="btn-group">
					<input name="ok" value="Prihlásiť" type="submit"  class="btn btn-default btn-lg" />
				</div>
			</form> 
		<?php echo $error ?>
		</div>
	</div>
</body>
</html>