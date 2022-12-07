<?php
    header('Acces-Control-Allow-Origin: *');
    header('Content-Type: application/json');

    include_once (__DIR__.'/../../config/Database.php');
    include_once (__DIR__.'/../../models/Inscrit.php');

    $database = new Database();
    $db = $database->connect();
    $inscrit = new Inscrit($db);

    $results = $inscrit->readMdpFromMail($mail);
    $num = $results->rowCount();

    if($num > 0){
        $inscrit_array = array();

        while($row = $results->fetch(PDO::FETCH_ASSOC)){
            extract($row);

            $inscrit_item = array(
                'id' => $id,
                'nom' => $nom,
                'prenom' => $prenom,
                'mail' => $mail,
                'mdp' => $mdp
            );
            array_push($inscrit_array, $inscrit_item);
        }
        echo json_encode($inscrit_array);
    } else {
        echo json_encode(array('message' => 'No Inscrit with mail='.$mail));
    }
?>