<?php
$data = json_decode(file_get_contents("php://input"));
$get_pw = mysql_real_escape_string($data->pw);
$pw = sha1($get_pw);
$ini = parse_ini_file('./config.ini');
$conn = new mysqli($ini['db_host'], $ini['db_username'], $ini['db_password'], "forsesk");
// Check connection
if ($conn->connect_error) {
	die("Connection failed: " . $conn->connect_error);
} 
$sql = "UPDATE `forsesk`.`admins` SET `pw` = ".$pw." WHERE `admins`.`id` = '".$_COOKIE['username']."';";
$conn->query($sql);
if ($conn->query($sql) === TRUE) {
	$arr = array('msg' => 'Heslo bolo zmenené úspešne!!!', 'error' => '');
    $jsn = json_encode($arr);
    print_r($jsn);
} else {
	$arr = array('msg' => "", 'error' => 'Neočakávaná chyba.');
    $jsn = json_encode($arr);
    print_r($jsn);
}
$conn->close();
?>