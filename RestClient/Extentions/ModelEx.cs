using System;

namespace RestClient.Extentions
{
    public static class ModelEx
    {
        public static void RaiseEvent(this EventHandler @event, object sender, EventArgs e)
        {
            if (@event != null)
            {
                @event(sender, e);
            }
        }
    }
}
