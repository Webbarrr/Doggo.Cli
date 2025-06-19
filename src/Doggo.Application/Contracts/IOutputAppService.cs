namespace Doggo.Application.Contracts
{
    public interface IOutputAppService
    {
        string Output(string outputPath, string value);
        string Output(string outputPath, IEnumerable<string> value);
    }
}