using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models
{
    public partial  class CustomContext : BeautysDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Component>().UseTptMappingStrategy().ToTable("Component");
            modelBuilder.Entity<Banner>().ToTable("Banner");
            modelBuilder.Entity<TextBox>().ToTable("TextBox");
            modelBuilder.Entity<ImageWithCaption>().ToTable("ImageWithCaption");
            modelBuilder.Entity<GridTwoColumn>().ToTable("GridTwoColumn");
            modelBuilder.Entity<ImageDesc>().ToTable("ImageDesc");
            modelBuilder.Entity<GridFourImage>().ToTable("GridFourImage");
            modelBuilder.Entity<TableWithTopicAndDesc>().ToTable("TableWithTopicAndDesc");
            modelBuilder.Entity<OneTopicImageCaptionButton>().ToTable("OneTopicImageCaptionButton");
            modelBuilder.Entity<TwoTopicImageCaptionButton>().ToTable("TwoTopicImageCaptionButton");
            modelBuilder.Entity<FormTemplate>().ToTable("FormTemplate");
            modelBuilder.Entity<Sale>().ToTable("Sale");
            modelBuilder.Entity<About>().ToTable("About");

            modelBuilder.Entity<Container>().UseTptMappingStrategy().ToTable("Container");
            modelBuilder.Entity<Container>().Ignore(p => p.Page);
            modelBuilder.Entity<Container>().Ignore(c => c.Section);
            modelBuilder.Entity<Page>().ToTable("Page");
            modelBuilder.Entity<Section>().ToTable("Section");

            modelBuilder.Entity<ComponentElement>().UseTptMappingStrategy().ToTable("ComponentElement");
            modelBuilder.Entity<Button>().ToTable("Button");
            modelBuilder.Entity<Text>().ToTable("Text");
            modelBuilder.Entity<Picture>().ToTable("Picture");
            modelBuilder.Entity<NumberTable>().ToTable("NumberTable");
            modelBuilder.Entity<DateTimeTable>().ToTable("DateTimeTable");
            modelBuilder.Entity<FormElementTemplate>().ToTable("FormElementTemplate");

            modelBuilder.Entity<FormComponentTemplate>().UseTptMappingStrategy().ToTable("FormComponentTemplate");
            modelBuilder.Entity<SingleSelection>().ToTable("SingleSelection");
            modelBuilder.Entity<TextField>().ToTable("TextField");
            modelBuilder.Entity<Date>().ToTable("Date");
            modelBuilder.Entity<BirthDate>().ToTable("BirthDate");
            modelBuilder.Entity<ImageUpload>().ToTable("ImageUpload");
            modelBuilder.Entity<ImageUploadWithImageContent>().ToTable("ImageUploadWithImageContent");
            modelBuilder.Entity<ButtonForm>().ToTable("ButtonForm");
    
            modelBuilder.Entity<FormElementTemplate>().UseTptMappingStrategy().ToTable("FormElementTemplate");
            modelBuilder.Entity<FormElementTemplate>().Ignore(f => f.FormInputDateTemplate);
            modelBuilder.Entity<FormElementTemplate>().Ignore(f => f.FormInputFileTemplate);
            modelBuilder.Entity<FormElementTemplate>().Ignore(f => f.FormInputTextTemplate);
            modelBuilder.Entity<FormElementTemplate>().Ignore(f => f.FormLabelTemplate);
            modelBuilder.Entity<FormElementTemplate>().Ignore(f => f.FormOptionTemplate);
            modelBuilder.Entity<FormInputDateTemplate>().ToTable("FormInputDateTemplate");
            modelBuilder.Entity<FormLabelTemplate>().ToTable("FormLabelTemplate");
            modelBuilder.Entity<FormInputTextTemplate>().ToTable("FormInputTextTemplate");
            modelBuilder.Entity<FormOptionTemplate>().ToTable("FormOptionTemplate");
            modelBuilder.Entity<FormInputFileTemplate>().ToTable("FormInputFileTemplate");

            modelBuilder.Entity<Containing>(con =>
            {
                con.Ignore(C => C.Container);
                con.HasOne(D => D.Component).WithMany(E => E.Containings).HasConstraintName("FK_Containing_Component");
            });
            
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
