# mergejsonfiles

A .NET command line tool to merge 2 input .json files into 1 output file, using the `Newtonsoft.json` library, being able to specify the handling of arrays and nulls during the process.

## Parameters

```
  -l, --leftpath              Required. Specifies the file path to use on the left side.

  -r, --rightpath             Required. Specifies the file path to use on the right side.

  -o, --outputpath            Required. Specifies the output file path.

  --mergearrayhandling        Specifies MergeArrayHandling property of JsonMergeSettings class.

  --mergenullvaluehandling    Specifies MergeNullValueHandling property of JsonMergeSettings class.
```