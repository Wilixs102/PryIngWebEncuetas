using System;
using System.Collections.Generic;

namespace SistemaEncuestas_WP.Data;

public partial class Respuestum
{
    public int IdRespuesta { get; set; }

    public short? Calificacion { get; set; }

    public int? IdPregunta { get; set; }

    public virtual Preguntum? IdPreguntaNavigation { get; set; }
}
