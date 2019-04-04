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

        //public bool UpdateNote(NoteEdit model)
        public bool CreateFavorite(FavoriteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Favorites
                        .Single(e => e.Id == model.NoteId);// && e.OwnerId == _userId);

                entity.FavoriteBool = model.Favoritebtn;
                //entity.Content = model.Content;
                //entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        //public bool CreateNote(NoteCreate model)
        //{
        //    var entity =
        //        new Note()
        //        {
        //            OwnerId = _userId,
        //            Title = model.Title,
        //            Content = model.Content,
        //            CreatedUtc = DateTimeOffset.Now
        //        };

        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        ctx.Notes.Add(entity);
        //        return ctx.SaveChanges() == 1;
        //    }
        //}

        public bool DeleteFavorite(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == noteId && e.OwnerId == _userId);

                ctx.Favorites.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
