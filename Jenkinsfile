pipeline {
    agent any

    environment {
        DOTNET_CLI_HOME = '.dotnet'
    }

    stages {
        stage('Find Solution File') {
            steps {
                script {
                    // Use a Windows batch command to find the .sln file
                    def slnFile = bat(script: 'dir /s /b *.sln', returnStdout: true).trim()
                    // Set the .sln file path as an environment variable to use in later steps
                    env.SLN_FILE = slnFile
                    echo "Solution file found: ${env.SLN_FILE}"
                }
            }
        }

        stage('Restore') {
            steps {
                echo 'Restoring NuGet packages...'
                // Use the found .sln file for the restore command
                bat "dotnet restore ${env.SLN_FILE}"
            }
        }

        stage('Build') {
            steps {
                echo 'Building the project...'
                // Use the found .sln file for the build command
                bat "dotnet build ${env.SLN_FILE} --configuration Release"
            }
        }

        stage('Test') {
            steps {
                echo 'Running tests...'
                // Add your test command here. Adjust accordingly if you need to specify a project or solution.
                bat "dotnet test ${env.SLN_FILE} --logger \"trx;LogFileName=unit_tests.xml\""
            }
        }

        stage('Publish') {
            steps {
                echo 'Publishing the application...'
                // Specify the project to publish if necessary, or adjust the command as needed.
                bat "dotnet publish ${env.SLN_FILE} --configuration Release --output publish"
            }
        }
    }

    post {
        always {
            echo 'Cleaning up...'
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
