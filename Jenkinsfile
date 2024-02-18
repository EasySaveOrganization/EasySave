pipeline {  
    agent any  
    environment {  
        dotnet = 'C:\\Program Files\\dotnet\\dotnet.exe'  
    }  
    stages {  
        stage('Checkout') {  
            steps {
                git url: 'https://github.com/raphi9864/EasySave.git', branch: 'main'
            }  
        }  
        stage('Build') {  
            steps {  
                bat "${dotnet} build" 
            }  
        }  
        stage('Test') {  
            steps {  
                bat "${dotnet} test"  
            }  
        }
        stage("Release"){
            steps {
                bat "${dotnet} publish --configuration Release --output ./publish"
            }
        }
        stage('Deploy') {
            steps {
                 bat 'dotnet publish -c Release -o C:\\Users'
            }
        }
    }  
}
