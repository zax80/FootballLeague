//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FootballLeague.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Match
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public int HomeTeam { get; set; }
        public int AwayTeam { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    
        public virtual Team Team { get; set; }
        public virtual Team Team1 { get; set; }
    }
}
