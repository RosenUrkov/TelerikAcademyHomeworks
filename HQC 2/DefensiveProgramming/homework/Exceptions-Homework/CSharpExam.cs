using System;

public class CSharpExam : Exam
{
    private const int MIN_SCORE = 0;
    private const int MAX_SCORE = 100;
    
    public CSharpExam(int score)
    {
        if (score < MIN_SCORE || score >MAX_SCORE)
        {
            throw new ArgumentException($"Score must be between {MIN_SCORE} and {MAX_SCORE}.");
        }

        this.Score = score;
    }

    public int Score { get; private set; }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, MIN_SCORE, MAX_SCORE, "Exam results calculated by score.");
    }
}
