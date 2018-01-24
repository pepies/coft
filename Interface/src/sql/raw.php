 <?php

//header("Access-Control-Allow-Origin: *");
//header("Content-Type: application/json; charset=UTF-8");

 $table = $_GET['table'];
 if(isset($table)){
    $ini = parse_ini_file('./config.ini');
    $conn = new mysqli($ini['db_host'], $ini['db_username'], $ini['db_password'], "forsesk");

    $result = $conn->query(
        "SELECT * FROM zaznamy where id_stredisko='$table'
         ORDER BY UNIX_TIMESTAMP(datetime) DESC"
          , MYSQLI_USE_RESULT);

    $outp = "";
    while($rs = $result->fetch_array(MYSQLI_ASSOC)) {
        if ($outp != "") {$outp .= ",";}
        $outp .= '{';
        $outp .= '"id":"' . $rs["id"] . '",';
        $outp .= '"cas":"' . date( 'H:i', strtotime($rs["datetime"]) ) . '",';
        $outp .= '"rok":"' . date( 'j.n.Y', strtotime($rs["datetime"]) ) . '",';
        $outp .= '"vaha":"'. $rs["vaha"] . '"';
        $outp .= '}';
    }
    $outp ='['.$outp.']';
    $conn->close();
    echo($outp);
}else{
    echo "table is not defined";
 }
?>