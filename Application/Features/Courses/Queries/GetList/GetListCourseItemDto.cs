﻿using Domain.Entities;

namespace Application.Features.Courses.Queries.GetList;

public class GetListCourseItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int TotalPaticipants { get; set; }
    public DateTime CreatedDate { get; set; }
}

