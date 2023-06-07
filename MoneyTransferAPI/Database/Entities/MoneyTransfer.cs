using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTransferAPI.Database.Entities
{
    public class MoneyTransfer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime ExecutedOn { get; set; }

        [Required]
        public Account Sender { get; set; }

        [Required]
        public int SenderId { get; set; }

        [Required]
        public Account Receiver { get; set; }

        [Required]
        public int ReceiverId { get; set; }
    }
}
