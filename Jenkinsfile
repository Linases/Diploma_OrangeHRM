pipeline {
    agent any

    tools {
        dotnetsdk 'dotnet-sdk-8.0'
    }

    options {
        timeout(time: 20, unit: 'MINUTES')
        timestamps()
    }

    stages {
        stage('Clean workspace') {
            when {
                expression { return params.CLEAN_WORKSPACE == true } 
            }
            steps {
                cleanWs()
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
                bat "dotnet build Diploma_OrangeHRM.sln --no-restore -c Release"
            }
        }

        stage('Test and Export to ReportPortal') {
            steps {
                catchError(buildResult: 'SUCCESS', stageResult: 'FAILURE') {
                    bat '''
                        dotnet test Diploma_OrangeHRM.sln ^
                            --no-build ^
                            -c Release ^
                            --logger:"trx;LogFileName=test_results.trx"
                    '''
                }
            }
            post {
                always {
                    // Keep Jenkins logs in UI
                    junit allowEmptyResults: true, testResults: '**/TestResults/*.trx'
                }
            }
        }
    }
}
