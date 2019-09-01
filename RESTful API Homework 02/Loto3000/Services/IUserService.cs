﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUserService
    {
        UserModel Authenticate(string username, string password);
        void RegisterUser(RegisterModel model);
        void FillOutTicket(TicketModel ticket);
        SessionModel IsItSessionActive();
        void FindWinners();
        IEnumerable<WinnersModel> GetWinners();
    }
}
