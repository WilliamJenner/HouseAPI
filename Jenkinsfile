String githubUrl = "https://github.com/WilliamJenner/HouseAPI"
String projectName = "CISample/CISample.App"
String publishedPath = "CISample\\CISample.App\\bin\\Release\\netcoreapp2.2\\publish"
String iisApplicationName = "cisample"
String iisApplicationPath = "D:\\WebSites\\cisample"
String targetServerIP = "0.0.0.0"

node () {
    stage('Checkout') {
        checkout([
            $class: 'GitSCM', 
            branches: [[name: 'master']], 
            doGenerateSubmoduleConfigurations: false, 
            extensions: [], 
            submoduleCfg: [], 
            userRemoteConfigs: [[url: """ "${githubUrl}" """]]])
    }
    stage('Build') {
        bat """
        cd ${projectName}
        dotnet build -c Release /p:Version=${BUILD_NUMBER}
        dotnet publish -c Release --no-build
        """
    }
    stage('Deploy'){
        withCredentials([usernamePassword(credentialsId: 'iis-credential', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD')]) { bat """ "C:\\Program Files (x86)\\IIS\\Microsoft Web Deploy V3\\msdeploy.exe" -verb:sync -source:iisApp="${WORKSPACE}\\${publishedPath}" -enableRule:AppOffline -dest:iisApp="${iisApplicationName}",ComputerName="https://${targetServerIP}:8172/msdeploy.axd",UserName="$USERNAME",Password="$PASSWORD",AuthType="Basic" -allowUntrusted"""}
    }
}