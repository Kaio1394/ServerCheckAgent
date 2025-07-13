using ServerCheckAgent.Helper.Interfaces;
using ServerCheckAgent.Models;
using ServerCheckAgent.Services.Interfaces;

namespace ServerCheckAgent.Services
{
    public class ScriptsService : IScriptsService
    {
        private readonly IScriptsHelper _scriptsHelper;

        public ScriptsService(IScriptsHelper scriptsHelper)
        {
            _scriptsHelper = scriptsHelper;
        }
        public Task<string> ExecuteScriptByCmd(Script script, string pythonExePath)
        {
            return Task.Run(()=>
            {
                return _scriptsHelper.ExecuteScriptByCmd(script, pythonExePath);
            });
        }

        public Task<string> ExecuteScriptByFile(Script script)
        {
            throw new NotImplementedException();
        }
    }
}
