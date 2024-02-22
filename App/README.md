[![coverage report](https://gitlab.com/JosephYao/atdd-v2-dotnet/badges/master/coverage.svg)](https://gitlab.com/JosephYao/atdd-v2-dotnet/-/commits/master) Code coverage includes both unit tests and e2e tests

# Start up the environment

```shell
docker compose up -d
docker compose stop dotnet jdk # stop these two containers so that you can run the app from IDE and run e2e tests
```

# Run the app

```shell
dotnet run -lp e2e
```

# Run all tests

## For Linux and Mac

```shell
cd e2e_test
./gradlew cucumber
```

## For Windows

```shell
cd e2e_test
gradlew.bat cucumber
```

# Run tests in Intellij

* Install Intellij IDEA (either Ultimate or Community version)
    * when installing the community version, please also install the "Cucumber for Java" plugin
* Open the `e2e_test` folder with Intellij and wait for this gradle project loaded completely
* Open the feature file under `src/test/resources` and run it by clicking the green run test gutter
  icon on the left bar and test should pass