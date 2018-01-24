<?php

$data = json_decode(file_get_contents("php://input"));
$nazov = $data->nazov;
$table = $data->strid;
$ini = parse_ini_file('./config.ini');
	$conn = new mysqli($ini['db_host'], $ini['db_username'], $ini['db_password'], "forsesk");
	$sql = ""; // ADD text from file
$conn -> query($sql);

mysqli_select_db($conn ,"strediska");
$sql = "CREATE TABLE IF NOT EXISTS `".$table."` (
    `id` varchar(15) NOT NULL,
    `datetime` datetime NOT NULL,
    `vaha` int(10) NOT NULL,
    `status` tinyint(1) unsigned NOT NULL
  ) ENGINE=InnoDB AUTO_INCREMENT=0 DEFAULT CHARSET=utf8;";
$conn -> query($sql);

$sql = "ALTER TABLE `".$table."` ADD PRIMARY KEY (`id`),
        ADD UNIQUE KEY `id` (`id`);";
$conn -> query($sql);

mysqli_select_db($conn ,"forsesk");

// Check connection
	if ($conn->error) {
		die("Connection failed: " . $conn->error);
	} 
	$sql = "INSERT INTO `forsesk`.`stredisko` (`id_strediska`, `meno`) VALUES ('".$table."', '".$nazov."');";

if ($conn->query($sql) === TRUE) {
		$arr = array('msg' => "Stredisko vytvorené úspešne! Prosím použite REFRESH stránky (F5).", 'error' => 'Connection failed');
        $jsn = json_encode($arr);
        print_r($jsn);
} else {
		$arr = array('msg' => "", 'error' => 'Chyba pri vytváraní strediska.'.$conn->error);
        $jsn = json_encode($arr);
        print_r($jsn);
}
$conn->close();

?>