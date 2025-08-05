namespace Beauty1.Models
{
    public partial class FileImg
    {
        public void Create(CustomContext context, DtoFile dto)
        {
            string filename = Path.GetFileNameWithoutExtension(dto.file.FileName) + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + Path.GetExtension(dto.file.FileName);
            string path = Path.Combine("wwwroot", "uploads", filename);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                dto.file.CopyTo(stream);
            }
            FileName = filename;
            FilePath = $"/uploads/{filename}";
            context.FileImgs.Add(this);
            context.SaveChanges();

        }
    }
}
