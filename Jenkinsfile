pipeline {
    agent any

    environment {
        // Define environment variables if any
        DOTNET_SKIP_FIRST_TIME_EXPERIENCE = true
        DOTNET_CLI_TELEMETRY_OPTOUT = true
    }

    stages {
        stage('Restore') {
            steps {
                // Restore NuGet packages
                bat 'dotnet restore'
            }
        }
        stage('Build') {
            steps {
                // Build the project
                bat 'dotnet build --configuration Release'
            }
        }
        stage('Test') {
            steps {
                // Run tests
                bat 'dotnet test --configuration Release --no-build'
            }
        }
        stage('Publish') {
            steps {
                // Publish the application
                bat 'dotnet publish --configuration Release --output ./publish'
            }
        }
        // Add additional stages for deployment if necessary
    }
}
