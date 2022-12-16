﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        Task AddMessageAsync(Message message, string senderUserName, string receiverUserName);
        Task UpdateMessageAsync(Message message, string userName);
        Task DeleteMessageAsync(int id, string userName);
        Task<bool> DeleteMessagesAsync(List<string> ids, string userName);
        Task<Message> GetByIdAsync(int id);
        Task<Message> GetByFilterAsync(Expression<Func<Message, bool>> filter = null);
        Task<int> GetCountAsync(Expression<Func<Message, bool>> filter = null);
        Task<List<Message>> GetInboxWithMessageListAsync(int id, Expression<Func<Message, bool>> filter = null);
        Task<List<Message>> GetSendBoxWithMessageListAsync(int id, Expression<Func<Message, bool>> filter = null);
        Task<Message> GetReceivedMessageAsync(int id, Expression<Func<Message, bool>> filter = null);
        Task<Message> GetSendMessageAsync(int id, Expression<Func<Message, bool>> filter = null);
        Task<bool> MarkChangedAsync(int messageId, string userName);
        Task<bool> MarkUsReadAsync(int messageId, string userName);
        Task<bool> MarksUsReadAsync(List<string> messageIds, string userName);
        Task<bool> MarkUsUnreadAsync(int messageId, string userName);
        Task<Message> GetByFilterFileName(Expression<Func<Message, bool>> filter = null);
    }
}
