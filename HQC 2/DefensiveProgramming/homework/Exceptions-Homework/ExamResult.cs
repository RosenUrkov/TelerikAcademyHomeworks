using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentException("The grade must be positive integer.");
        }

        if (minGrade < 0)
        {
            throw new ArgumentException("The min grade must be positive integer.");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("The max grade must be higher than min grade.");
        }

        if (comments == null || comments == "")
        {
            throw new ArgumentException("Comments must be correct non empty string");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }


    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }
}
