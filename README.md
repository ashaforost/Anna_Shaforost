# Development and Testing How to

## How to start an application
* Import the kp1 into your code editor
* Add .NET SDK
* Import the necessary packages: NUnit, Nunit3TestAdapter and NUnitForms.Framework

You'll get the following .csproj config:
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net5.0</TargetFramework>
    <RootNamespace>C__Projects</RootNamespace>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.0.0" />
    <PackageReference Include="NUnit" Version="3.13.2" />
    <PackageReference Include="Nunit3TestAdapter" Version="4.1.0" />
    <PackageReference Include="NUnitForms.Framework" Version="1.3.1" />
  </ItemGroup>
</Project>
```

* And finally run the tests
