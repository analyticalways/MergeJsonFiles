[![NuGet](http://img.shields.io/nuget/vpre/MergeJsonFiles.svg?label=NuGet)](https://www.nuget.org/packages/MergeJsonFiles/)

# mergejsonfiles

A .NET command line tool to merge 2 input .json files into 1 output file, using the `Newtonsoft.json` library, being able to specify the handling of arrays and nulls during the process.

## Installation

```powershell
dotnet tool install mergejsonfiles -g
```

## How to use

```
  -l, --leftpath              Required. Specifies the file path to use on the left side.

  -r, --rightpath             Required. Specifies the file path to use on the right side.

  -o, --outputpath            Required. Specifies the output file path.

  --mergearrayhandling        Specifies MergeArrayHandling property of JsonMergeSettings class.

  --mergenullvaluehandling    Specifies MergeNullValueHandling property of JsonMergeSettings class.
```

With the following 2 files:

`left.json`

```json
{
  "name": "Sergio",
  "age": 44,
  "address": {
    "city": "Madrid",
    "zipCode": "28054"
  }
}

```

`right.json`

```json
{
  "name": "Carmen",
  "age": null,
  "address": {
    "city": "Málaga",
    "country": "España"
  }
}
```

We can create a `merged.json` with this command:

```powershell
mergejsonfiles -l .\left.json -r .\right.json -o merged.json
```

`merged.json`

```json
{
  "name": "Carmen",
  "age": 44,
  "address": {
    "city": "Málaga",
    "zipCode": "28054",
    "country": "España"
  }
}
```

## Contribution
- If you want to contribute to codes, create pull request
- If you find any bugs or error, create an issue
