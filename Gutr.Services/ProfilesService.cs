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
                    //Email = ctx.Users.FirstOrDefault(u => u.Id == e.OwnerId.ToString()).Email
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

        public ProfileDetail GetUserProfile(string userName)
        {
            //    using (var ctx = new ApplicationDbContext())
            //    {

            //    var entity =
            //     ctx
            //         .Profiles
            //             //.Where(e => e.OwnerId == _userId)
            //             //.Select(
            //             // e =>
            //             .Single(e => e.OwnerId == _userId);
            //return
            //new ProfileDetail
            //{
            //        //OwnerId = entity.OwnerId,
            //        Name = entity.Name,
            //    Summary = entity.Summary,
            //    Url = entity.Url
            //};

            //using (var ctx = new ApplicationDbContext())
            //{
            //    var query =
            //        ctx
            //            .Notes
            //            .Where(e => e.Email == userName)
            //            .Select(
            //                e =>

            //                new ProfileDetail
            //                {
            //                        // userEmail = ctx.Users.FirstOrDefault(u => u.Id == e.OwnerId.ToString()).Email.Substring(0, 5),
            //                        Name = ctx.Profiles.FirstOrDefault(c => c.OwnerId == e.OwnerId).Name,
            //                    Summary = ctx.Profiles.FirstOrDefault(c => c.OwnerId == e.OwnerId).Summary,
            //                    Url = ctx.Profiles.FirstOrDefault(c => c.OwnerId == e.OwnerId).Url
            //                }
            //            );

            //    return query.ToArray();
            //}
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Profiles
                            .Where(e => e.Email == userName)
                            .Select(
                             e =>
                //.Single(e => e.OwnerId);
                //return
                new ProfileDetail
                {
                    //OwnerId = entity.OwnerId,
                    Name = e.Name,
                    Summary = e.Summary,
                    Url = e.Url,

                }


                );

                return query.ToArray();
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

            public bool DeleteProfile()
            {

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Profiles
                            .Single(e => e.OwnerId == _userId);

                    ctx.Profiles.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }

            }
        }
    }

