using System;
using System.Collections.Generic;

namespace SistemaEncuestas_WP.Data;

public partial class Preguntum
{
    public int Id { get; set; }

    public string Pregunta { get; set; }

    public string NombreArea { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<Respuestum> Respuesta { get; set; } = new List<Respuestum>();
}
