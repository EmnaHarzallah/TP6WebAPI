using System;
using System.Collections.Generic;
using TP6WebAPI.Models.DTO;

namespace TP6WebAPI.Services
{
    public interface ICategorieService
    {
        IEnumerable<CategorieDTO> Index();
        CategorieDTO Create(CategorieDTO categorie);
        CategorieDTO Edit(CategorieDTO c, Guid id);
        void Delete(Guid id);
    }
}