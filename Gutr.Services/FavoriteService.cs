using Gutr.Data;
using Gutr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutr.Services
{
    public class FavoriteService
    {
        private readonly Guid _userId;

        public FavoriteService(Guid userId)
        {
            _userId = userId;
        }

        public bool SetFavorite()//FavoriteCreate model)
        {
            var entity =
               new Data.Favorite()
               {
                   OwnerId = _userId,
                   //FavoriteId = 22,//model.FavoriteId,
                   //NoteId = id//NoteId//model.NoteId,
                   //CreatedUtc = DateTimeOffset.Now
               };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Favorites.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool SetFavorite(int id)//FavoriteCreate model)
        {
            var entity =
               new Data.Favorite()
               {
                   OwnerId = _userId,
                   //FavoriteId = 22,//model.FavoriteId,
                   NoteId = id//NoteId//model.NoteId,
                   //CreatedUtc = DateTimeOffset.Now
               };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Favorites.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UnSetFavorite(int noteId)//FavoriteCreate model)
        {
           using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Favorites
                        .FirstOrDefault(e => e.NoteId == noteId && e.OwnerId == _userId);

                ctx.Favorites.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<NoteListItem> GetMyFavorites()
        {
            using (var ctx = new ApplicationDbContext())
            {
                //var FavoritesNoteId = ctx.Favorites.FirstOrDefault(u => u.OwnerId == c.OwnerId).NoteId;

                var query = 
                    ctx
                        .Favorites
                        .Where(e => e.OwnerId == _userId)// && e.NoteId == ctx.Favorites.FirstOrDefault(c => c.OwnerId == e.OwnerId).NoteId)
                        .Select(
                            e =>
                                new NoteListItem
                                {
                                    userEmail = ctx.Users.FirstOrDefault(u => u.Id == e.OwnerId.ToString()).Email.Substring(0, 5),
                                    Author = ctx.Notes.FirstOrDefault(c => c.NoteId == e.NoteId).Email,
                                    NoteId = e.NoteId,//ctx.Favorites.FirstOrDefault(c => c.OwnerId == e.OwnerId).NoteId,
                                    //NoteId = ctx.Favorites.FirstOrDefault(c => c.NoteId == e.NoteId),
                                    //Title = ctx.Notes.FirstOrDefault(c => c.OwnerId == e.OwnerId).Title,
                                    Title = ctx.Notes.FirstOrDefault(c => c.NoteId == e.NoteId).Title,
                                    //Content = ctx.Notes.FirstOrDefault(c => c.OwnerId == e.OwnerId).Content
                                    Content = ctx.Notes.FirstOrDefault(c => c.NoteId == e.NoteId).Content
                                    //IsStarred = e.IsStarred,
                                    //CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }


        public bool CreateNote(NoteCreate model)
        {
            var entity =
                new Note()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Content = model.Content,
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
                                    userEmail = e.Email,//ctx.Users.FirstOrDefault(u => u.Id == e.OwnerId.ToString()).Email.Substring(0, 5),
                                    NoteId = e.NoteId,
                                    Title = e.Title,
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
                        .Favorites
                        .Single(e => e.NoteId == model.NoteId && e.OwnerId == _userId);

                //entity.FavoriteId = model.FavoriteId;
                //entity.OwnerId = model.OwnerId;
                entity.NoteId = model.NoteId;
                //entity.ModifiedUtc = DateTimeOffset.UtcNow;
                //entity.IsStarred = model.IsStarred;

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
