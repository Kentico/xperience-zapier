using AngleSharp.Dom.Events;
using CMS.Core;
using CMS.DocumentEngine;

namespace Xperience.Zapier
{
    public class ZapierWorkflowAction : DocumentWorkflowAction
    {
        private IEventLogService mLogService;

        public IEventLogService LogService
        {
            get
            {
                if (mLogService == null)
                {
                    mLogService = Service.Resolve<IEventLogService>();
                }

                return mLogService;
            }
        }

        public override void Execute()
        {
            var url = GetResolvedParameter("WebhookURL", string.Empty);
            if(url != string.Empty) ZapierHelper.SendPostToWebhook(url, Node);
            else
            {
                LogService.LogEvent(EventTypeEnum.Warning, nameof(ZapierWorkflowAction), "EXECUTE", $"Workflow '{Workflow.WorkflowDisplayName}' step 'Send page to Zapier' couldn't be processed because it is missing the webhook URL.");
            }
        }
    }
}