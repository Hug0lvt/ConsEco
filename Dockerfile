FROM php:8.1-apache
RUN docker-php-ext-install mysqli pdo pdo_mysql && docker-php-ext-enable pdo_mysql
COPY ./Sources/API /var/www/html/
RUN mysql -u db_user -p db_database > https://codefirst.iut.uca.fr/git/ConsEcoTeam/ConsEco/src/branch/master/Sources/Data/tablewithgeneratedid.sql