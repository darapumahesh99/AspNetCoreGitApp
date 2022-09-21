using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGentle.BookStore.Models;

namespace WebGentle.BookStore.Repository
{
    public class MessageRepository : IMessageRepository
    {
        public  readonly IOptionsMonitor<NewBookAlert> _newBookAlertConfiguration;
        public MessageRepository(IOptionsMonitor<NewBookAlert> newBookAlertConfiguration)
        {
            _newBookAlertConfiguration = newBookAlertConfiguration;
        }
        public string GetName()
        {
            return _newBookAlertConfiguration.CurrentValue.BookName;
        }
    }
}
