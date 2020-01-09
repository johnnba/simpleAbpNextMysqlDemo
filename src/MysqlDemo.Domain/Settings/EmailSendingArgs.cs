using System;
using System.Collections.Generic;
using System.Text;

namespace MysqlDemo.Settings
{
    public class EmailSendingArgs
    {
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
