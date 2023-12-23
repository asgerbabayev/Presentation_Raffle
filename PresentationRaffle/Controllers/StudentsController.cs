using Microsoft.AspNetCore.Mvc;
using PresentationRaffle.Dtos;
using PresentationRaffle.Services;

namespace PresentationRaffle.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    => _studentService = studentService;


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStudentDto student)
    {
        var success = await _studentService.Create(student);
        if (!success) return BadRequest();
        return Ok(student);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Read(int id)
    {
        var student = await _studentService.Read(id);
        if (student == null) return NotFound();
        return Ok(student);
    }

    [HttpGet]
    public async Task<IActionResult> ReadAll()
    {
        var students = await _studentService.ReadAll();
        return Ok(students);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateStudentDto student)
    {
        if (id != student.Id) return BadRequest();
        await _studentService.Update(student);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _studentService.Delete(id);
        return NoContent();
    }
}
