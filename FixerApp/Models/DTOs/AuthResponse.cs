﻿namespace FixerApp.Models.DTOs
{
    public class AuthResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? Token { get; set; }
        public long? UserId { get; set; }
        public string? Role { get; set; }
    }
}
