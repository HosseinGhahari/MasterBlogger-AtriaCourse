﻿using MB.Application.Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void Add(Comment entity);
        List<CommentViewModel> GetCommentsList();
        void Save();
    }
}
