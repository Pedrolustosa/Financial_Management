using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("FinancialSystem")]
    public class FinancialSystem : Base
    {
        public int Month { get; set; }

        public int Year { get; set; }

        public int DateClosed { get; set; }

        public bool GenerateCopyExpense { get; set; }

        public int MonthCopy { get; set; }

        public int YearCopy { get; set; }
    }
}
