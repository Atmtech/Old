namespace ATMTECH.FishingAtWork.Entities
{
    public partial class Player
    {
        public int Level
        {
            get
            {
                //Experience
                int level = 0;

                for (int i = 1; i < 100; i++)
                {
                    int current = 0;
                    if (i == 1)
                    {
                        current = 1000;
                    }
                    else
                    {
                        current = (i*(i - 1))/2*1000;
                    }
                    if (Experience <= current)
                    {
                        level = i;
                        break;
                    }
                }
                return level;
            }
        }
    }
}
