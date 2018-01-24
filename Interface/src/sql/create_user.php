<?php

$data = json_decode(file_get_contents("php://input"));
$id = $data->new_user;
$get_pw = $data->pw;
$pw = sha1($get_pw);
$ini = parse_ini_file('./config.ini');
	$conn = new mysqli($ini['db_host'], $ini['db_username'], $ini['db_password'], "forsesk");
// Check connection
	if ($conn->error) {
		die("Connection failed: " . $conn->error);
	} 
$sql = "INSERT INTO `forsesk`.`admins` (`uniq_id`, `id`, `pw`) VALUES (NULL, '$id', '$pw');";

if ($conn->query($sql)) {
		$arr = array('msg' => 'Užívateľ vytvorený úspešne!!!', 'error' => 'chyba:'.$conn->error);
        $jsn = json_encode($arr);
        print_r($jsn);
} else {
		$arr = array('msg' => "".$conn->error, 'error' => 'Prihlasovacie meno už existuje.'.$conn->error);
        $jsn = json_encode($arr);
        print_r($jsn);
}
$conn->close();

?>