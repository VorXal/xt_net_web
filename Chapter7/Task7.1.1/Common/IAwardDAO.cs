using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IAwardDAO
    {
        List<Award> GetAllAwards();
        Award GetAwardByID(string id);
        void AddAward(Award award);
        void AddUser(string id, string userId);
        void RemoveAwardByID(string id);
        void UpdateDatabase(List<Award> awards);
        void EditAward(string id, string title);
    }
}
