using Microsoft.EntityFrameworkCore;
using Vocabify.API.Data;
using Vocabify.API.Data.Entities;
using Vocabify.API.Modules.Sets.Models;

namespace Vocabify.API.Modules.Sets.Services;

public class SetsService:ISetsService
{
    private readonly SetMapper _mapper;
    private readonly ApplicationDbContext _context;

    public SetsService(ApplicationDbContext context)
    {
        _context = context;
        _mapper = new SetMapper();
    }

    public async Task<Guid> CreateAsync(CreateSetDto dto)
    {
        Set setToCreate = _mapper.CreateSetDtoToSet(dto);

        await _context.AddAsync(setToCreate);

        await _context.SaveChangesAsync();

        return setToCreate.Id;
    }

    public async Task UpdateAsync(Guid id, UpdateSetDto dto)
    {
        Set? setToUpdate = await _context.Sets.FirstOrDefaultAsync(s => s.Id == id);

        if (setToUpdate == null)
        {
            throw new Exception($"Set '{id}' not found");
        }

        _mapper.UpdateSetDtoToSet(dto,setToUpdate);

        _context.Update(setToUpdate);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        Set? setToDelete = await _context.Sets.FirstOrDefaultAsync(s => s.Id == id);

        if (setToDelete == null)
        {
            throw new Exception($"Set '{id}' not found");
        }

        _context.Sets.Remove(setToDelete);

        await _context.SaveChangesAsync();
    }
}