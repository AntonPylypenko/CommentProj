using CommentProj.Infrastracture;
using CommentProj.Models;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace CommentProj.Repositories
{
    public class CommentRepository : IRepository
    {
        private readonly CommentContext _context;

        public CommentRepository(CommentContext context)
        {
            this._context = context;
      //    CreateSomeExamples();
        }

        private void CreateSomeExamples()
        {
            Create(new Comment
            {
                Name = "Anton",
                Country = "Ukraqine",
                Text = "srt",
                IsPositive = true,
                TimeOfCreation = DateTime.Now
            });
        }

        public Comment GetById(int id)
        {
            return _context.Comments.First(e => e.Id == id);
        }

        public void Create (Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public void Delete (Comment entity)
        {
            _context.Comments.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Comment entity)
        {
            var comment = _context.Comments.FirstOrDefault(x => x.Id == entity.Id);
            comment.Name = entity.Name;
            comment.Country = entity.Country;
            comment.IsPositive = entity.IsPositive;
            comment.Text = entity.Text;
            _context.SaveChanges();

        }

        public Comment GetId(int Id)
        {
            var comment = _context.Comments.FirstOrDefault(x => x.Id == Id);
            return comment;
        }


        public IEnumerable GetAll()
        {            
                var list = _context.Comments.Where(c => c.MainCommentId == null).ToList();
                return list;          
        }

        public IEnumerable GetAllSubComments(int id)
        {
            var list = _context.Comments.Where(c => c.MainCommentId == id).ToList();
            return list;
        }



        public IEnumerable GetAllByName()
        {
            var list = _context.Comments.Select(e => e.Name).ToList();
            return list;
        }
    }
}