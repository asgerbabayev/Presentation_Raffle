﻿namespace PresentationRaffle.Dtos;

public class GetStudentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string GroupNo { get; set; } = null!;
    public string PresentationName { get; set; } = null!;
}
