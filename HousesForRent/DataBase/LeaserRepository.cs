using HousesForRent.Helpers;
using HousesForRent.Models;
using HousesForRent.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HousesForRent.DataBase
{
    public class LeaserRepository : Repository<LeasersInformation>
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public string GetUserId(string email)
        {
            return context.Users.FirstOrDefault(e => e.Email == email).Id;
        }

        
        public List<LeasersInformationViewModel> GetListingsById(string UserId)
        {
            var v = context.LeasersInformations.Include(z => z.Location).Where(x => x.UserId == UserId).ToList();
            var list = v.ToViewModel<LeasersInformation, LeasersInformationViewModel>().ToList();
            foreach(var l in list)
            {
                l.IsExpired = l.Expiration < DateTime.Now;
            }
            return list;
            
        }

        public List<LocationViewModel> GetAllLocations()
        {
            return context.Locations.ToList().ToViewModel<Location, LocationViewModel>().ToList();
        }

        private Location GetLocation(int id)
        {
            return context.Locations.Where(x => x.Id == id).FirstOrDefault();
        }

        public LocationViewModel GetLocationById(int id)
        {
            return context.Locations.Where(x => x.Id == id).FirstOrDefault()
                .ToViewModelSingle<Location, LocationViewModel>();
        }

        public void AddHouse(LeasersInformation info)
        {
            context.LeasersInformations.Attach(info);
            context.LeasersInformations.Add(info);
            context.SaveChanges();
        }

        public void Update(LeasersInformation info)
        {
            context.Entry(info).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void UploadImage(string fileName, int Id)
        {
            context.Pictures.Add(new Pictures { Picture = fileName, FileName = Id });
            context.SaveChanges();
        }

        public int AmountOfPicturesById(int Id)
        {
            return context.Database.SqlQuery<int>($"exec PictureAmount @Id = {Id}").FirstOrDefault();
        }

        public List<Pictures> GetPicturesById(int PicId)
        {
            return context.Pictures.Where(x => x.FileName == PicId).ToList();
        }

        public void DeletePicturesById(int PicId)
        {
            Pictures pictures = new Pictures { Id = PicId };
            context.Pictures.Attach(pictures);
            context.Pictures.Remove(pictures);
            context.SaveChanges();
        }

        public void PauseListing(int Id, string user)
        {
            bool pause = true;

            var listing = context.LeasersInformations.Where(x => x.Id == Id && x.UserId == user).FirstOrDefault();
            if (listing.Paused)
            {
                pause = false;
            }
            context.Database.ExecuteSqlCommand(@"update LeasersInformations set Paused = @pause
                                                 where id = @id and UserId = @userid",
                                                 new SqlParameter("@id",Id),
                                                 new SqlParameter("@userid", user),
                                                 new SqlParameter("@pause", pause));
            context.SaveChanges();
            
        }

        public void RenewAdById(LeasersInformation user)
        {
            user.Expiration = DateTime.Now.AddMonths(2);
            Update(user);
        }

        public void DeleteListing(int listingId)
        {
            LeasersInformation LI = new LeasersInformation { Id = listingId };
            context.LeasersInformations.Attach(LI);
            context.LeasersInformations.Remove(LI);
            context.SaveChanges();
        }

    }
}