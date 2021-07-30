using System;
using System.Collections.Generic;
using System.Text;

namespace KRG_SES_APP.Models.MessagingSystem
{
    public class Message
    {
        public Guid GUID { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }

        public MessageCatagory messageCatagory;
        public string CatagoryName => messageCatagory.Name;
        public string CatagoryIcon => messageCatagory.IconURL;
        public string TimeSinceCreated
        {
            get
            {
                TimeSpan span = DateTime.Now - CreatedTime;

                if (span.TotalSeconds <= 60)
                    return $"{Math.Floor(span.TotalSeconds)} seconds ago";
                else if (span.TotalMinutes <= 60)
                    return $"{Math.Floor(span.TotalMinutes)} mins ago";
                else
                    return $"{Math.Floor(span.TotalHours)} hours ago";
            }
        }

        public Message(MessageCatagory messageCatagory)
        {
            this.messageCatagory = messageCatagory;
            GUID = Guid.NewGuid();
            CreatedTime = DateTime.Now;
        }
    }
}
