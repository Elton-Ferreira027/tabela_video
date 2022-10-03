using System.ComponentModel.DataAnnotations;

namespace video.Models
{
    public class Video
    {
        [Key]
        public int VideoID { get; set; }
        [Required]
        public string VideoAutor { get; set; }
        [Required]
        public string VideoTitulo { get; set; }
        [Required]
        public string LocalGravação { get; set; }
        [Required]
        public string VideoTipo { get; set; }
        [Required]
        public string VideoExtencao { get; set; }
        [Required]
        public string VideoDuracao { get; set; }
        [Required]
        public string VideoAssunto { get; set; }
        [Required]
        public string VideoDescricao { get; set; }
    }
}
