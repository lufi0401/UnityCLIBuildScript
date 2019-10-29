# To Build Unity Project using CommandLine

1. Customize the build script and put under folder `Editor`.
2. Use the folling commandline
```bash
"$(UnityExePath)" -batchmode -quit -logFile - -ProjectPath "$(ProjectDir)" -executeMethod Builder.PerformBuild -buildPath "$(TargetPath)"
```
    - batchmode: start unity in commandline
    - quit: quit Unity after command is finished
    - logFile -: Output log to Console
    - ProjectPath: Path to project
    - executeMethod: a static mehthod in the project to be executed, i.e. the build script
    - buildPath: Script defined argument