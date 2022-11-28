<?php
require_once(__DIR__.'/config/Config.php');

require_once(__DIR__.'/config/Autoload.php');
Autoload::charger();

$url='';
if(isset($_GET['url'])){
    $url = explode('/',$_GET['url']);
}

$cont = new Controller($url);
?>