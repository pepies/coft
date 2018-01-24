<?php
header( 'Content-type: text/html; charset=utf-8' );

function __autoload($class){
	require_once "class.".$class.".php";
}

ini_set('display_errors', 'On');
error_reporting(E_ALL | E_STRICT);
/***
 * Send output immediatly.
 */
function active_log($arg){
	echo $arg."</br>";
	ob_flush();
	flush();
}

	/*
	*   php.ini: file_uploads = On
	*
	*	Celý tento kód bude spúštaný pravidelne na spojenie SAP a SQL záznamov.
	*	TO DO: Po skončení presunie / uloží súbor ".csv" do priečinka passed.
	*/
	
new Main();
class Main {
		public function __construct(){
				define("max_time_diff", 60*$_POST['rozdiel_cas']);//(sec) 
				define("max_weigth_diff", $_POST['rozdiel_vaha']); 	//(kg)

				echo "<b> Stredisko: ".$_POST['post_stredisko']."</b>";
				if(empty($_POST['rozdiel_cas'])){
					$_POST['rozdiel_cas'] = INF;
				}
				if(empty($_POST['rozdiel_vaha'])){
					$_POST['rozdiel_vaha'] = INF;
				}
				$this->main();
		}

		private function main(){
			try {
				$file = new File($_FILES['post_file'], $_POST['oddelovac']);
				$strediska_data = Sql::getInstance()->load($_POST['post_stredisko']);
				$pair = new Pair($file->data, $strediska_data, true);
				if($_POST["send"]=='1'){
					Sql::getInstance()->insert_db($pair->paired, $_POST['post_stredisko']);
				}elseif($_POST["send"]=='0'){
					$pair->print_table();
				}
				
			}catch (Exception $e) {
				echo "analyze.php:" . $e;
			}finally{
				active_log("</br>Koniec");
			}
		}
}
?>