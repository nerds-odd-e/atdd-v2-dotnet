set -e
docker-compose pull
docker-compose build
docker-compose up -d $(docker-compose config --services |  grep -v dotnet)
./until_log.sh mssql 'SQL Server is now ready for client connections'
./until_log.sh kafka 'Created topic'
docker-compose up -d dotnet

