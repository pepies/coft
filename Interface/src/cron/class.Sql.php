<?php
//Singleton class
class Sql
{
	private $config;
	private $_connection;
	private $_connection_strediska;
	private static $_instance; //The single instance
	private $_host;
	private $_username;
	private $_password;
	//private $_database = "forsesk";
	/*
	Get an instance of the Database
	@return Instance
	*/
	public static function getInstance()
	{
		if (!self::$_instance) { // If no instance then make one
			self::$_instance = new self();
		}
		return self::$_instance;
	}

	// Login to sql
	private function __construct()
	{
		$ini = parse_ini_file('./config.ini');
		$this->_host = $ini['db_host'];
		$this->_username = $ini['db_username'];
		$this->_password = $ini['db_password'];
		$this->_connection = new mysqli($this->_host, $this->_username,$this->_password);

		// Error handling
		if (mysqli_connect_error()) {
			trigger_error("Problém s prihlásením do databázy. Kontaktujte <i>pbrecska@gmail.com</i>." . E_USER_ERROR);
		}
	}

	// Magic method clone is empty to prevent duplication of connection
	private function __clone()
	{
	}

	// Get mysqli connection
	public function getConnection()
	{
		return $this->_connection;
	}
 
	public function __destruct()
	{
		static::$_instance = null;
		mysqli_close($this->_connection);
	}

	/**
	 * [load_into_array description]
	 * @param  [string] $table_name [stredisko]
	 * @return [array]             [array of Record_sql]
	 */
    public function load(string $table_name){	 //TO DO: Where timestamp < 2 mesiace
        active_log( "<br/>Spracovávam SQL záznamy");

        $this->_connection_strediska = new mysqli($this->_host, $this->_username, $this->_password, "forsesk");
		if(!($result = $this->_connection_strediska->query("SELECT * FROM zaznamy WHERE id_stredisko='$table_name'" , MYSQLI_USE_RESULT))){
			echo mysqli_error($this->_connection_strediska);
			echo "<br/>";
			die();
		}
        $i = 0;
        $db_col_array = array();
        while($rs = $result->fetch_array(MYSQLI_ASSOC)) {
            $db_col_array[$i++] = new Record_sql($rs["id"], $rs["datetime"], $rs["vaha"], $rs["status"]);
        }
        $this->_connection_strediska->close();
        active_log("<br/>Záznamy zo stredísk načítané");
        return $db_col_array;
    }
    /**
     * [insert_db description]
     * @param  array  $sql   [array of ]
     * @param  string $table [table name to import in]
     * @return [void]
     */
	public function insert_db(array $sql, string $table)
	{
		active_log("<br/>Odosielam do databázy<br/>");
		if ($this->_connection->error) {
			die("Nepodarilo sa nadviazať spojenie: " . $this->_connection->error);
		}
		foreach ($sql as $line) {
			if($line->obj_paired_brutto){
				$b = "'".$line->obj_paired_brutto->id."'";
			}else{
				$b = 'NULL';
			}
			if($line->obj_paired_tara){
				$t = "'".$line->obj_paired_tara->id."'";
			}else{
				$t = 'NULL';
			}
			$query = "INSERT INTO forsesk.SAP
			(`id_stredisko`, `PV`, `partner`, `partner_id`, `norma`, `material_nazov`,
			`material_cislo`, `spz`, `vodic`, `vazil`, `poznamka`,
			`id_paired_brutto`, `id_paired_tara`, `brutto_time`,`brutto_weight`,
			`tara_time`, `tara_weight`, `netto_time`,`netto_weight`) VALUES (
			
			'" . $table . "',
			'" . $line->PV . "',
			'" . $line->partner . "',
			'" . $line->partner_id . "',
			'" . $line->norma . "',
			'" . $line->material_nazov . "',
				
			'" . $line->material_cislo . "',
			'" . $line->spz . "',
			'" . $line->vodic . "',
			'" . $line->vazil . "',
			'" . $line->poznamka . "',
				
			" . $b . ",
			" . $t . ",
			'" . $this->datetime_to_string($line->brutto_time) . "',			
			'" . $line->brutto_weight . "',
				
			'" . $this->datetime_to_string($line->tara_time) . "',
			'" . $line->tara_weight . "',
			'" . $this->datetime_to_string($line->netto_time) . "',
			'" . $line->netto_weight . "'
			);";
			if(!($this->_connection->query($query))){
				echo mysqli_error($this->_connection);
				echo "<br/>";
				echo $query;
				echo "<br/>";
			}
		}
	}

	/**
	 * @args: datetime object
	 * @return: Mysql formated time
	 */
	private static function datetime_to_string($datetime)
	{
		if ($datetime != null) {
			if (is_string($datetime)) {
				$datetime = DateTime::createFromFormat('Y-m-d H:i:s', $datetime);
			}
			$datetime = date('Y-m-d H:i:s', date_timestamp_get($datetime));
			return $datetime;
		} else {
			return "null";
		}
	}

	public function login($password, $username)
	{
		$password = sha1($password);
		$query = "SELECT * FROM `forsesk`.admins WHERE `id`='$username' and `pw`='$password'";
		if (mysqli_num_rows($this->_connection->query($query)) == 0) {
			return false;
		} else {
			return true;
		}
	}
}
?>
