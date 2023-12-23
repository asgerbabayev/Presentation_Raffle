using PresentationRaffle.Dtos;

namespace PresentationRaffle.Services;

public interface IStudentService
{
    Task<bool> Create(CreateStudentDto student);
    Task<GetStudentDto> Read(int id);
    Task<ICollection<GetStudentDto>> ReadAll();
    Task Update(UpdateStudentDto student);
    Task Delete(int id);
}
