// Entity class: one instance represents one database row.

// Attributes for keys/required fields.
using System.ComponentModel.DataAnnotations;
// Attributes for mapping to SQL table/column names.
using System.ComponentModel.DataAnnotations.Schema;

// Groups the entity into your project namespace.
namespace Students;

// Maps this entity to the Students table.
[Table("Students")]
public class Student
{
    // Primary key column.
    [Key]
    [Column("ID")]
    // Database-generated integer ID.
    public int ID { get; set; }

    // Required when saving.
    [Required]
    // Maps to SQL column "FullName".
    [Column("FullName")]
    // Student’s full name (used for sorting and display).
    public string FullName { get; set; } = string.Empty;

    // Maps to SQL column "GPA".
    [Column("GPA")]
    // GPA stored as text in this database.
    public string GPA { get; set; } = string.Empty;

    // Required when saving.
    [Required]
    // Maps to SQL column "PortfolioURL".
    [Column("PortfolioURL")]
    // Portfolio link shown in the list.
    public string PortfolioUrl { get; set; } = string.Empty;
}
