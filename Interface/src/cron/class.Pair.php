<?php
class pair {
    /**
     * [$paired array of all records]
     * @var [array of Record_sql]
     */
    public $paired = array();
    

    function __construct($sap_array, $strediska)
    {
       $this->paired = $this->pair($sap_array, $strediska);
    }

    /**
     * @param  [array] $sap_array   [array full of Record_sap]
     * @param  [array] $strediska   [array full of Record_sql]
     * @return [array]              [$sap_array filled]
     */
    private function pair($sap_array, $strediska){
        foreach ($sap_array as $sap_obj) {
            $tara = $brutto = array();
            // Find all log in between const(diff) seconds.
            foreach ($strediska as $strd_obj){
                $b = $this->diff_in_sec($strd_obj->datetime, $sap_obj->brutto_time);
                if ( $b <= constant("max_time_diff") ) {
                    if($strd_obj)
                    array_push($brutto, $strd_obj);
                }
                $t = $this->diff_in_sec($strd_obj->datetime, $sap_obj->tara_time);
                if( $t <= constant("max_time_diff") ){
                    if($strd_obj)
                    array_push($tara, $strd_obj);
                }
            }
            $sap_obj->obj_paired_brutto = $this->find_closest_kg($brutto, $sap_obj->brutto_weight);
            $sap_obj->obj_paired_tara = $this->find_closest_kg($tara, $sap_obj->tara_weight);
            // Truncate array
            $tara = $brutto = array();
        }
        return $sap_array;
    }

    public function print_table(){
        $table = "";
        $table .= "<table border='0' cellpadding='30'>";
        $table .= "<th>BRUTTO<br/>Zaznamenaná ~ Zo súbou</th>";
        $table .= " <th>TARA<br/>Zaznamenaná ~ Zo súbou</th>";
        foreach($this->paired as $p){
            $table .= "<tr>";

            if($p->obj_paired_brutto != null && $p->brutto_weight != null){
            $table .= "<td style='background-color: " . $this->color($p->obj_paired_brutto->vaha, $p->brutto_weight) . ";'><b>" .
                $p->obj_paired_brutto->vaha . " ~ " . $p->brutto_weight . "</b><br/>" .
                $p->obj_paired_brutto->datetime->format('H:i:s') . " ~ " . $p->brutto_time->format('H:i:s') .
                "</td>";
            }
            if($p->obj_paired_tara != null && $p->tara_weight != null){
            $table .= "<td style='background-color: " . $this->color($p->obj_paired_tara->vaha, $p->tara_weight) . ";'><b>" .
                $p->obj_paired_tara->vaha . " ~ " . $p->tara_weight . "</b><br/>" .
                $p->obj_paired_tara->datetime->format('H:i:s') . " ~ " . $p->tara_time->format('H:i:s') .
                "</td>";
            }
                $table.="</tr>";          
        }
        $table .= "</table>";
        echo $table;
    }

    /**
     * @param $array array of Record_stredisk
     * @param $sap - Record_sap object
     * @return closest Record_sql Object - not using form parameter, yet !
     */
    private function find_closest_kg($strediska, $vaha){
        $out = NULL;
        foreach ($strediska as $stredisko_obj) {
            $diff = abs($vaha - $stredisko_obj->vaha);
            if($stredisko_obj->diff >= $diff){
                $stredisko_obj->diff = $diff;
                $out = $stredisko_obj;
            }
        }
        return $out;
    }


    /**
     * [diff between 2 times]
     * @param  [datetime] $first  [description]
     * @param  [datetime] $second [description]
     * @return [int/bool]         [false on wrong input params]
     */
    private function diff_in_sec($first, $second){
        if( is_null($first)  || is_bool($first) || is_bool($second) ||is_null($second)){
            return INF;
        }
        // TRUE indicates that the interval/difference MUST be positive. Default is FALSE
        $difference = date_diff($first, $second, false); 
        
        if ($difference === false || $difference->invert==1){
            return INF;
        }
        $seconds = (int)$difference->s + $difference->i*60 + $difference->h*3600 + $difference->days*86400;
        if ($seconds == 0) {
            return 1;
        }else{
            return $seconds;    
        }
    }
    /**
     * [color class for tyble background]
     * @param  [int] $first  [vaha prveho]
     * @param  [int] $second [vaha druheho]
     * @return [string]         [CSS color type]
     */
    private function color($first, $second){
        $diff = abs($first - $second);
        if($diff > 100){
            return "#f45a5a"; //red
        }elseif($diff == 0){
            return "7bfc58"; //green
        }else{
            return "f5f76a"; //yellow
        }
    }
}
?>