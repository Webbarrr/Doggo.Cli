using Doggo.Application.Contracts;

namespace Doggo.Application.AppServices;

public class OutputAppService : IOutputAppService
{
    private readonly IFileSystemHelper _fileSystemHelper;

    public OutputAppService(IFileSystemHelper fileSystemHelper)
    {
        _fileSystemHelper = fileSystemHelper;
    }

    public string Output(string outputPath, string value)
    {
        return _fileSystemHelper.WriteOutput(outputPath, value);
    }

    public string Output(string outputPath, IEnumerable<string> value)
    {
        return _fileSystemHelper.WriteOutput(outputPath, string.Join(Environment.NewLine, value));
    }
}
