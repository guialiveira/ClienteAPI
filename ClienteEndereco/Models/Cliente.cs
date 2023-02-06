using System;

namespace ClienteEndereco.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime DtNascimento { get; set; }

    public byte Status { get; set; }

    public DateTime DatInclusao { get; set; }

    public virtual ICollection<ClienteEndereco> ClienteEnderecos { get; } = new List<ClienteEndereco>();
}
