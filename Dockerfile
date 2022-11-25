FROM php:8.1-apache
RUN docker-php-ext-install mysqli pdo pdo_mysql && docker-php-ext-enable pdo_mysql
COPY ./Sources/API /var/www/html/
RUN cd ./Sources/Data
RUN mysql -u db_user -p db_database > tablewithgeneratedid.sql