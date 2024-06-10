﻿using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;
        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Add(AddComment command)
        {
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.Add(comment);
        }

        public void Cancel(long id)
        {
            var comment = _commentRepository.GetById(id);
            comment.Cancel();
            _commentRepository.Save();
        }

        public void Confirm(long id)
        {
            var comment = _commentRepository.GetById(id);
            comment.Confirm();
            _commentRepository.Save();
        }

        public List<CommentViewModel> GetCommentsList()
        {
           return _commentRepository.GetCommentsList();
        }
    }
}
