using CMS.DocumentEngine;
using CMS.EventLog;

namespace Xperience.Zapier
{
    public class ZapierWorkflowAction : DocumentWorkflowAction
    {
        public override void Execute()
        {
            var url = GetResolvedParameter("WebhookURL", string.Empty);
            if(url != string.Empty) ZapierHelper.SendPostToWebhook(url, Node.Site, Node);
            else
            {
                EventLogProvider.LogEvent("W", nameof(ZapierWorkflowAction), "EXECUTE", $"Workflow '{Workflow.WorkflowDisplayName}' step 'Send page to Zapier' couldn't be processed because it is missing the webhook URL.");
            }
        }
    }
}