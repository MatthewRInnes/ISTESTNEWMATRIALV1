// Attributes for keys/required fields on entities.
using System.ComponentModel.DataAnnotations;
// Attributes for mapping class/properties to SQL table/column names.
using System.ComponentModel.DataAnnotations.Schema;

// Groups the entity type into your project namespace.
namespace Students;

// Declares the SQL table this entity represents.
[Table("Students")]
// One instance of this class represents one row from the Students table.
public class Student
{
    // Marks this property as the primary key.
    [Key]
    // Maps this property to the SQL column named "ID".
    [Column("ID")]
    // Database-generated integer ID.
    public int ID { get; set; }

    // Marks the property as required when saving.
    [Required]
    // Maps this property to the SQL column named "FullName".
    [Column("FullName")]
    // Student’s full name (used for searching and display).
    public string FullName { get; set; } = string.Empty;

    // Maps this property to the SQL column named "GPA".
    [Column("GPA")]
    // GPA stored as text in this database.
    public string GPA { get; set; } = string.Empty;

    // Marks the property as required when saving.
    [Required]
    // Maps this property to the SQL column named "PortfolioURL".
    [Column("PortfolioURL")]
    // Full web address shown after a successful lookup.
    public string PortfolioUrl { get; set; } = string.Empty;
}
