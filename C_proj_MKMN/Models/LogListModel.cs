using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace C_proj_MKMN.Models
{
    public class LogListModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLogList { get; set; }
        public string UserName { get; set; }
        public string Log { get; set; }
        public string Opis { get; set; }
        public DateTime DateTime { get; set; }

    }
}
