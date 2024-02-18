pipeline {
    agent any
    
    stages {
        stage('Build') {
            steps {
                // Build your project
                bat 'mvn clean install'
            }
        }
        stage('Test') {
            steps {
                // Run tests
                bat 'mvn test'
            }
        }
        stage('Deploy') {
            steps {
                // Deploy your application
                bat 'mvn deploy'
            }
        }
    }
}

