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
*   @OA\Get(path="/api/Inscrit",
*       @OA\Response(response="200", description="Succes")
*       @OA\Response(response="500", description="Bdd Error")
*   )
*/
$app->get('/Inscrit/', function(Request $request, Response $response){
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

$app->post('/Inscrit/FromMail/', function(Request $request, Response $response,array $args){
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

$app->put('/Inscrit/UpdatePassword/', function(Request $request, Response $response, array $args){
    $mail = $request->getParsedBody()["email"];
    $password = $request->getParsedBody()["password"];
    $query = 'UPDATE Inscrit SET mdp=:password WHERE mail=:mail';

    try{
        $db = new Database();
        $conn = $db->connect();

        $stmt = $conn->prepare($query);
        $stmt->bindValue(':mail', $mail, PDO::PARAM_STR);
        $stmt->bindValue(':password', $password, PDO::PARAM_STR);

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

$app->post('/Inscrit/add/', function(Request $request, Response $response, array $args){
    $nom = $request->getParsedBody()["nom"];
    $prenom = $request->getParsedBody()["prenom"];
    $mail = $request->getParsedbody()["email"];
    $password = $request->getParsedBody()["password"];

    $query = "INSERT INTO Inscrit (nom, prenom, mail, mdp) VALUES (:nom, :prenom, :mail, :password);";

    try{
        $db = new Database();
        $conn = $db->connect();

        $stmt = $conn->prepare($query);
        $stmt->bindValue(':nom', $nom, PDO::PARAM_STR);
        $stmt->bindValue(':prenom', $prenom, PDO::PARAM_STR);
        $stmt->bindValue(':mail', $mail, PDO::PARAM_STR);
        $stmt->bindValue(':password', $password, PDO::PARAM_STR);

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
})
?>