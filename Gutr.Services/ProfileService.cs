using Gutr.Data;
using Gutr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gutr.Services
{
    public class ProfileService
    {
        private readonly Guid _userId;

        public ProfileService(Guid userId)
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

        public IEnumerable<ProfileEdit> GetProfile()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Profiles
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ProfileEdit
                                {
                                    OwnerId = e.OwnerId,
                                    Name = e.Name,
                                    Summary = e.Summary,
                                    Url = e.Url
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
