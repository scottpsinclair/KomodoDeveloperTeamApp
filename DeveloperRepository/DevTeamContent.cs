using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperLibrary
{
    public class DevTeamContent
    {

        //Properties
        public List<DeveloperContent> TeamMembers { get; set; } = new List<DeveloperContent>();
        public string TeamName { get; set; }
        public int TeamId { get; set;}

        //Constructor Empty
        public DevTeamContent() { }
        //Constructor Full
        public DevTeamContent(List<DeveloperContent> teamMembers, string teamName, int teamId)
        {
            TeamMembers = teamMembers;
            TeamName = teamName;
            TeamId = teamId;
        }

        public void AddDeveloperToTeam(DeveloperContent developer)
        {
            TeamMembers.Add(developer);
        }
        
        public void RemoveDeveloperFromTeam(DeveloperContent developer)
        {
            TeamMembers.Remove(developer);
        }
    }

}
