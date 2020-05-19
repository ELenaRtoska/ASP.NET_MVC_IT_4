using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Lab3.Models;

namespace Lab3.Controllers
{
    public class Friends1Controller : ApiController
    {
        private FriendsContext db = new FriendsContext();

        // GET: api/Friends1
        public IQueryable<FriendModel> GetFriends()
        {
            return db.Friends;
        }

        // GET: api/Friends1/5
        [ResponseType(typeof(FriendModel))]
        public IHttpActionResult GetFriendModel(int id)
        {
            FriendModel friendModel = db.Friends.Find(id);
            if (friendModel == null)
            {
                return NotFound();
            }

            return Ok(friendModel);
        }

        // PUT: api/Friends1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFriendModel(int id, FriendModel friendModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != friendModel.Id)
            {
                return BadRequest();
            }

            db.Entry(friendModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Friends1
        [ResponseType(typeof(FriendModel))]
        public IHttpActionResult PostFriendModel(FriendModel friendModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Friends.Add(friendModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = friendModel.Id }, friendModel);
        }

        // DELETE: api/Friends1/5
        [ResponseType(typeof(FriendModel))]
        public IHttpActionResult DeleteFriendModel(int id)
        {
            FriendModel friendModel = db.Friends.Find(id);
            if (friendModel == null)
            {
                return NotFound();
            }

            db.Friends.Remove(friendModel);
            db.SaveChanges();

            return Ok(friendModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FriendModelExists(int id)
        {
            return db.Friends.Count(e => e.Id == id) > 0;
        }
    }
}