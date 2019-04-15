using Gutr.Data;
using Gutr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Gutr.Services
{
    public class NoteService
    {
        private readonly Guid _userId;

        public NoteService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateNote(NoteCreate model, String userName)
        {
            //var timestamp = DateTimeOffset.Now.ToString().Substring(0, 18);
            

            var checkHttp = model.Content.Substring(0, 8);
            if (checkHttp != "https://")
            {
                model.Content = "https://" + model.Content;
            }
            var entity =
                new Note()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    Email = userName,// User.Identity.GetUserName(),
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

       public IEnumerable<NoteListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Notes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new NoteListItem
                                {
                                    NoteId = e.NoteId,
                                    Title = e.Title,
                                    Content = e.Content,
                                    IsStarred = e.IsStarred,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

       

        public IEnumerable<NoteListItem> GetAllPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                //string value;
                var query =
                    ctx
                        .Notes
                        .Where(e => e.NoteId > 0)
                        .Select(
                            e =>
                                new NoteListItem
                                {
                                    //userEmail = ctx.Users.FirstOrDefault(u => u.Id == e.OwnerId.ToString()).Email,
                                    userEmail = ctx.Users.FirstOrDefault(u => u.Id == e.OwnerId.ToString()).Email.Substring(0,5),
                                    NoteId = e.NoteId,
                                    Title = e.Title,
                                    Content = e.Content,
                                    IsStarred = e.IsStarred,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public IEnumerable<NoteListItem> GetAllFavorites()
        {
            using (var ctx = new ApplicationDbContext())
            {
                
                //string value;
                var query =
                    ctx
                        .Notes
                        .Where(e => e.IsStarred == true)
                        .Select(
                            e =>
                                new NoteListItem
                                {
                                    //userEmail = ctx.Users.FirstOrDefault(u => u.Id == e.OwnerId.ToString()).Email,
                                    userEmail = ctx.Users.FirstOrDefault(u => u.Id == e.OwnerId.ToString()).Email.Substring(0, 5),
                                    NoteId = e.NoteId,
                                    Title = e.Title,
                                    Content = e.Content,
                                    IsStarred = e.IsStarred,
                                    CreatedUtc = e.CreatedUtc
                                    
                                }
                        );

                return query.ToArray();
            }
        }

        public NoteDetail GetNoteById(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == noteId && e.OwnerId == _userId);
                return
                    new NoteDetail
                    {
                        NoteId = entity.NoteId,
                        Title = entity.Title,
                        Content = entity.Content,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateNote(NoteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == model.NoteId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                entity.IsStarred = model.IsStarred;

                return ctx.SaveChanges() == 1;
            }
                
        }

        public bool DeleteNote(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == noteId && e.OwnerId == _userId);

                ctx.Notes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
