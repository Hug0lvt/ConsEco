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
*   @OA\Get(path="/api/Operation",
*       @OA\Response(response="200", description="Succes")
*       @OA\Response(response="500", description="Bdd Error")
*   )
*/

$app->post('/Operation/FromIdCompte/', function(Request $request, Response $response,array $args){
    $idCompte = $request->getParsedBody()["id"];
    $query = 'SELECT * FROM Operation WHERE compte=:id';

    try{
        $db = new Database();
        $conn = $db->connect();

        $stmt = $conn->prepare($query);
        $stmt->bindValue(':id', $idCompte, PDO::PARAM_STR);

        $stmt->execute();
        $ope = $stmt->fetchAll(PDO::FETCH_OBJ);
        
        $db = null;
        $response->getBody()->write(json_encode($ope));
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

$app->post('/Operation/add/', function(Request $request, Response $response, array $args){
    $compte = $request->getParsedBody()["compte"];
    $nom = $request->getParsedBody()["nom"];
    $montant = $request->getParsedBody()["montant"];
    $dateO = $request->getParsedBody()["dateO"];
    $methodePayement = $request->getParsedBody()["methodePayement"];
    $isDebit = $request->getParsedBody()["isDebit"];

    $query = "INSERT INTO Operation (compte, nom, montant, dateO, methodePayement, isDebit) SELECT :compte,:nom,:montant, STR_TO_DATE(:dateO, '%d/%m/%Y %H:%i:%s' ), :methodePayement, :isD;";
    try{
        $db = new Database();
        $conn = $db->connect();

        $stmt = $conn->prepare($query);
        $stmt->bindValue(':compte', $compte, PDO::PARAM_STR);
        $stmt->bindValue(':nom', $nom, PDO::PARAM_STR);
        $stmt->bindValue(':montant', $montant, PDO::PARAM_STR);
        $stmt->bindValue(':dateO', $dateO, PDO::PARAM_STR);
        $stmt->bindValue(':methodePayement', $methodePayement, PDO::PARAM_STR);
        $stmt->bindValue(':isD', $isDebit, PDO::PARAM_BOOL);

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

$app->delete('/Operation/delete/', function (Request $request, Response $response, array $args) {
    $compte = $request->getParsedBody()["compte"];
    $nom = $request->getParsedBody()["nom"];

    $query = "DELETE FROM Operation WHERE compte=:compte AND nom=:nom";

    try{
        $db = new Database();
        $conn = $db->connect();

        $stmt = $conn->prepare($query);
        $stmt->bindValue(':compte', $compte, PDO::PARAM_STR);
        $stmt->bindValue(':nom', $nom, PDO::PARAM_STR);

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