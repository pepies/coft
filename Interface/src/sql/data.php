<?php
//header("Access-Control-Allow-Origin: *");
header('Connection: close');
//header("Content-Type: application/json; charset=UTF-8");
$table = $_GET['table'];
if(isset($table)) {
    $ini = parse_ini_file('./config.ini');
    $conn = new mysqli($ini['db_host'], $ini['db_username'], $ini['db_password']);

    // OLD
    // $result = $conn->query(
    //     "SELECT f.sql_id, f.PV, f.partner, f.partner_id, f.norma, f.material_nazov,
    //     f.material_cislo, f.spz, f.vodic, f.vazil, f.poznamka,

    //     f.brutto_time as d_brutto, f.brutto_weight as h_brutto, 
    //     sb.datetime as brutto_time_strd, sb.vaha as brutto_weight_strd, sb.id as id_brutto,

    //     f.tara_time as d_tara, f.tara_weight as h_tara,
    //     st.datetime as tara_time_strd, st.vaha as tara_weight_strd, st.id as id_tara, 

    //     f.netto_time, f.netto_weight 
    //     FROM forsesk.$table as f 
    //     INNER JOIN strediska.$table as sb ON f.id_paired_brutto=sb.id 
    //     INNER JOIN strediska.$table as st ON f.id_paired_tara=st.id
    //     ORDER BY f.brutto_time ASC"
    //     , MYSQLI_USE_RESULT
    // );
    $result = $conn->query(
        "SELECT f.sql_id, f.PV, f.partner, f.partner_id, f.norma, f.material_nazov,
        f.material_cislo, f.spz, f.vodic, f.vazil, f.poznamka,

        f.brutto_time as d_brutto, f.brutto_weight as h_brutto, 
        sb.datetime as brutto_time_strd, sb.vaha as brutto_weight_strd, sb.id as id_brutto,

        f.tara_time as d_tara, f.tara_weight as h_tara,
        st.datetime as tara_time_strd, st.vaha as tara_weight_strd, st.id as id_tara, 

        f.netto_time, f.netto_weight 
        FROM forsesk.SAP as f 
        INNER JOIN (
            SELECT id, vaha, datetime 
            FROM forsesk.zaznamy 
            WHERE id_stredisko='$table'
            ) as sb ON (f.id_paired_brutto=sb.id )
        INNER JOIN (
            SELECT id, vaha, datetime 
            FROM forsesk.zaznamy 
            WHERE id_stredisko='$table' 
            ) as st ON (f.id_paired_tara=st.id)
        WHERE f.id_stredisko='$table'
        ORDER BY f.brutto_time ASC"
        , MYSQLI_USE_RESULT
    );

    $outp = "";
    while ($rs = mysqli_fetch_object($result)) {
        if ($outp != "") {
            $outp .= ",";
        }
        $outp .= '{';
        $outp .= '"PV":"' . $rs->PV . '",';
        $outp .= '"partner":"' . $rs->partner . '",';
        $outp .= '"partner_id":"' . $rs->partner_id . '",';
        $outp .= '"norma":"' . $rs->norma . '",';
        $outp .= '"material_nazov":"' . $rs->material_nazov . '",';
        $outp .= '"material_cislo":"' . $rs->material_cislo . '",';

        $outp .= '"h_brutto":"' . $rs->h_brutto . '",';
        $outp .= '"d_brutto":"' . $rs->d_brutto . '",';
        $outp .= '"h_real_brutto":"' . $rs->brutto_weight_strd . '",';
        $outp .= '"id_real_brutto":"' . $rs->id_brutto . '",';
        $outp .= '"d_real_brutto":"' . $rs->brutto_time_strd . '",';
        $outp .= '"zobraz_d_real_brutto":"' . date('H:i', strtotime($rs->brutto_time_strd)) . '",';

        $outp .= '"h_tara":"' . $rs->h_tara . '",';
        $outp .= '"d_tara":"' . $rs->d_tara . '",';
        $outp .= '"id_real_tara":"' . $rs->id_tara . '",';
        $outp .= '"d_real_tara":"' . $rs->tara_time_strd . '",';
        $outp .= '"h_real_tara":"' . $rs->tara_weight_strd . '",';
        $outp .= '"zobraz_d_real_tara":"' . date('H:i', strtotime($rs->tara_time_strd)) . '",';

        $outp .= '"h_netto":"' . $rs->netto_weight . '",';
        $outp .= '"d_netto":"' . $rs->netto_time . '",';

        $outp .= '"spz":"' . $rs->spz . '",';
        $outp .= '"vodic":"' . $rs->vodic . '",';
        $outp .= '"vazil":"' . $rs->vazil . '",';
        $outp .= '"poznamka":"' . $rs->poznamka . '"';
        $outp .= '}';
    }
    echo '[' . $outp . ']';
    $conn->close();

}else{
    echo "table not set";
}

// select * from test where datediff(day, date, '03/19/2014') = 0
?>