using Microsoft.EntityFrameworkCore;

namespace GummyWorld.Domain.Entities.Dtos.Product;

public class UpdateProductDto
{
    public int Id { get; set; }
    public required string Denumire { get; set; }
    public int Stoc { get; set; } = 0;
    [Precision(18, 2)]
    public decimal Pret { get; set; } = decimal.Zero;
}
