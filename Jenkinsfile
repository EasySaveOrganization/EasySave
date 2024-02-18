pipeline {
    agent any

    environment {
        // Define environment variables
        DOTNET_CLI_HOME = '.dotnet'
    }

    stages {
        stage('Restore') {
            steps {
                echo 'Restoring NuGet packages...'
                // Restore NuGet packages
                bat 'dotnet restore EasySaveProject.sln'
            }
        }

        stage('Build') {
            steps {
                echo 'Building the project...'
                // Build the project
                bat 'dotnet build --configuration Release'
            }
        }

        stage('Test') {
            steps {
                echo 'Running tests...'
                // Run tests
                bat 'dotnet test --logger "trx;LogFileName=unit_tests.xml"'
                // Publish the test results to Jenkins (optional)
                // junit 'unit_tests.xml'
            }
        }

        stage('Publish') {
            steps {
                echo 'Publishing the application...'
                // Publish the application
                bat 'dotnet publish --configuration Release --output publish'
                // Steps to deploy or archive the output can be added here
            }
        }
    }

    post {
        always {
            echo 'Cleaning up...'
            // Clean up actions
            cleanWs()
        }
        success {
            echo 'Build succeeded!'
        }
        failure {
            echo 'Build failed.'
        }
    }
}
