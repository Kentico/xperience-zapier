using CMS;
using CMS.Base.Web.UI;
using CMS.Helpers;
using CMS.UIControls;

[assembly: RegisterCustomClass("WebhookListingExtender", typeof(Xperience.Zapier.WebhookListingExtender))]
namespace Xperience.Zapier
{
    public class WebhookListingExtender : ControlExtender<UniGrid>
    {
        public override void OnInit()
        {
            Control.OnExternalDataBound += Control_OnExternalDataBound;
        }

        private object Control_OnExternalDataBound(object sender, string sourceName, object parameter)
        {
            switch (sourceName)
            {
                case "event":
                    var eventValue = ValidationHelper.GetInteger(parameter, -1);
                    var eventType = ZapierHelper.GetWebhookEventTypeEnum(eventValue);
                    return eventType.ToStringRepresentation();
            }

            return parameter;
        }
    }
}