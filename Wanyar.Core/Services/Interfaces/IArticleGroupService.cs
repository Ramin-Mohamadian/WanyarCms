using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanyar.DataLayer.Entities;

namespace Wanyar.Core.Services.Interfaces
{
    public interface IArticleGroupService
    {
        List<ArticleGroup> GetAllArticleGroups();
        void AddGroup(ArticleGroup group);
        void UpdateGroup(ArticleGroup group);
        ArticleGroup GetGroupById(int id);
    }
}
