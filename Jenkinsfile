pipeline {
    agent any

    tools {
        dotnetsdk 'dotnet-sdk-8.0'
    }

    stages {
        stage('Clean workspace') {
            steps {
                script {
                    deleteDir()
                }
            }
        }

        stage('Checkout') {
            steps {
                git branch: 'master', url: 'https://github.com/Linases/Diploma_OrangeHRM.git'
            }
        }

        stage('Restore') {
            steps {
                bat "dotnet restore Diploma_OrangeHRM.sln"
            }
        }

        stage('Build') {
            steps {
                bat "dotnet build Diploma_OrangeHRM.sln --no-restore"
            }
        }

        stage('Test export to ReportPortal') {
            steps {
                bat '''
                    dotnet test Diploma_OrangeHRM.sln ^
                        --no-build ^
                        -c Release
                '''
            }
        }
    }
}
