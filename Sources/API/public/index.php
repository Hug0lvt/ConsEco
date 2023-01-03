<?php

use Psr\Http\Message\ResponseInterface as Response;
use Psr\Http\Message\ServerRequestInterface as Request;
use Slim\Factory\AppFactory;

require __DIR__ .'/../vendor/autoload.php';
require __DIR__.'/../config/Database.php';

$app = AppFactory::create();

$app->get('/', function (Request $request, Response $response, $args) {
    $response->getBody()->write("Hello world!");
    return $response;
});

$app->get('/Inscrit/', function(Request $request, Response $response, $args){
    print('TEEEEST');
});

require __DIR__.'/../routes/Inscrit.php';
require __DIR__.'/../routes/Banque.php';

$app->run();
?>