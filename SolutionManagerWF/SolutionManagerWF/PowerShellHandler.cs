using System;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using PowerShell = System.Management.Automation.PowerShell;

namespace SolutionManagerWF
{
    public class PowerShellHandler
    {
        public PowerShellHandler()
        {
            
        }

        public string RunScript(string scriptText)
        {
            PowerShellProcessInstance instance = new PowerShellProcessInstance(new Version(2, 0), null, null, false);
            
            PSSnapInException warning;
            //Runspace runspace = RunspaceFactory.CreateRunspace();
            Runspace runspace = RunspaceFactory.CreateOutOfProcessRunspace(new TypeTable(new string[0]), instance);
            
            runspace.Open();
            runspace.RunspaceConfiguration.AddPSSnapIn("Microsoft.Sharepoint.Powershell", out warning);

            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.Add(scriptText);

            pipeline.Commands.Add("Out-String");
            StringBuilder sb = new StringBuilder();
            try
            {
                Collection<PSObject> results = pipeline.Invoke();
                foreach (PSObject obj in results)
                {
                    sb.AppendLine(obj.ToString());
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine(ex.Message);
            }
            finally
            {
                runspace.Close();
            }

            return sb.ToString();

        }
    }
}