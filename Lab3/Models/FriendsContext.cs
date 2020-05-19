using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class FriendsContext : DbContext
    {
        //so ova se pravi tabela vo bazata za Friends:
        public DbSet<FriendModel> Friends { get; set; }
        public FriendsContext() : base("name=DefaultConnection")
        {
        }
        public static FriendsContext Create()
        {
            return new FriendsContext();
        }
    }
}