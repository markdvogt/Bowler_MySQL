using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bowler_MySQL.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }

        void SaveBowler(Bowler bowler);
        public void CreateBowler(Bowler b); //create or add a bowler
        public void DeleteBowler(Bowler b); //delete a bowler
    }
}
