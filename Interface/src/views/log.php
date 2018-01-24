<md-dialog aria-label="label modal">
	<md-toolbar>
        <div class="md-toolbar-tools">
            <h2>Prehrávač videa</h2>
            <span flex></span>
            <md-button class="md-icon-button" ng-click="cancel()">
                <md-icon md-svg-src="img/ic_close_24px.svg" aria-label="Yatvor dialog"></md-icon>
            </md-button>
        </div>
    </md-toolbar>
	<md-dialog-content>
	<?php
		$id = $_GET["id"];
		$s = $_GET["s"];
		$host = $_SERVER['HTTP_HOST'];
		$video = $s ."/video/".$id.".mp4";
		$xml = $s."/xml/".$id.".vtt";
		$path = $host."/".$video;
		echo '
		<div>
			<video id="video" controls autoplay preload="metadata">
			   <source src="../'.$video.'" type="video/mp4">
			   <track label="Vaha" kind="subtitles" srclang="en" src="../'.$xml.'" default>
			</video>
		</div>'; 
		echo "
			</md-dialog-content>
			<md-dialog-actions layout='row' layout-align='end center'>
				<md-button href='../".$video."' download class='md-raised md-default'>
					 <span class='glyphicon glyphicon-download-alt' aria-hidden='true'></span> video
				</md-button>
				<md-button href='../".$xml."' download class='md-raised md-default'>
					 <span class='glyphicon glyphicon-download-alt' aria-hidden='true'></span> váha
				</md-button>
			</md-dialog-actions>";
	?>
</md-dialog>