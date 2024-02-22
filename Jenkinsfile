pipeline {
    agent any
    stages {
        stage('Restore') {
            steps {
                dir('EasySaveProjectCode') {
                    bat 'dotnet restore'
                echo 'Restoring'}
            }
        }

        stage('Build') {
            steps {
            dir('EasySaveProjectCode') {
                    bat 'dotnet build --configuration Release'
                 echo 'Building'}
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
<<<<<<< HEAD
}
=======

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
>>>>>>> 7f8ee939f33ec6cf7ce0e8ffe0da01f5e39c4b9e
