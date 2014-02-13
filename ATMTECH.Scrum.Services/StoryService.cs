using System.Collections.Generic;
using ATMTECH.Scrum.DAO.Interface;
using ATMTECH.Scrum.Entities;
using ATMTECH.Scrum.Services.Interface;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.Scrum.Services
{
    public class StoryService : BaseService, IStoryService
    {
        public IDAOStory DaoStory { get; set; }
        public IDAOTask DaoTask { get; set; }

        public IList<Story> GetByProduct(int idProduct)
        {
            return DaoStory.GetByProduct(idProduct);
        }

        public IList<Story> GetUnlinkedStory()
        {
            // IList<Story> stories =
            //foreach (Story storey in stories)
            //{
            //    storey.Tasks = DaoTask.GetTaskByStory(storey.Id);
            //}

            return DaoStory.GetUnlinkedStory();
        }

        public int SaveStory(Story story)
        {
            return DaoStory.SaveStory(story);
        }

        public Story GetStory(int idStory)
        {
            //Story story = DaoStory.GetStory(idStory);
            //story.Tasks = DaoTask.GetTaskByStory(story.Id);
            return DaoStory.GetStory(idStory);
        }

        public Dictionary<string, string> GetListStatus()
        {

            Dictionary<string, string> liste = new Dictionary<string, string>();
            liste.Add("Done", "Terminé");
            liste.Add("Undone", "Ouverte");
            return liste;
        }

        public IList<int> GetListPoints()
        {
            IList<int> list = new List<int>();
            for (int i = 1; i < 11; i++)
            {
                list.Add(Fibonacci(i));
            }
            return list;
        }

        private int Fibonacci(int n)
        {
            int a = 0;
            int b = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }





    }
}
