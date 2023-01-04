<?php
use Psr\Http\Message\ResponseInterface as Response;
use Psr\Http\Message\ServerRequestInterface as Request;
use Slim\Factory\AppFactory;
use OpenApi\Annotations as OA;

/**
*   @OA\Info(title="My First API", version="0.1")
*/

$app->addBodyParsingMiddleware();
$app->addRoutingMiddleware();
$app->addErrorMiddleware(true, true, true);

/**
*   @OA\Get(path="/api/Compte",
*       @OA\Response(response="200", description="Succes")
*       @OA\Response(response="500", description="Bdd Error")
*   )
*/

$app->post('/Compte/FromIdInscrit/', function(Request $request, Response $response,array $args){
    $idInscrit = $request->getParsedBody()["id"];
    $query = 'SELECT * FROM Compte WHERE idInscritBanque=:id';

    try{
        $db = new Database();
        $conn = $db->connect();

        $stmt = $conn->prepare($query);
        $stmt->bindValue(':id', $idInscrit, PDO::PARAM_STR);

        $stmt->execute();
        $compte = $stmt->fetchAll(PDO::FETCH_OBJ);
        
        $db = null;
        $response->getBody()->write(json_encode($compte));
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

$app->post('/Compte/add/', function(Request $request, Response $response, array $args){
    $nom = $request->getParsedBody()["nom"];
    $idInscrit = $request->getParsedBody()["idInscrit"];

    $query = "INSERT INTO Compte (nom, idInscritBanque) VALUES (:nom, :idI)";

    try{
        $db = new Database();
        $conn = $db->connect();

        $stmt = $conn->prepare($query);
        $stmt->bindValue(':nom', $nom, PDO::PARAM_STR);
        $stmt->bindValue(':idI', $idInscrit, PDO::PARAM_STR);

        $result = $stmt->execute();
        
        $db = null;
        $response->getBody()->write(json_encode($result));
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

$app->delete('/Compte/delete/', function (Request $request, Response $response, array $args) {
    $nom = $request->getParsedBody()["nom"];
    $idInscrit = $request->getParsedBody()["idInscrit"];

    $query = "DELETE FROM Compte WHERE nom=:nom AND idInscritBanque=:idI";

    try{
        $db = new Database();
        $conn = $db->connect();

        $stmt = $conn->prepare($query);
        $stmt->bindValue(':nom', $nom, PDO::PARAM_STR);
        $stmt->bindValue(':idI', $idInscrit, PDO::PARAM_STR);

        $result = $stmt->execute();

        $db = null;
        $response->getBody()->write(json_encode($result));
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