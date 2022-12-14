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
    nom varchar(40),
    credit numeric,
    compte MEDIUMINT,
    debit numeric,
    dateE date,
    datecrea date,
    methodePayement varchar(20),
    CONSTRAINT ck_echan CHECK (methodePayement IN ('CB','Cheque','Espece','Prélevement')),
    FOREIGN KEY(compte) REFERENCES Compte(id),
    UNIQUE (datecrea,compte)
);

CREATE TABLE Operation
(
    id MEDIUMINT PRIMARY KEY AUTO_INCREMENT,
    nom varchar(40),
    credit numeric,
    compte MEDIUMINT,
    debit numeric,
    dateO date,
    datecrea date,
    methodePayement varchar(20),
    CONSTRAINT ck_methPaye CHECK (methodePayement IN ('CB','Cheque','Espece','Prélevement')),
    FOREIGN KEY(compte) REFERENCES Compte(id),
    UNIQUE (datecrea,compte)
);

CREATE TABLE Planification
(
    id MEDIUMINT PRIMARY KEY AUTO_INCREMENT,
    nom varchar(40),
    credit numeric,
    compte MEDIUMINT,
    debit numeric,
    dateP date,
    datecrea date,
    methodePayement varchar(20),
    CONSTRAINT ck_planif CHECK (methodePayement IN ('CB','Cheque','Espece','Prélevement')),
    FOREIGN KEY(compte) REFERENCES Compte(id),
    UNIQUE (datecrea,compte)
);