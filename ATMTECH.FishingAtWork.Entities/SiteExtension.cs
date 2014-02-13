using System.Collections.Generic;

namespace ATMTECH.FishingAtWork.Entities
{
    public partial class Site
    {
        public IList<int> DeepList
        {
            get
            {
                IList<int> deep = new List<int>();
                for (int i = 0; i < MaxDeep; i++)
                {
                    deep.Add(i);
                }
                return deep;
            }
        }

    }
}
