using ClearnArchitecture.Domain.Entities;
using ClearnArchitecture.Domain.IRepositories;
using ClearnArchitecture.Infrastructure.Context.Persistence.MSSQLServer;
using Microsoft.EntityFrameworkCore;
namespace ClearnArchitecture.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationMSSQLServer _context;
    public StudentRepository(ApplicationMSSQLServer context)
    {
        _context = context;
    }
    public async Task<long> CreateAsync(Student student)
    {
       await _context.Students.AddAsync(student);
       await _context.SaveChangesAsync();
       return student.Id;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var student = await GetStudentByIdAsync(id);

        if (student is not null)
        {
            _context.Students.Remove(student);
            return true;
        }
        return false;
    }

    public async Task<List<Student>> GetAllStudentsAsync()
    {
        var students = await _context.Students.ToListAsync();
        return students;
    }

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        var result = await _context.Students.Where(q => q.Id == id).FirstOrDefaultAsync();
        return result;
    }

    public async Task<bool> IsExitByIdAsync(int id)
    {
        var result = await _context.Students.Where(q => q.Id == id).FirstOrDefaultAsync();
        if (result is null)
        {
            return  false;
        }
        return true;
    }

    public async Task<bool> UpdateAsync(Student student)
    {
         _context.Entry(student).State = EntityState.Modified;
         await _context.SaveChangesAsync();
         return true;
    }
}

