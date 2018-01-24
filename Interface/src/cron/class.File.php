<?php
class File {

	public $name;
	public 	$data;
	public 	$size;
	private $tmp;
	public 	$type;
	private $ext;
	
	/**
	 * loads file contents
	 * @param [file] $file      [description]
	 * @param [string] $oddelovac [csv delimiter]
	 */
	public function __construct($file, $oddelovac){
		active_log("<br/>Načítavam súbor");

		$this -> name = $file['name'];
		$this -> size = $file['size'];
		$this -> tmp = $file['tmp_name'];
		$this -> type = $file['type'];   
		$this -> ext = pathinfo($this -> name, PATHINFO_EXTENSION);

		if(in_array($this -> ext, array("csv","txt")) === false){
			throw new Exception("Súbor musí byť vo formáte csv alebo txt", 1);
		}
		if($this -> size > 2097152){
			throw new Exception("Veľkosť súboru nesmie presiahnuť 2MB", 1);
		}		
		$this -> data = $this -> make_array($this -> name, $oddelovac);
		$this -> move_file();
		active_log("Súbor načítaný");
	}


 		/**
		*	args: name of SAP csv formated file
		*	@return: array of collumns
		*			false on fail
		*/
		private function make_array($file_name, $oddelovac) {	
			if(!$csvData = file_get_contents($file_name)){
				throw new Exception("Súbor s menom \"".$file_name."\" sa nenašiel", 1);
			}		
			$lines = explode(PHP_EOL, $csvData);
			$array = array();
			foreach ($lines as $line_num=>$line) {
				$zaznam = new Record_file(str_getcsv($line, $oddelovac));
				if( empty($zaznam->brutto_time) && empty($zaznam->tara_time) ){
					active_log( "Riadok č.".$line_num." má nezadané údaje.<br/>");
				}else{
					// push $zaznam to array.
					$array[] = $zaznam;
				}
			}
			return $array;
		}

		private function move_file(){
			$file = fopen("passed/".date_format(new datetime(),"Y.m.d_H.i.s").".csv", "w") 
			or die("Nedokážem vytvoriť súbor");
			fwrite($file, file_get_contents($this -> name));
			fclose($file);
			//unlink("queue/".$this -> name);
		}
	}
	?>