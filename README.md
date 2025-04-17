# Doggo.Cli
(can't be bothered to write tests)

1. Clone repo
2. Navigate to .exe in terminal
3. Doggo.Cli.exe fetch
4. Doggo.Cli.exe fetch -b <breed>
5. Doggo.clie.exe fetch --breed <breed>

Thank you to [MarkWAppleton](https://github.com/MarkWAppleton) to reducing the build size by 85.5%

# Building
1. Ensure you have the dotnet cli installed
2. Navigate to Doggo.Cli.csproj
3. dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -o ./publish

Build can be modified to work on different windows / os versions

Images provided via https://dog.ceo/dog-api/

## License

This project is licensed under the [MIT License](LICENSE).

It uses [ImageSharp](https://github.com/SixLabors/ImageSharp), which is licensed under the [Apache 2.0 License](https://github.com/SixLabors/ImageSharp/blob/main/LICENSE).

Please refer to each license for more details.

