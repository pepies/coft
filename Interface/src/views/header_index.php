<header class="navbar-fixed-top md-whiteframe-z1 col-md-12">
	<md-button class="noselect md-warn" href="sql/logout.php" aria-label="FAB">	
		<span class="glyphicon glyphicon-off vcenter" aria-hidden="true"></span>
		<?php session_start(); echo $_SESSION['username'];?>
	</md-button >
	<md-button data-toggle="modal" data-target="#add_user"> 
		<md-tooltip md-direction="bottom">Administrácia účtu</md-tooltip>
		<span class="btn-sm glyphicon glyphicon-user" aria-hidden="true"></span>
	</md-button>
	<md-button href="<?php echo "http://".$_SERVER['SERVER_NAME'].":5000/"; ?>" target="_blank"> 
		<md-tooltip md-direction="bottom">Server GUI</md-tooltip>
		<span class="btn-sm glyphicon glyphicon-hdd" aria-hidden="true"></span>
	</md-button>
	
	<md-button data-toggle="modal" data-target="#analyze"> 
		<md-tooltip md-direction="bottom">Sprárovať záznamy</md-tooltip>
		<span class="btn-sm glyphicon glyphicon-tasks" aria-hidden="true"></span>
	</md-button>

	<div class="right">	
	<md-button data-toggle="modal" class="md-icon-button launch" data-target="#add_stredisko">
		<md-tooltip md-direction="bottom">Pridať stredisko</md-tooltip>
		<span class="btn-sm glyphicon glyphicon-plus" aria-hidden="true"></span>
	</md-button>
	<md-button data-toggle="modal" class="md-icon-button launch" data-target="#delete_stredisko">
		<md-tooltip md-direction="bottom">Zmazať odkaz na stredisko</md-tooltip>
		<span class="btn-sm glyphicon glyphicon-minus" aria-hidden="true"></span>
	</md-button>
	</div>
</header>