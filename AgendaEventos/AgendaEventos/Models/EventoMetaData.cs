using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaEventos.Models
{
    [MetadataType(typeof(EventoMetadata))]
    public partial class Evento
    {
    }

    public class EventoMetadata
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A data/hora é obrigatória.")]
        [Display(Name = "Data/Hora")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "O local é obrigatório.")]
        public string Local { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}