pipeline {
    agent any

    stages {
        stage('Restore') {
            steps {
                // Restore the dependencies
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                // Build the project
                sh 'dotnet build --configuration Release'
            }
        }

        stage('Test') {
            steps {
                // Run tests if you have a test project
                sh 'dotnet test'
            }
        }

        stage('Publish') {
            steps {
                // Publish the application
                sh 'dotnet publish --configuration Release --output ./publish'
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
