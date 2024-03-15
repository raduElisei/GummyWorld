using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GummyWorld.Domain.Entities.Models;

public class Product
{
    public int Id { get; set; }
    [StringLength(100)]
    public required string Denumire { get; set; }
    public int Stoc { get; set; } = 0;
    [Precision(18, 2)]
    public decimal Pret { get; set; } = decimal.Zero;
}
