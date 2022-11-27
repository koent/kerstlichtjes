# Kerstlichtjes


## Build and deploy
1. Make a file `build/customVariables.sh`.
1. In this file, assign values to the following variables:
  - `nanoFrameworkPath` the path to nanoFramework. For example, when installed via the VS Code extension: `nanoFrameworkPath="$HOME/.vscode/extensions/nanoframework.vscode-nanoframework-1.0.132"`.
  - `serialPort` the path to the serial device. For example `serialPort="/dev/ttyUSB0"`.
1. To build and deploy, execute `build/buildAndDeploy.sh`