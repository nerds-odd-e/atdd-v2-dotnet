set -x
dotnet build
dotnet tool install --global coverlet.console
dotnet tool install --global dotnet-reportgenerator-globaltool
export PATH="$PATH:/root/.dotnet/tools"
export ASPNETCORE_ENVIRONMENT=E2e
dotnet test --collect:"XPlat Code Coverage;Exclude=[*]atdd_v2_dotnet.Migrations.*,[*]GrpcGreeterClient.*" --results-directory:coverage-report
ls -l coverage-report
cd App
coverlet bin/Debug/net7.0/atdd-v2-dotnet.dll --target "dotnet" --targetargs bin/Debug/net7.0/atdd-v2-dotnet.dll --format cobertura  --include-test-assembly --exclude "[*]atdd_v2_dotnet.Migrations.*" --exclude "[*]GrpcGreeterClient.*" --verbosity:detailed
cd ..
reportgenerator "-reports:coverage-report/*/coverage.cobertura.xml;App/coverage.cobertura.xml" -targetdir:combined-reports -reporttypes:TextSummary
cat combined-reports/Summary.txt
echo e2e-coverage-done
