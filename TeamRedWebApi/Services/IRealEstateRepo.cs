using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TeamRedProject.Enitites;
using TeamRedWebApi.Enitites;

namespace TeamRedProject.Services
{
#pragma warning disable CS1591
    public interface IRealEstateRepo
    {
        //RealEstate
        #region
        IEnumerable<RealEstate> GetRealEstates(int userId);
        RealEstate GetRealEstate(int realEstateId);
        RealEstate GetRealEstateFromUser(string userName, int realestateId);
        void AddRealEstate(int userid, RealEstate realEstate);
        void UpdateRealEstate(RealEstate realEstate);
        void DeleteRealEstate(RealEstate realEstate);
        IEnumerable<RealEstate> GetRealEstates(int skip, int take);
        #endregion

        //User
        #region
        IEnumerable<User> GetUsers();
        User GetUser(string userName);
        User GetUser(int userId);
        IEnumerable<User> GetUsers(IEnumerable<int> userIds);
        void AddUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
        bool UserExists(int userId);
        bool RateUser(string username, int userId, int value);
        #endregion

        //Comment
        #region
        Comment GetComment(int commentId, int userId);
        IEnumerable<Comment> GetComments(int userId);
        IEnumerable<Comment> GetCommentsFromRealEstate(int realEstateId, int skip, int take);
        IEnumerable<Comment> GetCommentsFromUser(string userName, int skip, int take);
        void AddComment(string username, Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(Comment comment);
        #endregion

        //Image
        #region Image
        Image AddImage(int realestateId, string imageUrl, string title);
        Image GetImage(int imageId);
        IEnumerable<Image> GetImageFromRealEstate(int realestatId);
        #endregion

        JwtSecurityToken AuthenticateUser(string name, string password);

        bool Save();
    }
#pragma warning restore CS1591
}
