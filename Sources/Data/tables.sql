DROP TABLE if exists Planification;
DROP TABLE if exists Operation;
DROP TABLE if exists Echeancier;
DROP TABLE if exists Compte;
DROP TABLE if exists InscrBanque;
DROP TABLE if exists Banque;
DROP TABLE if exists DeviseInscrit;
DROP TABLE if exists Inscrit;
DROP TABLE if exists Devise;


CREATE TABLE Devise
(
    id char(3) PRIMARY KEY,
    nom varchar(20)
);

CREATE TABLE Inscrit
(
    id MEDIUMINT  PRIMARY KEY AUTO_INCREMENT,
    nom varchar(40),
    prenom varchar(40),
    mail varchar(40) UNIQUE,
    mdp varchar(40)
);

CREATE TABLE DeviseInscrit
(
    devise char(3),
    idInscrit MEDIUMINT UNIQUE,
    PRIMARY KEY(devise,idInscrit),
    FOREIGN KEY (devise) REFERENCES Devise(id),
    FOREIGN KEY (idInscrit) REFERENCES Inscrit(id)
);

CREATE TABLE Banque
(
    nom varchar(40) PRIMARY KEY,
    urlsite varchar(60),
    urllogo longblob
);

CREATE TABLE InscrBanque
(
    id MEDIUMINT PRIMARY KEY AUTO_INCREMENT,
    nomBanque varchar(40),
    idInscrit MEDIUMINT,
    UNIQUE(nomBanque,idInscrit),
    FOREIGN KEY (nomBanque) REFERENCES Banque(nom),
    FOREIGN KEY (idInscrit) REFERENCES Inscrit(id)
);

CREATE TABLE Compte
(
    id MEDIUMINT PRIMARY KEY AUTO_INCREMENT,
    nom varchar(40),
    idInscritBanque MEDIUMINT,
    FOREIGN KEY (idInscritBanque) REFERENCES InscrBanque(id),
    UNIQUE(idInscritBanque,nom)
);

CREATE TABLE Echeancier
(
    id MEDIUMINT PRIMARY KEY AUTO_INCREMENT,
    compte MEDIUMINT,
    nom varchar(40),
    montant numeric,
    dateO date,
    methodePayement varchar(20),
    isDebit boolean,
    tag varchar(30),
    CONSTRAINT ck_methEch CHECK (methodePayement IN ('Cb','Esp','Chq','Vir','Pre', 'None')),
    CONSTRAINT ck_tagEch CHECK (tag IN ('Alimentaire','Carburant','Habitation','Energie','Telephonie','Loisir','Restauration','Divers','Transport','Transaction','Santé')),
    FOREIGN KEY(compte) REFERENCES Compte(id)
);

CREATE TABLE Operation
(
    id MEDIUMINT PRIMARY KEY AUTO_INCREMENT,
    compte MEDIUMINT,
    nom varchar(40),
    montant numeric,
    dateO date,
    methodePayement varchar(20),
    isDebit boolean,
    fromBanque boolean,
    tag varchar(30),
    CONSTRAINT ck_methOpe CHECK (methodePayement IN ('Cb','Esp','Chq','Vir','Pre', 'None')),
    CONSTRAINT ck_tagOpe CHECK (tag IN ('Alimentaire','Carburant','Habitation','Energie','Telephonie','Loisir','Restauration','Divers','Transport','Transaction','Santé')),
    FOREIGN KEY(compte) REFERENCES Compte(id)
);

CREATE TABLE Planification
(
    id MEDIUMINT PRIMARY KEY AUTO_INCREMENT,
    compte MEDIUMINT,
    nom varchar(40),
    montant numeric,
    dateO date,
    methodePayement varchar(20),
    isDebit boolean,
    tag varchar(30),
    CONSTRAINT ck_methPla CHECK (methodePayement IN ('Cb','Esp','Chq','Vir','Pre', 'None')),
    CONSTRAINT ck_tagPla CHECK (tag IN ('Alimentaire','Carburant','Habitation','Energie','Telephonie','Loisir','Restauration','Divers','Transport','Transaction','Santé')),
    FOREIGN KEY(compte) REFERENCES Compte(id)
);