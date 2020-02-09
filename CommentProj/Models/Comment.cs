using CommentProj.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommentProj.Models
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
//      public int Comment { get; set; }
        public bool IsPositive { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Country { get; set; }
        public DateTime TimeOfCreation { get; set; }
        public int? MainCommentId { get; set; }
    }
}