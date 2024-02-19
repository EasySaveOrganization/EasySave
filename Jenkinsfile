pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                echo 'Building..' 
                bat 'dotnet build --configuration Release'
                archiveArtifacts artifacts: '**/bin/Release/net*/**/*', fingerprint: true
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
                bat 'dotnet test --logger "trx;LogFileName=test_results.xml"'
                publishTestResults '**/test_results.xml'
            }
        }
        stage('Deploy') {
            when {
                expression { currentBuild.result == null || currentBuild.result == 'SUCCESS' }
            }
            steps {
                echo 'Deploying....'
                bat 'dotnet publish --configuration Release -o ./publish'
            }
        }
    }
    post {
        always {
            echo 'Cleaning up...'
        }
        success {
            echo 'Build, test, and deployment completed successfully.'
        }
        failure {
            echo 'An error occurred during the pipeline execution.'
        }
    }
}
