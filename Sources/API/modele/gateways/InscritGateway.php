<?php

class InscritGateway{
    private $con;

    function __construct($con){
        $this->con=$con;
    }

    public function selectAll(){
        $query="SELECT * FROM Inscrit;";
        $this->con->executeQueryWithoutParameters($query);
        return $this->con->getResults();
    }
}

?>