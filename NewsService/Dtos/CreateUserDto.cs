﻿namespace NewsService.Dtos;

public class CreateUserDto
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
}