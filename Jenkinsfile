pipeline {
    agent any
    stages {
        stage('Restore') {
            steps {
                // Assuming your .csproj or .sln file is in the 'YourProject' directory
               // dir('EasySaveProjectCode') {
                    //bat 'dotnet restore'}
                echo 'Restoring'
            }
        }

        stage('Build') {
            steps {
                //dir('EasySaveProjectCode') {
                    //bat 'dotnet build --configuration Release'}
                 echo 'Building'
            }
        }

        stage('Test') {
            steps {
                dir('EasySaveProjectCode') {
                  bat 'dotnet test'
                }
            }
        }
    }

    post {
        always {
            // Clean up workspace after the pipeline run
            cleanWs()
        }
        success {
            // Actions to take on success
            echo 'Build and publish succeeded.'
        }
        failure {
            // Actions to take if the pipeline fails
            echo 'Build or publish failed.'
        }
    }
}
