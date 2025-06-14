using System;
using FixerApp.Dispatcher;
using FixerApp.Models.DTOs;
using FixerApp.Models.Entities;
using FixerApp.Models.Entities.Enums;
using FixerApp.Services.Interfaces;
using FixrApp.Data;
using Microsoft.EntityFrameworkCore;

namespace FixerApp.Services.Implementations
{
    public class SupportTicketService : ISupportTicketService
    {
        private readonly ApplicationDbContext _context;
        private readonly NotificationDispatcher _dispatcher;

        public SupportTicketService(ApplicationDbContext context, NotificationDispatcher dispatcher)
        {
            _context = context;
            _dispatcher = dispatcher;
        }

        public SupportTicketDto CreateTicket(SupportTicketDto dto)
        {
            var ticket = new SupportTicket
            {
                UserId = dto.UserId,
                Message = dto.Message ?? string.Empty,
                Status = TicketStatus.Pending,
                CreatedAt = DateTime.Now
            };

            _context.SupportTicket.Add(ticket);
            _context.SaveChanges();

            return ConvertToDto(ticket);
        }

        public List<SupportTicketDto> GetTicketsByUser(long userId)
        {
            return _context.SupportTicket
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.CreatedAt)
                .Select(t => ConvertToDto(t))
                .ToList();
        }

        public List<SupportTicketDto> GetAllTickets()
        {
            return _context.SupportTicket
                .OrderByDescending(t => t.CreatedAt)
                .Select(t => ConvertToDto(t))
                .ToList();
        }

        public SupportTicketDto RespondToTicket(long ticketId, string response)
        {
            var ticket = _context.SupportTicket.Include(t => t.User).FirstOrDefault(t => t.Id == ticketId) ?? throw new Exception("Ticket not found");
            if (ticket == null) throw new Exception("Ticket not found");

            ticket.AdminResponse = response;
            ticket.Status = TicketStatus.Resolved;
            ticket.ResolvedAt = DateTime.Now;
            _context.SaveChanges();

            var user = ticket.User;
            if (user != null)
            {
                var notification = new NotificationRequestDto
                {
                    UserId = user.Id,
                    Email = user.Email ?? string.Empty,
                    Phone = user.Phone ?? string.Empty,
                    FcmToken = user.FcmToken ?? string.Empty,
                    Message = "Your support ticket has been resolved by admin.",
                    Type = NotificationType.IN_APP
                };

                _dispatcher.Dispatch(notification);
            }

            return ConvertToDto(ticket);
        }

        private SupportTicketDto ConvertToDto(SupportTicket ticket)
        {
            return new SupportTicketDto
            {
                Id = ticket.Id,
                UserId = ticket.UserId,
                Message = ticket.Message,
                AdminResponse = ticket.AdminResponse,
                Status = ticket.Status,
                CreatedAt = ticket.CreatedAt,
                ResolvedAt = ticket.ResolvedAt
            };
        }
    }
}