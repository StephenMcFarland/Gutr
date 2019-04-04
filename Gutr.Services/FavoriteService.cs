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

      
        public bool CreateFavorite(FavoriteCreate model)
        {
            var entity =
                new Favorite()
                {
                    Id = _userId,
                    FavoriteBool = model.FavoriteBtn,
                    
                    //CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Favorites.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //public bool DeleteFavorite(int noteId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Notes
        //                .Single(e => e.NoteId == noteId && e.OwnerId == _userId);

        //        ctx.Favorites.Remove(entity);

        //        return ctx.SaveChanges() == 1;
        //    }
        //}
    }
}
