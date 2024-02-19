pipeline {
    agent any
stages {
        stage('Preparation') {
            steps {
                checkout scm
               bat 'dotnet tool restore'
            }
        }
    stages {
        stage('Build') {
            steps {
                echo 'Building..'
                bat 'dotnet build --configuration Release'
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
}
