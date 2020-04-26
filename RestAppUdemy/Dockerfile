#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mysql:5.7.22
EXPOSE 3306
COPY ./RestAppUdemy/db/migrations/ /home/database/
COPY ./RestAppUdemy/db/datasets/ /home/database/
COPY ./RestAppUdemy/ci/init_database.sh /docker-entrypoint-initdb.d/init_database.sh

