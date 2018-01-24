<!-- Pridať stredisko -->
<div class="modal fade" id="add_stredisko" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Pridanie nového strediska</h4>
      </div>
      <form ng-controller="AddController">
      	<div class="modal-body">
      		<ul>
      			<li ng-repeat="error in errors"> <span class="label label-danger">{{ error}}</span> </li>
      		</ul>
      		<ul>
      			<li ng-repeat="msg in msgs"><span class="label label-success"> {{ msg }}</span></li>
      		</ul>
      		<div class="input-group">
      			<input type="text" ng-model="nazov" class="form-control" placeholder="Názov">
      		</div>
      		<div class="input-group">
            <input type="text" ng-model="strid"class="form-control" placeholder="unikátne ID *" size="10" pattern="[a-z]{4,10}">
            <small>* 4 až 10 písmen malej abecedy</small>
          </div>
        </div>
        <div class="modal-footer">
          <md-button class="md-raised" data-dismiss="modal">Zatvor</md-button>
         <md-button ng-click='Nahraj();' class="md-raised md-primary">Pridaj</md-button>
        </div>
      </form>
    </div>
  </div>
</div>
<!-- Vymazať stredisko
TO DO: Select list
 -->
<div class="modal fade" id="delete_stredisko" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Vymazanie strediska</h4>
      </div>
      <form ng-controller="DeleteController">
        <div class="modal-body">
          <ul>
            <li ng-repeat="error in errors"> <span class="label label-danger">{{ error}}</span> </li>
          </ul>
          <ul>
            <li ng-repeat="msg in msgs"><span class="label label-success"> {{ msg }}</span></li>
          </ul>
          <div class="input-group">
            <input type="text" ng-model="strid" class="form-control" placeholder="unikátne ID" size="10" pattern="[a-z]{4,10}">
          </div>
        </div>
        <div class="modal-footer">
          <md-button class="md-raised" data-dismiss="modal">Zatvor</md-button>
         <md-button ng-click='Vymaz();' class="md-raised md-primary">Vymaž</md-button>
        </div>
      </form>
    </div>
  </div>
</div>
<!-- Pridať používateľa / zmena hesla-->
<div class="modal fade" id="add_user" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title">Pridanie používateľa</h4>
      </div>
      <form ng-controller="NewUserController">
        <div class="modal-body">
          <ul>
            <li ng-repeat="error in errors"> <span class="label label-danger">{{ error}}</span> </li>
          </ul>
          <ul>
            <li ng-repeat="msg in msgs"><span class="label label-success"> {{ msg }}</span></li>
          </ul>
          <div class="input-group">
            <input type="text" ng-model="new_user" class="form-control" placeholder="Meno / ID" size="20">
          </div>
          <div class="input-group">
            <input type="password" ng-model="pw" class="form-control" placeholder="Heslo / PW" size="20">
          </div>
         <md-button ng-click='Nahraj();' class="md-raised md-primary">Pridaj</md-button>
        </div>
      </form>

      <div class="modal-header">
        <h4 class="modal-title">Zmena hesla používateľa <?php echo $_COOKIE['username']; ?></h4>
      </div>
      <form ng-controller="ChangePasswordController">
        <div class="modal-body">
          <ul>
            <li ng-repeat="error in errors"> <span class="label label-danger">{{ error}}</span> </li>
          </ul>
          <ul>
            <li ng-repeat="msg in msgs"><span class="label label-success"> {{ msg }}</span></li>
          </ul>
          <div class="input-group">
            <input type="password" ng-model="pw" class="form-control" placeholder="Nové Heslo / PW" size="20">
          </div>
          <md-button ng-click='Nahraj();' class="md-raised md-primary">Zmeň</md-button>
        </div>
        <div class="modal-footer">
         <md-button class="md-raised" data-dismiss="modal">Zatvor</md-button>
        </div>
      </form>
    </div>
  </div>
</div>
<!-- Analyzovať dáta -->
<div class="modal fade" id="analyze" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Analýza dát</h4>
      </div>
      <form id="formID" action="./cron/analyze.php" method="post" class="analyze" enctype="multipart/form-data">
        <div class="modal-body">
          <div class="form-group">
            <label for="post_file">CSV log</label>
            <div class="input-group">
                <input type="file" name="post_file" id="post_file" class="form-control" />
            </div>
            <label for="post_stredisko">Stredisko</label>
            <div class="input-group">
                <select class="form-control" name="post_stredisko" id="post_stredisko">
                <?php
                  $conn = new mysqli("localhost", "admin", "2594FireNet", "forsesk");
                  $result = $conn->query("SELECT * FROM stredisko");
                  while($rs = $result->fetch_array(MYSQLI_ASSOC)) {
                    echo "<option value=\"".$rs["id_stredisko"]."\">".$rs["meno"]."</option>";
                  }
                  $conn->close();
                ?>
                </select>
            </div>
            <label for="oddelovac">Oddelovač</label>
            <div class="input-group">
                <input type="text" name="oddelovac" id="oddelovac" value="," class="form-control" />
            </div>
            <small>Oddelovač buniek v *.csv súbore.</small><br/>
            <label for="rozdiel_cas">Rozdiel časový</label>
            <div class="input-group">
                <input type="text" name="rozdiel_cas" id="rozdiel_cas" value="15" placeholder="nekonečný" class="form-control" aria-describedby="min" />
                <span class="input-group-addon" id="min">min</span>
            </div>
                <small>Maximálny možná rozdiel medzi reálnym meraním a časom zadaným do vážneho lístka.</small><br/>
                <label for="rozdiel_vaha">Rozdiel hmotnostný</label>
            <div class="input-group">
                <input type="text" name="rozdiel_vaha" id="rozdiel_vaha" value="2000" placeholder="nekonečný" class="form-control" aria-describedby="kg" />
                <span class="input-group-addon" id="kg">kg</span>
            </div>
                <small>Maximálny možný rozdiel medzi reálnym meraním a váhou zadanou do vážneho lístka.</small>
                <div class="radio">
                <label><input type="radio" name="send" value="0" checked />Iba otestovať</label>
              </div>
              <div class="radio">
                <label><input type="radio" name="send" value="1" />Uložiť výstup</label>
              </div>       
          </div>
          <div class="modal-footer">
                <md-button class="md-raised" data-dismiss="modal">Zatvor okno</md-button>
                <md-button class="md-raised md-primary" type="submit"> Spusti </md-button>
                
          </div>  

          </div>
      </form>
    </div>
  </div>
</div>
<script>
var myForm = document.getElementById('formID');
myForm.onsubmit = function() {
    var w = window.open('about:blank','Popup_Window','toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,width=600,height=800,left = 312,top = 234');
    this.target = 'Popup_Window';
};
</script>
