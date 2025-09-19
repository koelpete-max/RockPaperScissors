To run the current project .net SDK version must be higher or equal to 8.

From the folder where **RockPaperScissors** you can run the game using the command 
_dot run --project RockPaperScissors.csprj_

Running the tests
- Navigate to the RockPaperScissors.test
- Make sure that the test environment is available
  - dotnet add package Microsoft.NET.Test.Sdk
  - dotnet add package xunit
  - dotnet add package xunit.runner.visualstudio
- Then run _dotnet test_