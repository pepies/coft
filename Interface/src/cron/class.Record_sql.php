<?php
	class Record_sql {

		public $id;
		public $datetime;
		public $vaha;
		public $status;
		public $diff = INF;
	
		public function __construct($arg_id, $arg_datetime, $arg_vaha, $arg_status){
 			$this-> id = $arg_id;
 			$this-> datetime = DateTime::createFromFormat('Y-m-d H:i:s', $arg_datetime);
 			$this-> vaha = $arg_vaha;
 			$this -> status = $arg_status;
 		}
	}
?>