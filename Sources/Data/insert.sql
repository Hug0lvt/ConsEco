INSERT INTO Devise VALUES('EUR','EURO');
INSERT INTO Devise VALUES('USD','DOLLAR');
INSERT INTO Devise VALUES('GBP','Livre Sterling');
INSERT INTO Devise VALUES('JPY','YEN');
INSERT INTO Devise VALUES('AUD','DOLLAR AUSTRALIEN');
INSERT INTO Devise VALUES('NZD','DOLLAR NEO-ZELANDAIS');
INSERT INTO Devise VALUES('ZAR','RANd');


INSERT INTO Inscrit (nom,prenom,mail,mdp)VALUES('EVARD','LUCAS','lucasevard@gmail.com','Azerty12345678!');
INSERT INTO Inscrit (nom,prenom,mail,mdp)VALUES('MONCUL','STEPHANE','stef@gmail.com','Azerty12345678!');
INSERT INTO Inscrit (nom,prenom,mail,mdp)VALUES('MENFOUMETTOITOUTNU','RENAUD','renaudtoutnu@gmail.com','Azerty12345678!');
INSERT INTO Inscrit (nom,prenom,mail,mdp)VALUES('YOUVOI','BENJAMIN','BENJAMIN@gmail.com','Azerty12345678!');
INSERT INTO Inscrit (nom,prenom,mail,mdp)VALUES('TUBEAU','RAOUL','raoullacouille@gmail.com','Azerty12345678!');

INSERT INTO DeviseInscrit VALUES('EUR','1');
INSERT INTO DeviseInscrit VALUES('JPY','2');
INSERT INTO DeviseInscrit VALUES('USD','3');
INSERT INTO DeviseInscrit VALUES('NZD','4');


INSERT INtO Banque(nom,urlsite,urllogo) VALUES('BNP PARIBAS','mabanque','imagesitebnb.fr');
INSERT INtO Banque(nom,urlsite,urllogo) VALUES('CREDIT AGRICOLE','credit-agricole.fr','imageca');
INSERT INtO Banque(nom,urlsite,urllogo) VALUES('BANQUE POSTALE','labanquepostale.fr','imgbp');
INSERT INtO Banque(nom,urlsite,urllogo) VALUES('CAISSE D EPARGNE','caisse-epargne.fr','imgcaissedepargne');


INSERT INTO InscrBanque (nomBanque,idInscrit)VALUES('BNP PARIBAS','1');
INSERT INTO InscrBanque (nomBanque,idInscrit)VALUES('CREDIT AGRICOLE','2');
INSERT INTO InscrBanque (nomBanque,idInscrit)VALUES('BANQUE POSTALE','3');
INSERT INTO InscrBanque (nomBanque,idInscrit)VALUES('CAISSE D EPARGNE','4');


INSERT INTO Compte (nom,idInscritBanque)VALUES('LIVRET A','1');
INSERT INTO Compte (nom,idInscritBanque)VALUES('LIVRET A','2');
INSERT INTO Compte (nom,idInscritBanque)VALUES('LIVRET A','3');
INSERT INTO Compte (nom,idInscritBanque)VALUES('LIVRET A','4');
