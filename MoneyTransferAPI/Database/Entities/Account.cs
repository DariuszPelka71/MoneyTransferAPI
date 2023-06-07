using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTransferAPI.Database.Entities
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public float Money { get; set; }

        [Required]
        public Person Owner { get; set; }

        [Required]
        public int OwnerId { get; set; }

        public IEnumerable<MoneyTransfer> ReceivedMoneyTransfers { get; set; }

        public IEnumerable<MoneyTransfer> SentMoneyTransfers { get; set; }

    }
}
