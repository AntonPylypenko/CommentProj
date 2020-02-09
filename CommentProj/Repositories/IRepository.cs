using CommentProj.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentProj.Repositories
{
    public interface IRepository
    {
        void Create (Comment entity);
        void Delete (Comment entity);
        void Update(Comment entity);
        Comment GetId(int Id);
        IEnumerable GetAll();
        IEnumerable GetAllSubComments(int id);
        IEnumerable GetAllByName();
    }
}
