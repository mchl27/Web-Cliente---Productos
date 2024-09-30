using System;
using System.Collections.Generic;

namespace Web_Client.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Empresa { get; set; }

    public string? Referencia { get; set; }

    public string? Descripcion { get; set; }

    public string? Unidad { get; set; }

    public string? Estado { get; set; }

    public string? Link { get; set; }

    public string? Proveedor { get; set; }

    public DateTime? UltimoIngreso { get; set; }

    public decimal? Precio { get; set; }
}
