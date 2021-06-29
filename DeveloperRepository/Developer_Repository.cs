using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperLibrary
{
    public class DeveloperRepository
    {
        private List<DeveloperContent> _listOfDevelopers = new List<DeveloperContent>();

        //Create
        public void AddDeveloperToList(DeveloperContent content)
        {
            _listOfDevelopers.Add(content);
        }

        //Read
        public List<DeveloperContent> GetDeveloperList()
        {
            return _listOfDevelopers;
        }

        //Update
        public bool UpdateExistingContent(int originalidNumber, DeveloperContent newContent)
        {
            //Find the content
            DeveloperContent oldContent = GetContentByIdNumber(originalidNumber);

            //Update the content
            if(oldContent != null)
            {
                oldContent.IdNumber = newContent.IdNumber;
                oldContent.Name = newContent.Name;
                oldContent.PluralsightAccess = newContent.PluralsightAccess;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveContentFromList(int idNumber)
        {
            DeveloperContent content = GetContentByIdNumber(idNumber);

            if( content == null)
            {
                return false;
            }

            int initialCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(content);

            if(initialCount > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper Method
        public DeveloperContent GetContentByIdNumber(int idNumber)
        {
            foreach(DeveloperContent contnet in _listOfDevelopers)
            {
                if(contnet.IdNumber == idNumber)
                {
                    return contnet;
                }
            }

            return null;
        }
    }
}
