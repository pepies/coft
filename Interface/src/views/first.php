<div ng-include src="'views/header_index.php'"></div>
<div ng-include src="'views/modals.php'"></div>

<!-- BODY -->
<div class="float_left padding">
</div>

<div class="menu-items md-whiteframe-z5 right">
<?php
  function status($dbtime){

  	$diff = time() - strtotime($dbtime);
    if ( $diff < 1000) {
      return "online";
    }else{
      return "offline";
    }
  }
  $conn = new mysqli("localhost", "admin", "2594FireNet", "forsesk");
  $result = $conn->query("SELECT * FROM stredisko");

  while($rs = $result->fetch_array(MYSQLI_ASSOC)) {
    echo "
    <md-button 
      class=\"menu-item right ".
      status($rs['status'] ).
      "\"data-ng-click=\"go('".$rs["id_stredisko"]."')\">
      ".$rs["meno"]."
    </md-button>";
  }
  $conn->close();
?>
</div>