pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                // Build the project
                bat 'dotnet build'
            }
        }

        stage('Test') {
            steps {
                // Run tests if you have a test project
                bat 'dotnet test'
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
