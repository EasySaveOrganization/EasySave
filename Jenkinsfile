pipeline {
    agent any

    tools {
        // Make sure to specify the dotnet tool if it's available in your Jenkins configuration
        // If not, you might need to ensure dotnet is available in the PATH
        dotnet '5.0'
    }

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
                // Optionally run tests if you have a test project
                // sh 'dotnet test --no-restore --verbosity normal'
            }
        }

        stage('Publish') {
            steps {
                // Publish the application
                // Adjust the output directory as needed
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
