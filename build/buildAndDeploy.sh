solutionName="Kerstlichtjes.sln"

rootDir=`dirname "$0"`
cd $rootDir/..
. "build/customVariables.sh"

nuget restore $solutionName
msbuild $solutionName /p:NanoFrameworkProjectSystemPath="$nanoFrameworkPath"/dist/utils/nanoFramework/v1.0/
mono $nanoFrameworkPath/dist/utils/nanoFrameworkDeployer/nanoFrameworkDeployer.exe -v -c $serialPort -d Kerstlichtjes/bin/Debug