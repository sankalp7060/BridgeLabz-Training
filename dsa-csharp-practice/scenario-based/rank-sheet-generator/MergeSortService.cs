using System;
using System.Collections.Generic;

public class MergeSortService : IRankGenerator
{
    public List<Student> GenerateRankList(List<Student> students)
    {
        if (students.Count <= 1)
            return students;

        return MergeSort(students);
    }

    private List<Student> MergeSort(List<Student> list)
    {
        if (list.Count <= 1)
            return list;

        int mid = list.Count / 2;

        List<Student> left = list.GetRange(0, mid);
        List<Student> right = list.GetRange(mid, list.Count - mid);

        left = MergeSort(left);
        right = MergeSort(right);

        return Merge(left, right);
    }

    // Stable Merge
    private List<Student> Merge(List<Student> left, List<Student> right)
    {
        List<Student> result = new List<Student>();

        int i = 0,
            j = 0;

        while (i < left.Count && j < right.Count)
        {
            // Descending order (Highest marks first)
            if (left[i].Marks > right[j].Marks)
            {
                result.Add(left[i]);
                i++;
            }
            else if (left[i].Marks < right[j].Marks)
            {
                result.Add(right[j]);
                j++;
            }
            else
            {
                // Stability preserved
                result.Add(left[i]);
                i++;
            }
        }

        while (i < left.Count)
        {
            result.Add(left[i]);
            i++;
        }

        while (j < right.Count)
        {
            result.Add(right[j]);
            j++;
        }

        return result;
    }
}
