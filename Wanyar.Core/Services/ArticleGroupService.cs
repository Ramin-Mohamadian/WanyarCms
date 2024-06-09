using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanyar.Core.Services.Interfaces;
using Wanyar.DataLayer.Context;
using Wanyar.DataLayer.Entities;

namespace Wanyar.Core.Services
{
    public class ArticleGroupService : IArticleGroupService
    {
        WanyarContext _context;
        public ArticleGroupService(WanyarContext context)
        {
            _context = context;
        }

        public void AddGroup(ArticleGroup group)
        {
           _context.ArticleGroups.Add(group);
            _context.SaveChanges();
        }

        public List<ArticleGroup> GetAllArticleGroups()
        {
            return _context.ArticleGroups.Include(g=>g.ArticleGroups).ToList();
        }

        public ArticleGroup GetGroupById(int id)
        {
            return _context.ArticleGroups.Find(id);
        }

        public void UpdateGroup(ArticleGroup group)
        {
            _context.ArticleGroups.Update(group);
            _context.SaveChanges();
        }
    }
}
