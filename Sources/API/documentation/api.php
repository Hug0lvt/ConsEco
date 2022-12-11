<?php
require(__DIR__."/../vendor/autoload.php");
$openapi = \OpenApi\Generator::scan([__DIR__.'/../routes/Inscrit.php']);
//header('Content-Type: application/json');
echo $openapi->toJSON();
?>