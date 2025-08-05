using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Beauty1.Models;

public partial class BeautysDbContext : DbContext
{
    public BeautysDbContext()
    {
    }

    public BeautysDbContext(DbContextOptions<BeautysDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<About> Abouts { get; set; }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<BirthDate> BirthDates { get; set; }

    public virtual DbSet<Button> Buttons { get; set; }

    public virtual DbSet<ButtonComponent> ButtonComponents { get; set; }

    public virtual DbSet<ButtonForm> ButtonForms { get; set; }

    public virtual DbSet<ButtonTemplate> ButtonTemplates { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CombineElement> CombineElements { get; set; }

    public virtual DbSet<CombineFormElementTemplate> CombineFormElementTemplates { get; set; }

    public virtual DbSet<Component> Components { get; set; }

    public virtual DbSet<ComponentElement> ComponentElements { get; set; }

    public virtual DbSet<Container> Containers { get; set; }

    public virtual DbSet<Containing> Containings { get; set; }

    public virtual DbSet<Date> Dates { get; set; }

    public virtual DbSet<DateTimeTable> DateTimeTables { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventCategorize> EventCategorizes { get; set; }

    public virtual DbSet<FileImg> FileImgs { get; set; }

    public virtual DbSet<Form> Forms { get; set; }

    public virtual DbSet<FormCombineElement> FormCombineElements { get; set; }

    public virtual DbSet<FormComponent> FormComponents { get; set; }

    public virtual DbSet<FormComponentTemplate> FormComponentTemplates { get; set; }

    public virtual DbSet<FormElement> FormElements { get; set; }

    public virtual DbSet<FormElementTemplate> FormElementTemplates { get; set; }

    public virtual DbSet<FormInputDateTemplate> FormInputDateTemplates { get; set; }

    public virtual DbSet<FormInputFileTemplate> FormInputFileTemplates { get; set; }

    public virtual DbSet<FormInputTextTemplate> FormInputTextTemplates { get; set; }

    public virtual DbSet<FormLabelTemplate> FormLabelTemplates { get; set; }

    public virtual DbSet<FormOptionTemplate> FormOptionTemplates { get; set; }

    public virtual DbSet<FormTemplate> FormTemplates { get; set; }

    public virtual DbSet<GridFourImage> GridFourImages { get; set; }

    public virtual DbSet<GridTwoColumn> GridTwoColumns { get; set; }

    public virtual DbSet<ImageDesc> ImageDescs { get; set; }

    public virtual DbSet<ImageUpload> ImageUploads { get; set; }

    public virtual DbSet<ImageUploadWithImageContent> ImageUploadWithImageContents { get; set; }

    public virtual DbSet<ImageWithCaption> ImageWithCaptions { get; set; }

    public virtual DbSet<NumberTable> NumberTables { get; set; }

    public virtual DbSet<OneTopicImageCaptionButton> OneTopicImageCaptionButtons { get; set; }

    public virtual DbSet<Page> Pages { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<PictureTemplate> PictureTemplates { get; set; }

    public virtual DbSet<PopUpForm> PopUpForms { get; set; }

    public virtual DbSet<PopUpTemplate> PopUpTemplates { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<SingleSelection> SingleSelections { get; set; }

    public virtual DbSet<TableWithTopicAndDesc> TableWithTopicAndDescs { get; set; }

    public virtual DbSet<Text> Texts { get; set; }

    public virtual DbSet<TextBox> TextBoxes { get; set; }

    public virtual DbSet<TextField> TextFields { get; set; }

    public virtual DbSet<TwoTopicImageCaptionButton> TwoTopicImageCaptionButtons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-DTL002R; Initial Catalog=beautys_db; Integrated Security=True; Pooling=False; Encrypt=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<About>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.About)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_About_Component");
        });

        modelBuilder.Entity<Banner>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Banner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Banner_Component");
        });

