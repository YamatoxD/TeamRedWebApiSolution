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
        RealEstate GetRealEstate(int realEstateId);
        RealEstate GetRealEstateFromUser(string userName, int realestateId);
        void AddRealEstate(int userid, RealEstate realEstate);
        IEnumerable<RealEstate> GetRealEstates(int skip, int take);
        #endregion

        //User
        #region
        IEnumerable<User> GetUsers();
        User GetUser(string userName);
        User GetUser(int userId);
        void AddUser(User user);
        bool RateUser(string username, int userId, int value);
        #endregion

        //Comment
        #region
        IEnumerable<Comment> GetCommentsFromRealEstate(int realEstateId, int skip, int take);
        IEnumerable<Comment> GetCommentsFromUser(string userName, int skip, int take);
        void AddComment(string username, Comment comment);
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
