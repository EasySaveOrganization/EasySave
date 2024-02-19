pipeline {
    agent any

    stages {
        stage('Restore') {
            steps {
                // Assuming your .csproj or .sln file is in the 'YourProject' directory
                dir('EasySaveProjectCode') {
                    bat 'dotnet restore'
                }
            }
        }

        stage('Build') {
            steps {
                dir('EasySaveProjectCode') {
                    bat 'dotnet build --configuration Release'
                }
            }
        }

        stage('Test') {
            steps {
                dir('EasySaveProjectCode') {
                    // Update the path to the test project if it's different
                    // This assumes your tests are in the same project directory
                    // If your tests are in a different directory, specify that path here instead
                    bat 'dotnet test'
                }
            }
        }

        stage('Publish') {
            steps {
                dir('EasySaveProjectCode') {
                    // Adjust the output directory as needed
                    bat 'dotnet publish --configuration Release --output ./publish'
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
