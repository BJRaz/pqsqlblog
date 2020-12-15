using System;
using System.Collections.Generic;

namespace postgresql.model
{
    public partial class Score
    {
        public int Id { get; set; }
        public int? FkSpil { get; set; }
        public int? FkSpiller { get; set; }
        public int? Score1 { get; set; }

        public virtual Spil FkSpilNavigation { get; set; }
        public virtual Spiller FkSpillerNavigation { get; set; }
    }
}
