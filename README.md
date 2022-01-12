# stryker-mutator-poc

[![Nuget](https://img.shields.io/nuget/v/dotnet-stryker.svg?color=blue&label=dotnet-stryker&style=flat-square)](https://www.nuget.org/packages/dotnet-stryker/)
[![Nuget](https://img.shields.io/nuget/dt/dotnet-stryker.svg?style=flat-square)](https://www.nuget.org/packages/dotnet-stryker/)
[![Azure DevOps build](https://img.shields.io/azure-devops/build/stryker-mutator/Stryker/4/master.svg?label=Azure%20Pipelines&style=flat-square)](https://dev.azure.com/stryker-mutator/Stryker/_build/latest?definitionId=4)
[![Azure DevOps tests](https://img.shields.io/azure-devops/tests/stryker-mutator/506a1f46-900e-434e-805f-ff8d36fc81af/4/master.svg?compact_message&style=flat-square)](https://dev.azure.com/stryker-mutator/Stryker/_build/latest?definitionId=4)
[![Slack](https://img.shields.io/badge/chat-on%20slack-blueviolet?style=flat-square)](https://join.slack.com/t/stryker-mutator/shared_invite/enQtOTUyMTYyNTg1NDQ0LTU4ODNmZDlmN2I3MmEyMTVhYjZlYmJkOThlNTY3NTM1M2QxYmM5YTM3ODQxYmJjY2YyYzllM2RkMmM1NjNjZjM)


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

