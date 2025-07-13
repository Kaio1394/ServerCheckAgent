using ServerCheckAgent.Helper.Interfaces;
using ServerCheckAgent.Models;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace ServerCheckAgent.Helper
{
    [ExcludeFromCodeCoverage]
    public class ScriptsHelper: IScriptsHelper
    {
        private readonly IWebHostEnvironment _env;
        public ScriptsHelper(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string ExecuteScriptByFile(Script script)
        {
            return "";
;       }

        public string ExecuteScriptByCmd(Script script, string pythonExePath)
        {
            try
            {
                string escapedCode = script.Code.Replace("\"", "\\\"");

                string output = "";
                string error = "";
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = pythonExePath,
                    Arguments = $"-c \"{escapedCode}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = false
                };

                using (System.Diagnostics.Process? process = System.Diagnostics.Process.Start(psi))
                {
                    output = process.StandardOutput.ReadToEnd();
                    error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        return error;
                    }
                }
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
