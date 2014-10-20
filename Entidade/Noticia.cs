using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using VirouManchete.Entidade.Framework;

namespace VirouManchete.Entidade
{
    [Table("Noticia")]
    public partial class Noticia : DmgEntidade
    {
        [Required(ErrorMessage = "Ops. Você precisa preencher o título")]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Ops. Você precisa preencher o Subtítulo")]
        public string SubTitulo { get; set; }

        [Required(ErrorMessage = "Ops. Você precisa preencher a notícia")]
        [Display(Name = "Notícia")]
        [StringLength(5000, ErrorMessage = "Ops. Sua notícia não pode ter mais que 5000 caracteres")]
        public string Texto { get; set; }

        public string Ip { get; set; }
        public string Reporter { get; set; }
        public string Formato { get; set; }
        public string Imagem { get; set; }
        public string Legenda    { get { return Titulo; } }
        public DateTime Data     { get; set; }
        public int Visualizacoes { get; set; }

        [NotMapped]
        [Display(Name = "Imagem")]
        [File(AllowedFileExtensions = new string[] { ".jpg", ".gif", ".jpeg", ".png" }, MaxContentLength = 614400, ErrorMessage = "Ops.")] // 600kb
        public HttpPostedFileBase Upload { get; set; }
    }
}
