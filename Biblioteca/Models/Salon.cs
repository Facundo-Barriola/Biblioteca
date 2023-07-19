﻿using System;
using System.Collections.Generic;

namespace Biblioteca.Models;

public class Salon
{
    public int IdSalon { get; set; }

    public string DescripcionSalon { get; set; } = null!;

    private ICollection<Estanteria> Estanteria { get; set; } = new List<Estanteria>();
}
