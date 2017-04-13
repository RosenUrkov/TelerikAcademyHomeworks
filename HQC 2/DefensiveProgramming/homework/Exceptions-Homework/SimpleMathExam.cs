using System;

public class SimpleMathExam : Exam
{
    private const int MIN_GRADE = 2;
    private const int MAX_GRADE = 6;

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0 || 2 < problemsSolved)
        {
            throw new ArgumentException("Problems solved must be integer between 0 and 2.");
        }

        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved { get; private set; }
    
    public override ExamResult Check()
    {
        if (ProblemsSolved == 0)
        {
            return new ExamResult(2, MIN_GRADE, MAX_GRADE, "Bad result: nothing done.");
        }
        else if (ProblemsSolved == 1)
        {
            return new ExamResult(4, MIN_GRADE, MAX_GRADE, "Average result: something done.");
        }
        else if (ProblemsSolved == 2)
        {
            return new ExamResult(6, MIN_GRADE, MAX_GRADE, "Awesome result: evrything done.");
        }
        else
        {
            throw new ArgumentException("Problems solved must be integer between 0 and 2.");
        }
    }
}
