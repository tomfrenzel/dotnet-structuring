[![GitHub issues](https://img.shields.io/github/issues/tomfrenzel/dotnet-structuring?style=flat-square)](https://github.com/tomfrenzel/dotnet-structuring/issues)
[![Azure DevOps builds](https://img.shields.io/azure-devops/build/tomfrenzel/dotnet-structuring/5?label=Azure%20Pipelines&logo=azure-pipelines&style=flat-square)](https://dev.azure.com/tomfrenzel/dotnet-structuring/_build/latest?definitionId=5&branchName=dev)
[![Codecov](https://img.shields.io/codecov/c/gh/tomfrenzel/dotnet-structuring?logo=codecov&style=flat-square)](https://codecov.io/gh/tomfrenzel/dotnet-structuring)
[![Code Climate maintainability](https://img.shields.io/codeclimate/maintainability/tomfrenzel/dotnet-structuring?logo=code-climate&style=flat-square)](https://codeclimate.com/github/tomfrenzel/dotnet-structuring/maintainability)
[![Codacy grade](https://img.shields.io/codacy/grade/16af892b784c4b049b34622c3949a3d2?style=flat-square)](https://www.codacy.com/manual/tomfrenzel/dotnet-structuring?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=tomfrenzel/dotnet-structuring&amp;utm_campaign=Badge_Grade)
[![GitHub license](https://img.shields.io/github/license/tomfrenzel/dotnet-structuring?style=flat-square)](https://github.com/tomfrenzel/dotnet-structuring/blob/master/LICENSE)


# dotnet-structuring

This is a tool to structor .NET Projects

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.

#### Users
* dotnet core Runtime 3.1.x ([Windows x64](https://dotnet.microsoft.com/download/dotnet-core/thank-you/runtime-aspnetcore-3.1.0-windows-x64-installer) / [Windows x86](https://dotnet.microsoft.com/download/dotnet-core/thank-you/runtime-aspnetcore-3.1.0-windows-x86-installer))

#### Developers
* dotnet core SDK 3.1.x ([Windows x64](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.100-windows-x64-installer) / [Windows x86](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.100-windows-x86-installer))

### Installation

1. Clone the repo
```sh
git clone https://github.com/tomfrenzel/dotnet-structuring.git
```
3. Install required Packages
```sh
cd YOUR_WORKING_DIRECTORY
dotnet restore
```
4. Run the Program
```sh
dotnet run
```

### Build

Run ```build.bat``` to build the Project. The Output files will be located in the ```/artifacts``` Directory

## Usage

The Usage is basically self-explaining. Here are some screenshots of the Program:
![General](https://github.com/tomfrenzel/dotnet-structuring/samples/screenshots/general.png)
![Options](https://github.com/tomfrenzel/dotnet-structuring/samples/screenshots/options.png)
![Finish](https://github.com/tomfrenzel/dotnet-structuring/samples/screenshots/finish.png)

## Built With

* [NuGet](https://www.nuget.org/) - .NET package manager

## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
