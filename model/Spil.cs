using System;
using System.Collections.Generic;

namespace postgresql.model
{
    public partial class Spil
    {
        public Spil()
        {
            Score = new HashSet<Score>();
        }

        public int Id { get; set; }
        public DateTime? DatoOprettet { get; set; }
        public DateTime? DatoSpil { get; set; }
        public int? Pris { get; set; }
        public int? Betaler { get; set; }

        public virtual Spiller BetalerNavigation { get; set; }
        public virtual ICollection<Score> Score { get; set; }
    }
}
