using ServerCheckAgent.Models;

namespace ServerCheckAgent.Helper.Interfaces
{
    public interface IScriptsHelper
    {
        string ExecuteScriptByFile(Script script);
        string ExecuteScriptByCmd(Script script, string pythonExePath);
    }
}
