[![Build Status](https://dev.azure.com/tomfrenzel/dotnet-structuring/_apis/build/status/dotnet-structuring%20CI?branchName=master)](https://dev.azure.com/tomfrenzel/dotnet-structuring/_build/latest?definitionId=11&branchName=master)
[![GitHub issues](https://img.shields.io/github/issues/tomfrenzel/dotnet-structuring)](https://github.com/tomfrenzel/dotnet-structuring/issues)
[![GitHub license](https://img.shields.io/github/license/tomfrenzel/dotnet-structuring)](https://github.com/tomfrenzel/dotnet-structuring/blob/master/LICENSE)
[![GitHub release (latest SemVer including pre-releases)](https://img.shields.io/github/v/release/tomfrenzel/dotnet-structuring?include_prereleases&sort=semver)](https://github.com/tomfrenzel/dotnet-structuring/releases/latest)
[![Coverage Status](https://coveralls.io/repos/github/tomfrenzel/dotnet-structuring/badge.svg?branch=master)](https://coveralls.io/github/tomfrenzel/dotnet-structuring?branch=master)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/16af892b784c4b049b34622c3949a3d2)](https://www.codacy.com/manual/tomfrenzel/dotnet-structuring?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=tomfrenzel/dotnet-structuring&amp;utm_campaign=Badge_Grade)


# dotnet-structuring

This is a tool to structor .NET Projects

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

#### Users

* dotnet core Runtime 3.1.x ([Windows x64](https://dotnet.microsoft.com/download/dotnet-core/thank-you/runtime-aspnetcore-3.1.0-windows-x64-installer) / [Windows x86](https://dotnet.microsoft.com/download/dotnet-core/thank-you/runtime-aspnetcore-3.1.0-windows-x86-installer))

#### Developers

* dotnet core SDK 3.1.x ([Windows x64](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.100-windows-x64-installer) / [Windows x86](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.100-windows-x86-installer))

### Installation

1. Clone the repo
```sh
git clone https://github.com/tomfrenzel/dotnet-structuring.git
```
2. Install required Packages
```sh
cd YOUR_WORKING_DIRECTORY
dotnet restore
```

### Build

Run ```build.bat``` to build the Project. The Output files will be located in the ```/artifacts``` Directory

## Usage

The Usage is basically self-explaining.

[WPF Application](src/dotnet-structuring/)  
[Console Application](src/dotnet-structuring.console/)

## Built With

* [NuGet](https://www.nuget.org/) - .NET package manager

## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE) file for details
