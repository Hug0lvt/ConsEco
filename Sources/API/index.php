<?php
require 'vendor/autoload.php';
$router = new AltoRouter();
$router->setBasePath('/~vincent/ConsEco/Sources/API');

$router->map( 'GET', '/', function(){
    echo 'Hello World';
});

$router->map('GET|POST','/Inscrit', function(){
    require(__DIR__.'/api/inscrit/read.php');
});

$router->map('GET','/Inscrit/[*:mail]', function($mail){
    require(__DIR__.'/api/inscrit/readFromMail.php');
});

$router->match('POST|GET','/Inscrit/add', function(){
    require(__DIR__.'/api/Inscrit/add.php');
});

$match = $router->match();

if($match!=null) {
    if( is_array($match) && is_callable( $match['target'] ) && isset($match['params']) ) {
        call_user_func_array( $match['target'], $match['params']); 
    }else{
        $match['target']();
    }
}
else {
    echo 'ERROR 404';
}
?>
