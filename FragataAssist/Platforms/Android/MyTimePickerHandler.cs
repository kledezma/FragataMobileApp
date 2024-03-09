using Android.App;
using Microsoft.Maui.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragataAssist.Platforms.Android
{
    public class MyTimePickerHandler : TimePickerHandler
    {
        protected override TimePickerDialog CreateTimePickerDialog(int hour, int minute)
        {
            TimePickerDialog timePickerDialog = new(
this.Context,
                         global::Android.Resource.Style.ThemeHoloLightDialogNoActionBar,
                         (s, e) => {
                             this.VirtualView.Time = new TimeOnly(e.HourOfDay, e.Minute, 0).ToTimeSpan();
                             DateTime dateTime = DateTime.Today.Add(this.VirtualView.Time);
                             this.PlatformView.Text = dateTime.ToString("h:mm tt"); ;
                         },
this.VirtualView.Time.Hours,
this.VirtualView.Time.Minutes,
false);

            return timePickerDialog;
        }
    }

}
