using DataAccess;
using DataModels;
using Microsoft.Extensions.Options;
using Models;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<UserDTO> _userRepository;
        private readonly IRepository<DrawingDTO> _drawingRepository;
        private readonly IRepository<SessionDTO> _sessionRepository;
        private readonly IRepository<PrizeDTO> _prizeRepository;
        private readonly IOptions<AppSettings> _options;

        public AdminService(IRepository<UserDTO> userRepository,
            IRepository<DrawingDTO> drawingRepository,
            IRepository<SessionDTO> sessionRepository, 
            IRepository<PrizeDTO> prizeRepository, 
            IOptions<AppSettings> options)
        {
            _userRepository = userRepository;
            _drawingRepository = drawingRepository;
            _sessionRepository = sessionRepository;
            _prizeRepository = prizeRepository;
            _options = options;
        }

        public void RegisterUser(RegisterModel model)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(model.Password));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            UserDTO user = new UserDTO()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = hashedPassword,
                Role = model.Role
            };

            _userRepository.Add(user);
        }

        public void PublishNumbers(DrawingModel drawing)
        {
            DrawingDTO newDrawing = new DrawingDTO()
            {
                SessionId = drawing.SessionId,
                DrawnNumbers = drawing.DrawnNumbers
            };

            _drawingRepository.Add(newDrawing);
        }

        public void StartSession()
        {
            SessionDTO newSession = new SessionDTO()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7)
            };

            _sessionRepository.Add(newSession);
        }

        public void AddOrUpdatePrize(PrizeModel prize)
        {
            var check = _prizeRepository.GetAll().FirstOrDefault(p => p.NumberOfHits == prize.NumberOfHits);

            PrizeDTO newPrize = new PrizeDTO()
            {
                NumberOfHits = prize.NumberOfHits,
                Prize = prize.Prize
            };

            if (check == null)
            {
                _prizeRepository.Add(newPrize);
            }
            else
            {
                _prizeRepository.Delete(check);
                _prizeRepository.Update(newPrize);
            }
        }
    }
}
