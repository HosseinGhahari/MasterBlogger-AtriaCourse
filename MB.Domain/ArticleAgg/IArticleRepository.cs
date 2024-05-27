﻿using MB.Application.Contracts.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetArticles();
        void Create(Article entity);
        Article GetById(long id);
        bool Exist(string titile);
        void Save();
    }
}
