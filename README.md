[![Unit Tests](https://github.com/pravinchandankhede/codesamples/actions/workflows/dotnet.yml/badge.svg)](https://github.com/pravinchandankhede/codesamples/actions/workflows/azure-static-web-apps-happy-wave-0ec297500.yml).

# Table of Contents
- [Code Samples](#code-samples)
  - [Rest Client Demo](#rest-client-demo)
  - [Rate Limiter](#rate-limiter)
  - [Angular Elements](#angular-elements)
  - [mTLS Demo](#mutual-tls-demo)
  - [XML Transformation Demo](#xml-transformation-demo)
  - [Adaptive Card Demo](#adaptive-card-demo)
  - [Picture App](#picture-app)

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
This sample demonstrates how to perform XSLT (Extensible Stylesheet Language Transformations) in .NET using the `XslCompiledTransform` class. It shows how to transform XML data into HTML or other formats, which is a common requirement in enterprise integration and data transformation scenarios.

**Features:**
- Loads XML and XSLT files and performs transformations
- Outputs the transformed result (e.g., HTML)
- Demonstrates the use of .NET's `XslCompiledTransform` API
- Serves as a foundation for more advanced integration and transformation engines

**How it works:**
- The application loads an XML file and an XSLT stylesheet
- It applies the XSLT transformation to the XML data
- The result is saved or displayed as HTML

**Location:**
- Project directory: `src/XmlTransformationDemo`

**Usage:**
- Open the project in Visual Studio or your preferred .NET IDE
- Build and run the project
- View the transformation output in the specified output location

**Further Reading:**
- This sample is further evolved in a full-scale enterprise integration & transformation engine: [XConnect](https://github.com/pravinchandankhede/XConnect)

## [Adaptive Card Demo](https://github.com/pravinchandankhede/codesamples/tree/main/src/AdaptiveCardDemo)
This sample demonstrates the use of Adaptive Cards in an Angular application. It shows how to dynamically render Adaptive Cards using the `adaptivecards` JavaScript library.

**Features:**
- Renders multiple Adaptive Cards, including:
  - A static table with work item types and counts
  - A donut chart visualizing the distribution of work items (using a chart image)
- Demonstrates integration of Adaptive Cards with Angular components

**How it works:**
- The Angular component creates and parses Adaptive Card JSON payloads
- Cards are rendered and appended to the DOM at runtime
- The donut chart is generated using the QuickChart API and embedded as an image in the card

**Location:**
- Project directory: `src/AdaptiveCardDemo/AdaptiveCardDemo`
- Main component: `src/app/app.component.ts`

**Usage:**
- Install dependencies: `npm install`
- Run the Angular app: `ng serve`
- View the rendered Adaptive Cards in the browser

## [Picture App](https://github.com/pravinchandankhede/codesamples/tree/main/src/picture-app)
This is a simple picture gallery app using plain HTML and JavaScript code. It uses images stored in Azure Storage and is mobile friendly.
