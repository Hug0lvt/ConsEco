<?php
use Psr\Http\Message\ResponseInterface as Response;
use Psr\Http\Message\ServerRequestInterface as Request;
use Slim\Factory\AppFactory;
use OpenApi\Annotations as OA;

/**
*   @OA\Info(title="My First API", version="0.1")
*/

$app = AppFactory::create();

$app->addBodyParsingMiddleware();
$app->addRoutingMiddleware();
$app->addErrorMiddleware(true, true, true);

/**
*   @OA\Get(path="/api/Banque",
*       @OA\Response(response="200", description="Succes")
*       @OA\Response(response="500", description="Bdd Error")
*   )
*/
$app->get('/Banque/', function(Request $request, Response $response){
    $query = "SELECT * FROM Banque";

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

$app->post('/Banque/FromId/', function(Request $request, Response $response,array $args){
    $id = $request->getParsedBody()["id"];
    $query = 'SELECT * FROM Banque WHERE nom IN (SELECT nomBanque FROM InscrBanque WHERE idInscrit=:id)';

    try{
        $db = new Database();
        $conn = $db->connect();

        $stmt = $conn->prepare($query);
        $stmt->bindValue(':id', $id, PDO::PARAM_STR);

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

$app->post('/Banque/add/', function(Request $request, Response $response, array $args){
    $nom = $request->getParsedBody()["nom"];
    $idInscrit = $request->getParsedBody()["idIscrit"];

    $query = "INSERT INTO InscrBanque (nomBanque, idInscrit) VALUES (:nom, :idInscrit) WHERE EXISTS (SELECT nom FROM Banque WHERE nom=:nom)";

    try{
        $db = new Database();
        $conn = $db->connect();

        $stmt = $conn->prepare($query);
        $stmt->bindValue(':nom', $nom, PDO::PARAM_STR);
        $stmt->bindValue(':idInscrit', $idInscrit, PDO::PARAM_STR);

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

$app->delete('/Banque/delete/', function (Request $request, Response $response, array $args) {
    $nom = $request->getParsedBody()["nom"];
    $idInscrit = $request->getParsedBody()["idIscrit"];

    $query = "DELETE FROM InscrBanque WHERE nom=:nom AND idInscrit=:idI";

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