using Microsoft.EntityFrameworkCore;
using PresentationRaffle.Data;
using PresentationRaffle.Dtos;
using PresentationRaffle.Entities;

namespace PresentationRaffle.Services;

public class StudentService : IStudentService
{
    private readonly RaffleDbContext _context;

    public StudentService(RaffleDbContext context)
    => _context = context;

    public async Task<bool> Create(CreateStudentDto studentDto)
    {
        var student = new Student
        {
            Name = studentDto.Name,
            Surname = studentDto.Surname,
            GroupNo = studentDto.GroupNo,
        };
        await _context.Students.AddAsync(student);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<GetStudentDto?> Read(int id)
    {
        var student = await _context.Students.FindAsync(id);
        return new GetStudentDto
        {
            Id = student.Id,
            Name = student.Name,
            Surname = student.Surname,
            GroupNo = student.GroupNo,
            PresentationName = student.PresentationName
        };
    }
    public async Task Update(UpdateStudentDto studentDto)
    {
        var student = await _context.Students.FindAsync(studentDto.Id);
        student.PresentationName = studentDto.PresentationName;
        await _context.SaveChangesAsync();
    }
    public async Task Delete(int id)
    {
        var student = await _context.Students.FindAsync(id);
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<GetStudentDto>> ReadAll()
    {
        var students = await _context.Students.ToListAsync();
        return students.Select(student => new GetStudentDto
        {
            Id = student.Id,
            Name = student.Name,
            Surname = student.Surname,
            GroupNo = student.GroupNo,
            PresentationName = student.PresentationName
        }).ToList();
    }
}
