<?php
use Psr\Http\Message\ResponseInterface as Response;
use Psr\Http\Message\ServerRequestInterface as Request;
use Slim\Factory\AppFactory;

$app = AppFactory::create();

$app->get('/Inscrit', function(Request $request, Response $response){
    $query = "SELECT * FROM Inscrit";

    try{
        $db = new Database();
        $conn = $db->connect();

        $stmt = $conn->query($query);
        $inscrits = $stmt->fetchAll(PDO::FETCH_OBJ);

        $db = null;
        $response->getBody()->write(json_encode($inscrits));
        return $response
            ->withHeader('content-type', 'application/json')
            ->withStatus(200);
    } catch(PDOException $e){
        $error = array("message" => $e->getMessage());
        
        $response->getBody()->write(json_encode($error));
        return $response
            ->withHeader('content-type', 'application/json')
            ->withStatus(500);
    }
});

$app->post('/Inscrit/one', function(Request $request, Response $response,array $args){
    $mail = $request->getParsedBody()["email"];
    $query = 'SELECT * FROM Inscrit WHERE mail=:mail';

    try{
        $db = new Database();
        $conn = $db->connect();

        $stmt = $conn->prepare($query);
        $stmt->bindValue(':mail', $mail, PDO::PARAM_STR);

        $stmt->execute();
        $inscrit = $stmt->fetchAll(PDO::FETCH_OBJ);
        
        $db = null;
        $response->getBody()->write(json_encode($inscrit));
        return $response
            ->withHeader('content-type', 'application/json')
            ->withStatus(200);
    } catch(PDOException $e){
        $error = array("message" => $e->getMessage());
        
        $response->getBody()->write(json_encode($error));
        return $response
            ->withHeader('content-type', 'application/json')
            ->withStatus(500);
    }
});
?>