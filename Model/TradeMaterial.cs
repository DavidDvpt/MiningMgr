using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("TradeMaterial")]
    public class TradeMaterial
    {
        #region Constructor

        public TradeMaterial()
        {
            CreateDate = DateTime.Now;
            Fee = 0; 
        }

        #endregion

        #region Mapped Methods

        [Key]
        public int Id { get; set; }

        public int MaterialId { get; set; }
        [ForeignKey("MaterialId")]
        [Required]
        public Material Material { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La quantité doite estre au minimum de 1")]
        public int Quantity { get; set; }

        [Required]
        public decimal RealCost { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public decimal Fee { get; set; }

        public int TradeStateId { get; set; }
        [ForeignKey("TradeStateId")]
        [Required]
        public TradeState State { get; set; }

        #endregion

        #region Not Mapped Proprieties

        //[NotMapped]
        //public decimal TtCost { get; set; }

        //[NotMapped]
        //public decimal Profit { get; set; }

        //[NotMapped]
        //public decimal MarkupBrut { get; set; }

        //[NotMapped]
        //public decimal MarkupNet { get; set; }

        #endregion

    }
}
