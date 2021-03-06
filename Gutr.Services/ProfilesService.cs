﻿using Gutr.Data;
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
                    ImageUrl = model.ImageUrl
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
                    Url = entity.Url,
                    ImageUrl = entity.ImageUrl
                };


                //return query.ToArray();
            }
        }

        public ProfileDetail GetUserProfile(string userName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Profiles
                        .Single(e => e.Email == userName);
                return
                new ProfileDetail()
                {
                    UserName = userName,
                    Name = entity.Name,
                    Summary = entity.Summary,
                    Url = entity.Url,
                    ImageUrl = entity.ImageUrl

                };
                                                            
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

