<?php

require_once(__DIR__.'/config/Config.php');

require_once(__DIR__.'/config/Autoload.php');
Autoload::charger();

$router = new AltoRouter();

$router->map( 'GET', '/', function() {
	echo "OUIIIII";
});

// map user details page
$router->map( 'GET', '/test/', function() {
    echo "NOOOOOOON";
});
?>