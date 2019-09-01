using DataAccess;
using DataModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserDTO> _userRepository;
        private readonly IRepository<TicketDTO> _ticketRepository;
        private readonly IRepository<DrawingDTO> _drawingRepository;
        private readonly IRepository<SessionDTO> _sessionRepository;
        private readonly IRepository<WinnersDTO> _winnersRepository;
        private readonly IRepository<PrizeDTO> _prizeRepository;
        private readonly IOptions<AppSettings> _options;

        public UserService(IRepository<UserDTO> userRepository, 
            IRepository<TicketDTO> ticketRepository, 
            IRepository<DrawingDTO> drawingRepository,
            IRepository<SessionDTO> sessionRepository, 
            IRepository<WinnersDTO> winnersRepository,
            IRepository<PrizeDTO> prizeRepository,
            IOptions<AppSettings> options)
        {
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
            _drawingRepository = drawingRepository;
            _sessionRepository = sessionRepository;
            _winnersRepository = winnersRepository;
            _prizeRepository = prizeRepository;
            _options = options;
        }

        public UserModel Authenticate(string username, string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            var user = _userRepository.GetAll()
                .SingleOrDefault(x => x.Username == username && x.Password == hashedPassword);

            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name,
                        $"{user.FirstName} {user.LastName}"),
                        new Claim(ClaimTypes.Role, user.Role),
                        new Claim(ClaimTypes.NameIdentifier,
                        user.Id.ToString())
                    }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            UserModel userModel = new UserModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Role = user.Role,
                Token = tokenHandler.WriteToken(token)
            };

            return userModel;
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

        public void FillOutTicket(TicketModel ticket)
        {
            TicketDTO newTicket = new TicketDTO()
            {
                SessionId = ticket.SessionId,
                UserId = ticket.UserId,
                Numbers = ticket.Numbers
            };

            _ticketRepository.Add(newTicket);
        }

        public SessionModel IsItSessionActive()
        {
            IEnumerable<SessionModel> sessions = _sessionRepository.GetAll().Select(x => new SessionModel()
            {
                Id = x.Id,
                StartDate = x.StartDate,
                EndDate = x.EndDate
                
            });


            var count = sessions.Count();
            if (count == 0) return null;
            
            SessionModel session = sessions.Last();

            return session;

        }

        public void FindWinners()
        {
            IEnumerable<TicketModel> tickets = _ticketRepository.GetAll().Select(x => new TicketModel()
            {
                SessionId = x.SessionId,
                UserId = x.UserId,
                Numbers = x.Numbers
            });

            IEnumerable<DrawingModel> drawings = _drawingRepository.GetAll().Select(x => new DrawingModel()
            {
                SessionId = x.SessionId,
                DrawnNumbers = x.DrawnNumbers
            });

            foreach (var ticket in tickets)
            {
                IEnumerable<int> ticketNumbers = ticket.Numbers.Split(',').Select(Int32.Parse).ToList();
                IEnumerable<int> drawnNumbers = drawings.Last().DrawnNumbers.Split(',').Select(Int32.Parse).ToList();

                if (drawings.Last().SessionId == ticket.SessionId)
                {
                    var intersectmatchings = ticketNumbers.Intersect(drawnNumbers);

                    var hits = intersectmatchings.Count();

                    if (hits >= 3)
                    {
                        
                        var prize = _prizeRepository.GetAll().FirstOrDefault(p => p.NumberOfHits == hits);
                        var user = _userRepository.GetAll().FirstOrDefault(u => u.Id == ticket.UserId);


                        WinnersDTO winner = new WinnersDTO()
                        {
                            SessionId = ticket.SessionId,
                            UserId = ticket.UserId,
                            Hits = hits,
                            Prize = prize.Prize,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            WinningNumbers = ticket.Numbers
                        };
                        _winnersRepository.Add(winner);
                    }
                }
            }
        }

        public IEnumerable<WinnersModel> GetWinners()
        {
            var lastSession = IsItSessionActive();
            return _winnersRepository.GetAll().Where(w => w.SessionId == lastSession.Id - 1).Select(w => new WinnersModel()
            {
                SessionId = w.SessionId,
                FirstName = w.FirstName,
                LastName = w.LastName,
                WinningNumbers = w.WinningNumbers,
                Hits = w.Hits,
                Prize = w.Prize
            });
        }
    }
}
