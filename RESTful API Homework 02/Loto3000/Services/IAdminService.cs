using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IAdminService
    {
        void RegisterUser(RegisterModel model);
        void PublishNumbers(DrawingModel drawing);
        void StartSession();
        void AddOrUpdatePrize(PrizeModel prize);
    }
}
