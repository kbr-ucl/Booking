﻿using System;

namespace Booking.Application.Commands
{
    public class CreateBookingRequest
    {
        public Guid CalenderId { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }
    }
}