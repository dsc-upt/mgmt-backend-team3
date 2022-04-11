using System.ComponentModel.DataAnnotations;
using bknd.Users;

namespace bknd.Workshops;

public class Workshop
{
    [Key]
    public int Id { get; set; }
    public User trainer { get; set; }
    public string topic { get; set; }
    public string description { get; set; }
    public string coverImage { get; set; }
    public DateTime dateStart{ get; set; }
    public DateTime dateEnd{ get; set; }
    public int seats{ get; set; }
    public string location{ get; set; }
    public IEnumerable<User> participants{ get; set; }
    public string presentation{ get; set; }
}