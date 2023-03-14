# Kerstlichtjes

This is version 2 of Kerstlichtjes, completely rewritten in .NET using [NanoFramework](https://www.nanoframework.net/).

## Setup
1. Make a file `build/customVariables.sh`.
1. In this file, assign values to the following variables:
  - `nanoFrameworkPath` the path to nanoFramework. For example, when installed via the VS Code extension: `nanoFrameworkPath="$HOME/.vscode/extensions/nanoframework.vscode-nanoframework-1.0.132"`.
  - `serialPort` the path to the serial device. For example `serialPort="/dev/ttyUSB0"`.
3. In `Configuration/SecretConstants.cs`, add the following `public const`s
  - `string WiFiSsid` the Wi-Fi SSID. For example: `public const string WiFiSsid = "AIVD Surveillance Van";`.
  - `string WiFiPassword` the Wi-Fi password.


## Build and deploy
1. Disconnect any running instances of `screen`. (ctrl-a, k, y)
1. Execute `build/buildAndDeploy.sh`.
1. Start monitoring: `screen /dev/ttyUSB0 921600`.
1. Press the 'en' button on the esp32.