using Gutr.Data;
using Gutr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gutr.Services
{
    public class ProfilesService
    {
        private readonly Guid _userId;

        public ProfilesService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProfile(ProfileCreate model)
        {
            var entity =
                new Profile()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Summary = model.Summary,
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Profiles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public ProfileDetail GetProfile()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Profiles
                        //.Where(e => e.OwnerId == _userId)
                        //.Select(
                           // e =>
                            .Single(e => e.OwnerId == _userId);
                return
                new ProfileDetail
                {
                    //OwnerId = entity.OwnerId,
                    Name = entity.Name,
                    Summary = entity.Summary,
                    Url = entity.Url
                };
                        

                //return query.ToArray();
            }
        }

        public Profile GetProfileById()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Profiles
                        .Single(e => e.OwnerId == _userId);
                return
                    new Profile
                    {
                        Name = entity.Name,
                        Summary = entity.Summary,
                        Url = entity.Url,
                        
                    };
            }
        }
    }
}
