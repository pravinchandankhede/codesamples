[![Unit Tests](https://github.com/pravinchandankhede/codesamples/actions/workflows/dotnet.yml/badge.svg)](https://github.com/pravinchandankhede/codesamples/actions/workflows/dotnet.yml)

# Table of Contents
- [Code Samples](#code-samples)
  - [Rest Client Demo](#rest-client-demo)
  - [Rate Limiter](#rate-limiter)
  - [Angular Elements](#angular-elements)
  - [mTLS Demo](#mutual-tls-demo)
  - [XML Transformation Demo](#xml-transformation-demo)

# Code Samples
This repo contains numerous code samples that demonstrate some key programming concepts in different programming languages, frameworks and libraries.

## [Rest Client Demo](https://github.com/pravinchandankhede/codesamples/tree/main/src/HttpRestClientDemo)
This sample shows how to call an API using the HttpClient library provided out of the box in .NET Core Framework.

## [Rate Limiter](https://github.com/pravinchandankhede/codesamples/tree/main/src/RateLimitingSolution)
This solution demonstrates the implementation of a rate limiter pattern in .Net 9 ASP.NET Core API. It uses the standard NuGet packages to implement the various rate limit
Specifically it shows the implementation of Fixed Window and Concurrency rate limiter. It also shows how to implement a custom date limiter using policy.

## [Angular Elements](https://github.com/pravinchandankhede/codesamples/tree/main/src/AngularElements)
This sample show the use of elements in Angular. It demonstrates how to define a custom element and then use in an application. It has a simple hello world custom elements which is then loaded on the home screen of application. It uses inbuilt `createCustomElement` method from `@angular/elements` package.

## [Mutual TLS Demo](https://github.com/pravinchandankhede/codesamples/tree/main/src/MTLSDemo)
This sample demonstrate the implementation of Mutual TLS (mTLS) protocol. We will go through the impportant concepts, its working, challenges and benefits. We will also see an implementation using in C# language using ASP.NET Core Service and .NET Console application.

## [XML Transformation Demo](https://github.com/pravinchandankhede/codesamples/tree/main/src/XmlTransformationDemo)
This is sample code to demonstrate the working of XSLT transformaiton in .NET. It uses a XslCompiledTransform class to translate a XML file into HTML. This sample is further evolved in a full scale backbone of a enterpise integration & transformation engine here [XConnect](https://github.com/pravinchandankhede/XConnect)
