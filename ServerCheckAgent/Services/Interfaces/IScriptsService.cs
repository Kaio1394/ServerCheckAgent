using ServerCheckAgent.Models;

namespace ServerCheckAgent.Services.Interfaces
{
    public interface IScriptsService
    {
        Task<string> ExecuteScriptByFile(Script script);
        Task<string> ExecuteScriptByCmd(Script script, string pythonExePath);
    }
}
