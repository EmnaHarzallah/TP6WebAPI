using System;
using System.Collections.Generic;
using AutoMapper;
using TP6WebAPI.Models.DTO;
using TP6WebAPI.Models;
using TP6WebAPI.Data;

namespace TP6WebAPI.Services
{

    public class CategorieService : ICategorieService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategorieService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<CategorieDTO> Index()
        {
            var cats = _context.Categories.ToList();
            return _mapper.Map<List<CategorieDTO>>(cats);
        }

        public CategorieDTO Create(CategorieDTO categorie)
        {
            var cat = _mapper.Map<Categorie>(categorie);
            _context.Categories.Add(cat);
            _context.SaveChanges();
            return _mapper.Map<CategorieDTO>(cat);
        }

        public CategorieDTO Edit(CategorieDTO c, Guid id)
        {
            var cat = _context.Categories.Find(id);
            cat.Name = c.Name;
            _context.SaveChanges();
            return _mapper.Map<CategorieDTO>(cat);
        }

        public void Delete(Guid id)
        {
            var cat = _context.Categories.Find(id);
            _context.Categories.Remove(cat);
            _context.SaveChanges();
        }
    }
}