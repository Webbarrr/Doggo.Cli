# Doggo.Cli
(can't be bothered to write tests)

1. Clone repo
2. Navigate to .exe in terminal
3. Doggo.Cli.exe fetch
4. Doggo.Cli.exe fetch -b <breed>
5. Doggo.clie.exe fetch --breed <breed>

# Building
1. Ensure you have the dotnet cli installed
2. Navigate to Doggo.Cli.csproj
3. dotnet publish ./src/Doggo.Cli/Doggo.Cli.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:UseAppHost=true -o ./publish -p:DebugType=None -p:DebugSymbols=false

Build can be modified to work on different windows / os versions

Alternatively just use the latest release

## Thanks

Images provided via https://dog.ceo/dog-api/

## License

This project is licensed under the [MIT License](LICENSE).

It uses [ImageSharp](https://github.com/SixLabors/ImageSharp), which is licensed under the [Apache 2.0 License](https://github.com/SixLabors/ImageSharp/blob/main/LICENSE).

Please refer to each license for more details.

