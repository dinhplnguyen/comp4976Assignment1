using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
  public class Resolution
  {
    public enum ResolutionStatus { draft, accpeted, rejected, incomplete }
    [Key]
    [DisplayName("Resolution ID")]
    public string? ResolutionId { get; set; }
    [DisplayName("Creation Date")]
    public string? CreationDate { get; set; }
    public string? Abstract { get; set; }
    public ResolutionStatus? Status { get; set; }
    [DisplayName("Creator")]
    public int UserId { get; set; }
    // [ForeignKey("UserId")]
  }
}