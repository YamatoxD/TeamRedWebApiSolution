using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamRedProject.Enitites;

namespace TeamRedProject.Services
{
    public interface IRealEstateRepo
    {
        //Realestate
        #region
        IEnumerable<RealEstate> GetRealEstates(int userId);
        RealEstate GetRealEstate(int realEstateId, int userId);
        void AddRealEstate(int userId, RealEstate realEstate);
        void UpdateRealEstate(RealEstate realEstate);
        void DeleteRealEstate(RealEstate realEstate);
        #endregion

        //User
        #region
        IEnumerable<User> GetUsers();
        User GetUser(int userId);
        IEnumerable<User> GetUsers(IEnumerable<int> userIds);
        void AddUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
        bool UserExists(int userId);
        #endregion

        //Comment
        #region
        Comment GetComment(int commentId, int userId);
        IEnumerable<Comment> GetComments(int userId);
        void AddComment(Comment comment, int userId);
        void UpdateComment(Comment comment);
        void DeleteComment(Comment comment);
        #endregion

        bool Save();
    }
}
