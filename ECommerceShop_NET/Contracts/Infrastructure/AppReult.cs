using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceShop.Contracts.Infrastructure
{
    public class AppResult
    {

        private MessageInfo _messageInfo = default!;
        public object? Data { get; set; } = default!;
        public bool Success { get; set; }
        public string? Description { get; set; }
        public int Total { get; set; }

        public void SetSuccessMessage(params string[] messages)
        {
            _messageInfo = new MessageInfo
            {
                MessageType = MessageType.Success,
                Messages = messages.Select(x => new MessageItem { Message = x }).ToList()
            };
        }

        public void SetInfoMessage(params string[] messages)
        {
            _messageInfo = new MessageInfo
            {
                MessageType = MessageType.Info,
                Messages = messages.Select(x => new MessageItem { Message = x }).ToList()
            };
        }

        public void SetWarningMessage(params string[] messages)
        {
            _messageInfo = new MessageInfo
            {
                MessageType = MessageType.Warning,
                Messages = messages.Select(x => new MessageItem { Message = x }).ToList()
            };
        }

        public void SetDangerMessage(params string[] messages)
        {
            _messageInfo = new MessageInfo
            {
                MessageType = MessageType.Danger,
                Messages = messages.Select(x => new MessageItem { Message = x }).ToList()
            };
        }


        public void SetMessage(MessageType messageType, params MessageItem[] messages)
        {
            _messageInfo = new MessageInfo
            {
                MessageType = messageType,
                Messages = messages.ToList()
            };
        }
    }


    public enum MessageType
    {
        Success = 0,
        Info = 1,
        Warning = 2,
        Danger = 3
    }

    public class MessageItem
    {
        public string FieldName { get; set; } = null!;
        public string Message { get; set; } = null!;
    }

    public class MessageInfo
    {
        public MessageInfo()
        {
            Messages = new List<MessageItem>();
        }

        public List<MessageItem> Messages { get; set; }
        public MessageType MessageType { get; set; }
    }
}