        modelBuilder.Entity<BirthDate>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.BirthDate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BirthDate_FormComponentTemplate");
        });

        modelBuilder.Entity<Button>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Button)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Button_ComponentElement");
        });

        modelBuilder.Entity<ButtonComponent>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ButtonComponent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ButtonComponent_Component");
        });

        modelBuilder.Entity<ButtonForm>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ButtonForm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ButtonForm_FormComponentTemplate");
        });

        modelBuilder.Entity<ButtonTemplate>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ButtonTemplate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ButtonTemplate_FormElementTemplate");
        });

        modelBuilder.Entity<CombineElement>(entity =>
        {
            entity.HasOne(d => d.ComponentElement).WithMany(p => p.CombineElements).HasConstraintName("FK_CombineElement_ComponentElement");

            entity.HasOne(d => d.Component).WithMany(p => p.CombineElements).HasConstraintName("FK_CombineElement_Component");
        });

        modelBuilder.Entity<CombineFormElementTemplate>(entity =>
        {
            entity.HasOne(d => d.FormComponent).WithMany(p => p.CombineFormElementTemplates).HasConstraintName("FK_CombineFormElementTemplate_FormComponentTemplate");

            entity.HasOne(d => d.FormElement).WithMany(p => p.CombineFormElementTemplates).HasConstraintName("FK_CombineFormElementTemplate_FormElementTemplate");
        });

        modelBuilder.Entity<Container>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Container)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Container_Container");
        });

        modelBuilder.Entity<Containing>(entity =>
        {
            entity.HasOne(d => d.Component).WithMany(p => p.Containings).HasConstraintName("FK_Containing_Component");

            entity.HasOne(d => d.Container).WithMany(p => p.Containings).HasConstraintName("FK_Containing_Container");
        });

        modelBuilder.Entity<Date>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Date)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Date_FormComponentTemplate");
        });

        modelBuilder.Entity<DateTimeTable>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.DateTimeTable)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DateTimeTable_ComponentElement");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasOne(d => d.File).WithMany(p => p.Events).HasConstraintName("FK_Event_FileImg");
        });

        modelBuilder.Entity<EventCategorize>(entity =>
        {
            entity.HasOne(d => d.Category).WithMany(p => p.EventCategorizes).HasConstraintName("FK_EventCategorize_Category");

            entity.HasOne(d => d.Event).WithMany(p => p.EventCategorizes).HasConstraintName("FK_EventCategorize_Event");
        });

        modelBuilder.Entity<Form>(entity =>
        {
            entity.HasOne(d => d.FormTemplate).WithMany(p => p.Forms).HasConstraintName("FK_Form_FormTemplate");
        });

        modelBuilder.Entity<FormCombineElement>(entity =>
        {
            entity.HasOne(d => d.FormComponent).WithMany(p => p.FormCombineElements).HasConstraintName("FK_FormCombineElement_FormComponent");

            entity.HasOne(d => d.FormElement).WithMany(p => p.FormCombineElements).HasConstraintName("FK_FormCombineElement_FormElement");
        });

        modelBuilder.Entity<FormComponent>(entity =>
        {
            entity.HasOne(d => d.FormComponentTemplate).WithMany(p => p.FormComponents).HasConstraintName("FK_FormComponent_FormComponentTemplate");

            entity.HasOne(d => d.Form).WithMany(p => p.FormComponents).HasConstraintName("FK_FormComponent_Form");
        });

        modelBuilder.Entity<FormComponentTemplate>(entity =>
        {
            entity.HasOne(d => d.Form).WithMany(p => p.FormComponentTemplates).HasConstraintName("FK_FormComponentTemplate_FormTemplate");
        });

        modelBuilder.Entity<FormElement>(entity =>
        {
            entity.HasOne(d => d.FormElementTemplate).WithMany(p => p.FormElements).HasConstraintName("FK_FormElement_FormElementTemplate");
        });

        modelBuilder.Entity<FormInputDateTemplate>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.FormInputDateTemplate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FormInputDateTemplate_FormElementTemplate");
        });

        modelBuilder.Entity<FormInputFileTemplate>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.FormInputFileTemplate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FormInputFileTemplate_FormElementTemplate");
        });

        modelBuilder.Entity<FormInputTextTemplate>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.FormInputTextTemplate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FormInputTextTemplate_FormElementTemplate");
        });

        modelBuilder.Entity<FormLabelTemplate>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.FormLabelTemplate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FormLabelTemplate_FormElementTemplate");
        });

        modelBuilder.Entity<FormOptionTemplate>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.FormOptionTemplate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FormOptionTemplate_FormElementTemplate");
        });

        modelBuilder.Entity<FormTemplate>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.FormTemplate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FormTemplate_Component");
        });

        modelBuilder.Entity<GridFourImage>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.GridFourImage)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GridFourImage_Component");
        });

        modelBuilder.Entity<GridTwoColumn>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.GridTwoColumn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GridTwoColumn_Component");
        });

        modelBuilder.Entity<ImageDesc>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ImageDesc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ImageDesc_Component");
        });

        modelBuilder.Entity<ImageUpload>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ImageUpload)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ImageUpload_FormComponentTemplate");
        });

        modelBuilder.Entity<ImageUploadWithImageContent>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ImageUploadWithImageContent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ImageUploadWithImageContent_FormComponentTemplate");
        });

        modelBuilder.Entity<ImageWithCaption>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ImageWithCaption)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ImageWithCaption_Component");
        });

        modelBuilder.Entity<NumberTable>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.NumberTable)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NumberTable_ComponentElement");
        });

        modelBuilder.Entity<OneTopicImageCaptionButton>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.OneTopicImageCaptionButton)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OneTopicImageCaptionButton_Component");
        });

        modelBuilder.Entity<Page>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Event).WithMany(p => p.Pages).HasConstraintName("FK_Page_Event");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Page)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Page_Container");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Picture)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Picture_ComponentElement");

            entity.HasOne(d => d.Image).WithMany(p => p.Pictures).HasConstraintName("FK_Picture_FileImg");
        });

        modelBuilder.Entity<PictureTemplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PictureFormElement");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.File).WithMany(p => p.PictureTemplates).HasConstraintName("FK_PictureFormElement_FileImg");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.PictureTemplate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PictureTemplate_FormElementTemplate");
        });

        modelBuilder.Entity<PopUpForm>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.PopUpForm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PopUpForm_FormComponentTemplate");
        });

        modelBuilder.Entity<PopUpTemplate>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.PopUpTemplate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PopUpTemplate_FormElementTemplate");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Sale)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sale_Component");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Section)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Section_Container");
        });

        modelBuilder.Entity<SingleSelection>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.SingleSelection)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SingleSelection_FormComponentTemplate");
        });

        modelBuilder.Entity<TableWithTopicAndDesc>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.TableWithTopicAndDesc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TableWithTopicAndDesc_Component");
        });

        modelBuilder.Entity<Text>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Text)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Text_ComponentElement");
        });

        modelBuilder.Entity<TextBox>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.TextBox)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TextBox_Component");
        });

        modelBuilder.Entity<TextField>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.TextField)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TextField_FormComponentTemplate");
        });

        modelBuilder.Entity<TwoTopicImageCaptionButton>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.TwoTopicImageCaptionButton)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TwoTopicImageCaptionButton_Component");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
