using Android;
using Android.App;
using Android.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeteoApp.Models
{
    [Service]
    class NotificationService : Service
    {
        const int NOTIFICATION_ID = 9000;

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            // Code omitted for clarity - here is where the service would do something.

            // Work has finished, now dispatch anotification to let the user know.
            Notification.Builder notificationBuilder = new Notification.Builder(this)
                .SetSmallIcon(Resource.Drawable.ic_notification_small_icon)
                .SetContentTitle(Resources.GetString(Resource.String.notification_content_title))
                .SetContentText(Resources.GetString(Resource.String.notification_content_text));

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.Notify(NOTIFICATION_ID, notificationBuilder.Build());
        }
    }
}
