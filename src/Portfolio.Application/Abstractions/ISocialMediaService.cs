using Portfolio.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Abstractions
{
    public interface ISocialMediaService
    {
        Task<IReadOnlyList<SocialMediaDto>> GetAsync(CancellationToken ct);
        Task<SocialMediaDto?> GetByIdAsync(long id, CancellationToken ct);
        Task<SocialMediaDto> CreateAsync(SocialMediaCreateUpdateDto dto, CancellationToken ct);
        Task<bool> UpdateAsync(long id, SocialMediaCreateUpdateDto dto, CancellationToken ct);
        Task<bool> DeleteAsync(long id, CancellationToken ct);
    }
}
