using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamRedProject.DbContexts;
using TeamRedProject.Enitites;

namespace TeamRedProject.Services
{
    public class RealEstateRepo : IRealEstateRepo, IDisposable
    {
        private readonly RealEstateContext _context;

        public RealEstateRepo(RealEstateContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //Realestate
        #region
        public void AddRealEstate(RealEstate realEstate)
        {
            //if(userId <= 0)
            //{
            //    throw new ArgumentNullException(nameof(userId));
            //}
            if(realEstate == null)
            {
                throw new ArgumentNullException(nameof(realEstate));
            }
            //realEstate.UserId = userId;
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
            return _context.RealEstates
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
            if (skip == null) skip = "0";
            if (take == null) take = "10";
            return _context.RealEstates.ToList<RealEstate>()
                .OrderByDescending(o => o.adCreated)
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

        public User GetUser(string userName)
        {
           if(userName== null) throw new ArgumentNullException(nameof(userName));

            return _context.Users.FirstOrDefault(a => a.Name == userName);
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
                 .OrderBy(a => a.Name)
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

        public IEnumerable<Comment> GetComments(int realEstateId, string skip, string take)
        {
            if (realEstateId <= 0)
            {
                throw new ArgumentNullException(nameof(realEstateId));
            }

            if (skip == null) skip = "0";
            if (take == null) take = "10";
            return _context.Comments.ToList<Comment>()
                .OrderByDescending(o => o.CreatedOn)
                .Skip(int.Parse(skip))
                .Take(int.Parse(take));
        }

        public IEnumerable<Comment> GetCommentsFromUser(string userName, string skip, string take)
        {

            var user = _context.Users.Where(x => x.Name == userName).FirstOrDefault();
            
            if (skip == null) skip = "0";
            if (take == null) take = "10";
            return _context.Comments.ToList<Comment>()
                .Where(x => x.UserId == user.Id)
                .OrderByDescending(o => o.CreatedOn)
                .Skip(int.Parse(skip))
                .Take(int.Parse(take));
        }

        public void AddComment(Comment comment)
        {
            if(comment == null)
            {
                throw new ArgumentNullException(nameof(comment));
            }
            //if(userId <= 0)
            //{
            //    throw new ArgumentNullException(nameof(userId));
            //}
            //comment.UserId = userId;
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
    }
}
