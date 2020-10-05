using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TeamRedProject.DbContexts;
using TeamRedProject.Enitites;

namespace TeamRedProject.Services
{
    public class RealEstateRepo : IRealEstateRepo, IDisposable
    {
        private readonly RealEstateContext _context;
        private IConfiguration Configuration { get; }

        public RealEstateRepo(RealEstateContext context, IConfiguration configuration)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            this.Configuration = configuration;
        }

        //Realestate
        #region
        public void AddRealEstate(int userid, RealEstate realEstate)
        { 
            if (realEstate == null)
            {
                throw new ArgumentNullException(nameof(realEstate));
            }
            realEstate.UserId = userid;
            realEstate.AdCreated = DateTime.Now;
            if (realEstate.RentingPrice > 0) realEstate.CanBeRented = true;
            if (realEstate.PurchasePrice > 0) realEstate.CanBePurchased = true;
            _context.RealEstates.Add(realEstate);
        }

        public void UpdateRealEstate(RealEstate realEstate)
        {
            throw new NotImplementedException();
        }

        public void DeleteRealEstate(RealEstate realEstate)
        {

            if(realEstate == null)
            {
                throw new ArgumentNullException(nameof(realEstate));
            }
            _context.RealEstates.Remove(realEstate);
        }

        public RealEstate GetRealEstate(int realEstateId)
        {
            if(realEstateId <= 0)
            {
                throw new ArgumentNullException(nameof(realEstateId));
            }
            return _context.RealEstates.Include("Comments")
                .Where(r =>r.Id == realEstateId).FirstOrDefault();
        }

        public IEnumerable<RealEstate> GetRealEstates(int userId)
        {
            if(userId <= 0)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _context.RealEstates
                .Where(r => r.UserId == userId)
                .OrderBy(r => r.Title).ToList();
        }

        public IEnumerable<RealEstate> GetRealEstates(string skip, string take)
        {
            if (skip == "") skip = "0";
            if (take == "") take = "10";
            return _context.RealEstates.ToList<RealEstate>()
                .OrderByDescending(o => o.AdCreated)
                .Skip(int.Parse(skip))  
                .Take(int.Parse(take));
        }

        #endregion

        //User
        #region
        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Add(user);
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Remove(user);
        }

        public User GetUser(string Name)
        {
          if(Name == null) throw new ArgumentNullException(nameof(Name));

            return _context.Users.FirstOrDefault(a => a.UserName == Name);
        }
        public User GetUser(int userid)
        {
            return _context.Users.Include("Ratings").FirstOrDefault(a => a.Id == userid);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList<User>();
        }

        public IEnumerable<User> GetUsers(IEnumerable<int> userIds)
        {
           if(userIds == null)
            {
                throw new ArgumentNullException(nameof(userIds));
            }

            return _context.Users.Where(a => userIds.Contains(a.Id))
                 .OrderBy(a => a.UserName)
                 .ToList();
        }

        public bool UserExists(int userId)
        {
            if(userId <= 0)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _context.Users.Any(a => a.Id == userId);
        }

        public bool RateUser(string username, int userId, int value)
        {
            var user = GetUser(userId);
            var rater = GetUser(username);

            if (user == null) return false;
            if (rater == null) return false;
            if (rater.Id == user.Id) return false;

            Rating rate = new Rating
            {
                Ratings = value,
                UserId = user.Id
            };

            _context.Ratings.Add(rate);
            user.AverageRating = user.Ratings.Average(x => x.Ratings);
            return true;
        }
        #endregion

        //comment
        #region

        public Comment GetComment(int commentId, int userId)
        {
            if(commentId <= 0)
            {
                throw new ArgumentNullException(nameof(commentId));
            }
            if(userId <= 0)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _context.Comments.FirstOrDefault(a => a.Id == commentId);
        }

        public IEnumerable<Comment> GetComments(int userId)
        {
            if(userId <= 0)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return _context.Comments.Where(r => r.UserId == userId);
        }

        //behöver fixas
        public IEnumerable<Comment> GetCommentsFromRealEstate(int realEstateId, string skip, string take)
        {
            if (realEstateId <= 0)
            {
                throw new ArgumentNullException(nameof(realEstateId));
            }

            if (skip == "") skip = "0";
            if (take == "") take = "10";
            return _context.Comments.Include("Creator")
                .Where(r => r.RealEstateId == realEstateId)
                .OrderByDescending(o => o.CreatedOn)
                .Skip(int.Parse(skip))
                .Take(int.Parse(take)).ToList();
        }
        public IEnumerable<Comment> GetCommentsFromUser(string userName, string skip, string take)
        {
            var user = _context.Users.Where(x => x.UserName == userName).FirstOrDefault();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (skip == "") skip = "0";
            if (take == "") take = "10";
            return _context.Comments.ToList<Comment>()
                .Where(x => x.UserId == user.Id)
                .OrderByDescending(o => o.CreatedOn)
                .Skip(int.Parse(skip))
                .Take(int.Parse(take));
        }

        public void AddComment(string username, Comment comment)
        {
            if(comment == null)
            {
                throw new ArgumentNullException(nameof(comment));
            }
            var user = GetUser(username);
            if(user==null) throw new ArgumentNullException(nameof(user));

            comment.UserId = user.Id;
            _context.Comments.Add(comment);
        }

        public void UpdateComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(Comment comment)
        {
            if(comment == null)
            {
                throw new ArgumentNullException(nameof(comment));
            }
            _context.Comments.Remove(comment);
        }

        #endregion

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }

        public JwtSecurityToken AuthenticateUser(string name, string password)
        {
            var user = _context.Users.Where(a => a.UserName == name && a.Password == password).FirstOrDefault();
            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(Configuration["JWT:Secret"]);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, name)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

            return token; /*tokenHandler.WriteToken(token);*/
        }
    }
}
