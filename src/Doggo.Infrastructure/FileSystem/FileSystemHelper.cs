using Doggo.Application.Contracts;

namespace Doggo.Infrastructure.FileSystem;

public class FileSystemHelper : IFileSystemHelper
{
    public string WriteOutput(string filePathOrDirectory, string value)
    {
        // create the output file
        var path = CreateOutput(filePathOrDirectory);

        // write the output
        File.WriteAllText(path, value);

        return path;
    }

    private string CreateOutput(string filePathOrDirectory)
    {
        string outputPath;
        var fileName = $"{Guid.NewGuid()}.txt";

        if (Directory.Exists(filePathOrDirectory))
        {
            // It's a directory — generate a filename inside it
            outputPath = Path.Combine(filePathOrDirectory, fileName);
        }
        else
        {
            // Could be a file path or a non-existent path, so check if the parent directory exists
            var directory = Path.GetDirectoryName(filePathOrDirectory);

            if (!string.IsNullOrWhiteSpace(directory) && Directory.Exists(directory))
            {
                // Parent directory exists, so treat filePathOrDirectory as a full file path
                outputPath = filePathOrDirectory;
            }
            else if (filePathOrDirectory.EndsWith(Path.DirectorySeparatorChar) || filePathOrDirectory.EndsWith(Path.AltDirectorySeparatorChar))
            {
                // Ends with separator but directory doesn't exist — treat as directory anyway
                outputPath = Path.Combine(filePathOrDirectory, fileName);
            }
            else
            {
                // Neither file nor existing directory — fallback to current directory with default filename
                outputPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            }
        }

        return outputPath;
    }
}