set -x
dotnet build
dotnet tool install --global coverlet.console
export PATH="$PATH:/root/.dotnet/tools"
export ASPNETCORE_ENVIRONMENT=E2e
coverlet bin/Debug/net7.0/atdd-v2-dotnet.dll --target "dotnet" --targetargs bin/Debug/net7.0/atdd-v2-dotnet.dll --format cobertura  --include-test-assembly --exclude "[*]atdd_v2_dotnet.Migrations.*" --exclude "[*]GrpcGreeterClient.*" --verbosity:detailed
echo e2e-coverage-done