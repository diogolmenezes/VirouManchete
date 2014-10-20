using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirouManchete.Entidade
{
    public class FileAttribute : ValidationAttribute
    {

        public int MaxContentLength = int.MaxValue;
        public string[] AllowedFileExtensions;
        public string[] AllowedContentTypes;

        public override bool IsValid(object value)
        {

            var file = value as HttpPostedFileBase;

            //this should be handled by [Required]
            if (file == null)
                return true;

            if (file.ContentLength > MaxContentLength)
            {
                ErrorMessage = String.Format("Ops. O arquivo é muito grande, o máximo permitido são: {0} KB", MaxContentLength / 1024);
                return false;
            }

            if (AllowedFileExtensions != null)
            {
                if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                {
                    ErrorMessage = "Ops. Os formatos permitidos são " + string.Join(", ", AllowedFileExtensions);
                    return false;
                }
            }

            if (AllowedContentTypes != null)
            {
                if (!AllowedContentTypes.Contains(file.ContentType))
                {
                    ErrorMessage = "Ops. Os formatos permitidos são " + string.Join(", ", AllowedContentTypes);
                    return false;
                }
            }

            return true;
        }
    }
}
