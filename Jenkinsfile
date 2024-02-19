pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                echo 'Building..' 
                bat 'dotnet build --configuration Release'
                // Archive the build artifacts (DLLs, EXEs, etc.) for later stages or records.
                archiveArtifacts artifacts: '**/bin/Release/net*/**/*', fingerprint: true            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
                 bat 'dotnet test --logger "trx;LogFileName=test_results.xml"'
                // Publish the test results in Jenkins
                publishTestResults '**/test_results.xml'
            }
        }
        stage('Deploy') {
            when {
                // Proceed with deployment only if the previous stages were successful
                expression { currentBuild.result == null || currentBuild.result == 'SUCCESS' }
            }
            steps {
                echo 'Deploying....'
               bat 'dotnet publish --configuration Release -o ./publish'
            }
        }
        post {
        always {
            // Cleanup or finalization actions, if any
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
}
