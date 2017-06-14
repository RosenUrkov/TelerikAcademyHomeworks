using Academy.Models.Contracts;

namespace Academy.Framework.Core.Contracts
{
    public interface ICourseForm
    {
        bool CheckForm(string formName);

        void AddStudentToCourseForm(ICourse course, IStudent student);
    }
}
