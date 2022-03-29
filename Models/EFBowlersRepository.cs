﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowler_MySQL.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlersDbContext _context { get; set; }
        public EFBowlersRepository (BowlersDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;

        public void SaveBowler(Bowler bowler)
        {
            _context.SaveChanges();
        }
        public void CreateBowler(Bowler b)
        {
            _context.Add(b);
            _context.SaveChanges();
        }

        public void DeleteBowler(Bowler b)
        {
            _context.Remove(b);
            _context.SaveChanges();
        }

    }
}
