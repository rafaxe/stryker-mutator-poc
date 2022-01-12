# stryker-mutator-poc

[![Nuget](https://img.shields.io/nuget/v/dotnet-stryker.svg?color=blue&label=dotnet-stryker&style=flat-square)](https://www.nuget.org/packages/dotnet-stryker/)


## Introduction
This is a POC for Stryker Mutator .NET Lib. Stryker offers mutation testing for your .NET Core and .NET Framework projects. It allows you to test your tests by temporarily inserting bugs in your source code

For an introduction to mutation testing and Stryker's features, see [stryker-mutator.io](https://stryker-mutator.io/). Looking for mutation testing in [JavaScript & Typescript](https://stryker-mutator.github.io/stryker) or [Scala](https://stryker-mutator.github.io/stryker4s)?

## Compatibility

 - dotnet core 1.1 or newer
 - dotnet framework 4.5 or newer

## Getting started

```bash
dotnet tool install -g dotnet-stryker
cd /stryker-mutator-poc/X-Men-Tests/XMen.Test/
dotnet stryker
```

For more information read our [getting started](https://stryker-mutator.io/docs/stryker-net/Getting-started)

## License

This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at http://mozilla.org/MPL/2.0/.

