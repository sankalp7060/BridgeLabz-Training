using System;

namespace TechVille.Core.Services
{
    public class ArrayService
    {
        public void SortIds(int[] ids)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                for (int j = 0; j < ids.Length - 1; j++)
                {
                    if (ids[j] > ids[j + 1])
                    {
                        int temp = ids[j];
                        ids[j] = ids[j + 1];
                        ids[j + 1] = temp;
                    }
                }
            }
        }

        public int SearchId(int[] ids, int target)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i] == target)
                    return i;
            }
            return -1;
        }
    }
}
