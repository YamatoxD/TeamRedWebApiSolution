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
        RealEstate GetRealEstate(int realEstateId);
        void AddRealEstate(RealEstate realEstate);
        void UpdateRealEstate(RealEstate realEstate);
        void DeleteRealEstate(RealEstate realEstate);
        IEnumerable<RealEstate> GetRealEstates(string skip, string take);
        #endregion

        //User
        #region
        IEnumerable<User> GetUsers();

        User GetUser(string userName);
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
        IEnumerable<Comment> GetComments(int realEstateId, string skip, string take);
        IEnumerable<Comment> GetCommentsFromUser(string userName, string skip, string take);
        void AddComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(Comment comment);
        #endregion

        bool Save();
    }
}
