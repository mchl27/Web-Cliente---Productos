﻿using System;
using System.Collections.Generic;

namespace Web_Client.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public DateTime? Creacion { get; set; }

    public int? Identificacion { get; set; }

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public string? Username { get; set; }

    public string? Contraseña { get; set; }

    public string? Estado { get; set; }

    public int? IdRol { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }
}
