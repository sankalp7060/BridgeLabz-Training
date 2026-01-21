using System.Collections.Generic;

public interface IRankGenerator
{
    List<Student> GenerateRankList(List<Student> students);
}
