using ClearnArchitecture.Domain.Entities;

namespace ClearnArchitecture.Domain.IRepositories
{
    public interface IStudentRepository
    {

        Task<List<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        Task<long> CreateAsync(Student student);
        Task<bool> UpdateAsync(Student student);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsExitByIdAsync(int id);
    }
}
