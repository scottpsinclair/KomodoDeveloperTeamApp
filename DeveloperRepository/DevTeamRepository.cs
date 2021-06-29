using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperLibrary
{
    public class DevTeamRepository
    {
        private List<DevTeamContent> _listOfTeams = new List<DevTeamContent>();

        //Create
        public void AddTeamToList(DevTeamContent content)
        {
            _listOfTeams.Add(content);
        }

        //Read
        public List<DevTeamContent> GetTeamList()
        {
            return _listOfTeams;
        }

        //Update
        public bool UpdateExistingTeam(int originalTeamId, DevTeamContent newContent)
        {
            //Find the content
            DevTeamContent oldContent = GetContentByTeamId(originalTeamId);

            //Update the team
            if(oldContent != null)
            {
                oldContent.TeamMembers = newContent.TeamMembers;
                oldContent.TeamName = newContent.TeamName;
                oldContent.TeamId = newContent.TeamId;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveTeamFromList(int teamId)
        {
            DevTeamContent content = GetContentByTeamId(teamId);

            if( content == null)
            {
                return false;
            }

            int initialCount = _listOfTeams.Count;
            _listOfTeams.Remove(content);

            if(initialCount > _listOfTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper Method
        public DevTeamContent GetContentByTeamId(int teamId)
        {
            foreach (DevTeamContent content in _listOfTeams)
            {
                if(content.TeamId == teamId)
                {
                    return content;
                }
            }

            return null;
        }
    }
}
