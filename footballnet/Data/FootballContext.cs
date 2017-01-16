using footballnet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace footballnet.Data
{

    public class FootballContext : DbContext
    {

        public FootballContext() : base()
        {
        }

        public DbSet<GameRecord> GameRecord { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Referee> Referee { get; set; }
        public DbSet<ChangeRecord> ChangeRecord { get; set; }
        public DbSet<Change> Change { get; set; }
        public DbSet<GoalRecord> GoalRecord { get; set; }
        public DbSet<Goal> Goal { get; set; }
        public DbSet<PenaltyRecord> PenaltyRecord { get; set; }
        public DbSet<Penalty> Penalty { get; set; }
        public DbSet<PlayerNrRecord> PlayerNrRecord { get; set; }
        public DbSet<PlayerNr> PlayerNr { get; set; }
        public DbSet<PlayerRecord> PlayerRecord { get; set; }
        public DbSet<Player> Player { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}