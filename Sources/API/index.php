<?php

require_once(__DIR__.'/config/Config.php');

require_once(__DIR__.'/config/Autoload.php');
Autoload::charger();

$router = new AltoRouter();
$router->map('GET|POST',"/","test");

$match=$router->match();

if(!$match){echo "404"; die;}

if($match){
    $cont = new Controller();
}
?>