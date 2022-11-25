<?php

require_once(__DIR__.'/config/Config.php');

require_once(__DIR__.'/config/Autoload.php');
Autoload::charger();

$router = new AltoRouter();

$router->map( 'GET|POST', '/', function() {
	echo "OUIIIII";
});

// map user details page
$router->map( 'GET|POST', '/test', function() {
    echo "NOOOOOOON";
});
?>