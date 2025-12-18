using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TP6WebAPI.Models.DTO;
using TP6WebAPI.Services;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin,Customer")]
public class CategorieController : ControllerBase
{
    private readonly ICategorieService service;

    public CategorieController(ICategorieService service)
    {
        this.service = service;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(service.Index());

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Create(CategorieDTO dto) => Ok(service.Create(dto));

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Edit(Guid id, CategorieDTO dto)
        => Ok(service.Edit(dto, id));

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(Guid id)
    {
        service.Delete(id);
        return Ok();
    }
}
