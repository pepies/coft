<?php
	class Record_file {
        //constants defining place of col in CSV file
        private const num_delimiter = '.';
        private const PV = 5;
        private const partner = 20;
        private const partner_id = 21;
        private const norma = 25;
        private const material_nazov = 28;
        private const material_cislo = 27;
        private const HmoBrutto = 31;
        private const DatBrutto = 32;
        private const CasBrutto = 33;
        private const HmoTara =   34;
        private const DatTara =   35;
        private const CasTara =   36;
        private const HmoNetto =  37;
        private const DatNetto =  39;
        private const CasNetto =  40;
        private const spz = 44;
        private const vodic = 46;
        private const vazil = 51;
        private const poznamka = 55;

        public $brutto_time;
        public $tara_time;
        public $netto_time;

        public $brutto_weight;
        public $tara_weight;
        public $netto_weight;

        public $obj_paired_brutto;
        public $obj_paired_tara;

		public $PV;
		public $partner;
		public $partner_id;
		public $norma;
		public $material_nazov;
		public $material_cislo;
		public $spz;
		public $vodic;
		public $vazil;
        public $poznamka;

        /**
         * Record_sap_info constructor.
         * @param $array File object
         */
        public function __construct($array) {
            if( isset($array[self::PV]) ){	
				$this -> PV = $array[self::PV];
				$this -> partner = $array[self::partner];
				$this -> partner_id = $array[self::partner_id];
				$this -> norma = $array[self::norma];
				$this -> material_nazov = $array[self::material_nazov];
				$this -> material_cislo = $array[self::material_cislo];
				$this -> spz = $array[self::spz];
				$this -> vodic = $array[self::vodic];
				$this -> vazil = $array[self::vazil];
				$this -> poznamka = $array[self::poznamka];

                $this -> obj_paired_brutto = null;
                $this -> obj_paired_tara = null;

                $this -> brutto_weight = str_replace(self::num_delimiter, '', $array[self::HmoBrutto]);
                $this -> tara_weight = str_replace(self::num_delimiter, '', $array[self::HmoTara]);
                $this -> netto_weight = str_replace(self::num_delimiter, '', $array[self::HmoNetto]);

                $this -> brutto_time = $this->parse_time($array[self::DatBrutto], $array[self::CasBrutto]);
                $this -> tara_time = $this->parse_time($array[self::DatTara], $array[self::CasTara]);
                $this -> netto_time = $this->parse_time($array[self::DatNetto], $array[self::CasNetto]);
            }
		}
        /**
         * table datetime to DateTime object
         * @param  string $datum date
         * @param  string $cas   time
         * @return object        DateTime for sql
         */
        private function parse_time($datum, $cas){
            if(!(is_string($datum) || is_string($cas))){
                echo "Cas nieje string. ";
                var_dump($datum);
                return null;
            }
            if (!preg_match("/(\d+)\/(\d+)\/(\d{4})/", $datum, $datum_out)) {
                return null; //mm - dd - YY
            }
            if (!preg_match("/(\d+):(\d+):(\d+)\s(\D+)/", $cas, $cas_out)) {
                return null;
            }
            if ($cas_out[4] == "odp." || $cas_out[4] == "PM") {
                if((int)$cas_out[1] != 12){
                    $cas_out[1] += 12;
                }
            }
            $datetime = $datum_out[3] . "-" . $datum_out[1] . "-" . $datum_out[2]
                . " " . $cas_out[1] . ":" . $cas_out[2] . ":" . $cas_out[3] ;
            return DateTime::createFromFormat('Y-m-d H:i:s', $datetime);
        }
	}
?>