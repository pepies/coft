<?php

$data = json_decode(file_get_contents("php://input"));
$table = $data->strid;

//$ini = parse_ini_file('./config.ini');
	// $conn = new mysqli($ini['db_host'], $ini['db_username'], $ini['db_password'], "forsesk");
	// $sql = "DROP TABLE ".$table;
  // $conn -> query($sql);

  // mysqli_select_db($conn ,"strediska");
  // $sql = "DROP TABLE ".$table;
  // $conn -> query($sql);

  mysqli_select_db($conn ,"forsesk");
  $sql = "DELETE FROM `stredisko` WHERE `id_stredisko` = '$table'";
  // mysql predpoklad: CONSTRAINS RESTRICTED TO delete all FK occurances.

if ($conn->query($sql) === TRUE) {
    $arr = array('msg' => "Stredisko s databázy vymazané úspešne!\n 
    Pre zmazanie kamerových záznamov a fotiek prosím použite NAS (port 5000).", 'error' => 'Connection failed');
        $jsn = json_encode($arr);
        print_r($jsn);
} else {
		$arr = array('msg' => "", 'error' => 'Chyba: '.$conn->error);
        $jsn = json_encode($arr);
        print_r($jsn);
}
$conn->close();

?>