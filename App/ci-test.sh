./until_log.sh dotnet 'Now listening on'
docker-compose exec jdk ./gradlew cucumber
docker-compose exec dotnet bash -c "kill $(docker-compose exec dotnet pidof dotnet)"
./until_log.sh dotnet 'e2e-coverage-done'
#cat coverage.cobertura.xml
docker compose logs dotnet
