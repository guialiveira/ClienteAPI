using System;
using System.Collections.Generic;

namespace ClienteEndereco.Models;

public partial class ClienteEndereco
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public string Logradouro { get; set; } = null!;

    public string Cep { get; set; } = null!;

    public string Uf { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public byte Status { get; set; }

    public DateTime DatInclusao { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
