using System;
using System.Collections.Generic;

namespace postgresql.model
{
    public partial class Spiller
    {
        public Spiller()
        {
            Score = new HashSet<Score>();
            Spil = new HashSet<Spil>();
        }

        public int Id { get; set; }
        public string Navn { get; set; }

        public virtual ICollection<Score> Score { get; set; }
        public virtual ICollection<Spil> Spil { get; set; }
    }
}
