pipeline {
    agent any
    
    stages {
        stage('Build') {
            steps {
                // Build your project
                sh 'mvn clean install'
            }
        }
        stage('Test') {
            steps {
                // Run tests
                sh 'mvn test'
            }
        }
        stage('Deploy') {
            steps {
                // Deploy your application
                sh 'mvn deploy'
            }
        }
    }
}