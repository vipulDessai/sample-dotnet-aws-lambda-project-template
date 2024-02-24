# Refer
- Authenticate and authorize the graph ql query/mutation using hot choclate - <b style="color: green">DONE</b>
    - [authentication tutorial](https://medium.com/@marcinjaniak/graphql-simple-authorization-and-authentication-with-hotchocolate-11-and-asp-net-core-3-162e0a35743d)
- enable cors - currently enabled from API server directly - <b style="color: green">DONE</b>
    - [serverless httpapi config](https://www.serverless.com/framework/docs/providers/aws/events/http-api)
    - [stack overflow issue cors](https://stackoverflow.com/questions/66000642/httpapi-serverless-framework-api-gateway-cors-not-working)
    - [AWS cors note](https://docs.aws.amazon.com/apigateway/latest/developerguide/http-api-cors.html)
- serverless.yml setup
    - configs
        - [multiple httpApi route configs](https://forum.serverless.com/t/multiple-request-methods-for-a-single-httpapi-route/15721/5)
- secure api
    - use password hash (something like bcrypt js)
    - use TOTP 
      - [tutorial link](https://medium.com/techvraksh/setup-2fa-using-totp-in-your-app-347e8ff7ad4d)
      - [stack overflow](https://stackoverflow.com/questions/53413527/is-there-a-google-authenticator-api)
- Setup git action pipeline for building and deploying the project
    - using node and dotnet - [link](https://docs.github.com/en/actions/automating-builds-and-tests/building-and-testing-net)
    - setup pre commit
    - git hooks
- graphql for lambda - <b style="color: green">DONE</b>
    - [Link 1](https://dev.to/memark/running-a-graphql-api-in-net-6-on-aws-lambda-17oc)
    - Graph QL setup for dotnet core web api
        - [Article 1](https://medium.com/@TimHolzherr/creating-a-graphql-backend-in-c-how-to-get-started-with-hot-chocolate-12-in-net-6-30f0fb177c5c) - implementation in progress
        - [Article 2](https://www.c-sharpcorner.com/article/building-api-in-net-core-with-graphql2/) - for reference only

# AWS Lambda Empty Function Project

This starter project consists of:
* Function.cs - class file containing a class with a single function handler method
* aws-lambda-tools-defaults.json - default argument settings for use with Visual Studio and command line deployment tools for AWS

You may also have a test project depending on the options selected.

The generated function handler is a simple method accepting a string argument that returns the uppercase equivalent of the input string. Replace the body of this method, and parameters, to suit your needs. 

## Here are some steps to follow from Visual Studio:

To deploy your function to AWS Lambda, right click the project in Solution Explorer and select *Publish to AWS Lambda*.

To view your deployed function open its Function View window by double-clicking the function name shown beneath the AWS Lambda node in the AWS Explorer tree.

To perform testing against your deployed function use the Test Invoke tab in the opened Function View window.

To configure event sources for your deployed function, for example to have your function invoked when an object is created in an Amazon S3 bucket, use the Event Sources tab in the opened Function View window.

To update the runtime configuration of your deployed function use the Configuration tab in the opened Function View window.

To view execution logs of invocations of your function use the Logs tab in the opened Function View window.

## Here are some steps to follow to get started from the command line:

Once you have edited your template and code you can deploy your application using the [Amazon.Lambda.Tools Global Tool](https://github.com/aws/aws-extensions-for-dotnet-cli#aws-lambda-amazonlambdatools) from the command line.

Install Amazon.Lambda.Tools Global Tools if not already installed.
```
    dotnet tool install -g Amazon.Lambda.Tools
```

If already installed check if new version is available.
```
    dotnet tool update -g Amazon.Lambda.Tools
```

Execute unit tests
```
    cd "SampleDotnetAWSLambdaProjectTemplate/test/SampleDotnetAWSLambdaProjectTemplate.Tests"
    dotnet test
```

Deploy function to AWS Lambda
```
    cd "SampleDotnetAWSLambdaProjectTemplate/src/SampleDotnetAWSLambdaProjectTemplate"
    dotnet lambda deploy-function
```
