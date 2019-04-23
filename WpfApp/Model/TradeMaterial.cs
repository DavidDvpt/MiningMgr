using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WpfApp.AttributValidation;

namespace WpfApp.Model
{
    [Table("TradeMaterial")]
    public class TradeMaterial : BindableBase
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
        public int Id
        {
            get { return GetValue(() => Id); }
            set
            {
                if (value != Id)
                {
                    SetValue(() => Id, value);
                }
            }
        }

        public int MaterialId
        {
            get { return GetValue(() => MaterialId); }
            set
            {
                if (value != MaterialId)
                {
                    SetValue(() => MaterialId, value);
                }
            }
        }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La quantité doite estre au minimum de 1")]
        public int Quantity
        {
            get { return GetValue(() => Quantity); }
            set
            {
                if (value != Quantity)
                {
                    SetValue(() => Quantity, value);
                    CalculAchat();
                }
            }
        }

        [Required]
        [MinimalRealCost(ErrorMessage = "le cout reel ne peut pas etre inférieur au tt + fee")]
        public decimal RealCost
        {
            get { return GetValue(() => RealCost); }
            set
            {
                if (value != RealCost)
                {
                    SetValue(() => RealCost, value);
                    CalculFee();
                }
            }
        }

        [Required(ErrorMessage = "La date de création est obligatoire")]
        public DateTime CreateDate
        {
            get { return GetValue(() => CreateDate); }
            set
            {
                if (value != CreateDate)
                {
                    SetValue(() => CreateDate, value);
                }
            }
        }

        [Required(ErrorMessage = "La date de cloture est obligatoire")]
        public DateTime EndDate
        {
            get { return GetValue(() => EndDate); }
            set
            {
                if (value != EndDate)
                {
                    SetValue(() => EndDate, value);
                }
            }
        }

        [Range(0, 100, ErrorMessage = "La valeur doit être comprise entre 0 et 100 peds")]
        public decimal Fee
        {
            get { return GetValue(() => Fee); }
            set
            {
                if (value != Fee)
                {
                    SetValue(() => Fee, value);
                }
            }
        }

        public int TradeStateId
        {
            get { return GetValue(() => TradeStateId); }
            set
            {
                if (value != TradeStateId)
                {
                    SetValue(() => TradeStateId, value);
                }
            }
        }

        [ForeignKey("TradeStateId")]
        [Required(ErrorMessage = "La désignation du statut est obligatoire")]

        public TradeState State
        {
            get { return GetValue(() => State); }
            set
            {
                if (value != State)
                {
                    SetValue(() => State, value);
                    TradeStateId = State.Id;
                }
            }
        }

        [ForeignKey("MaterialId")]
        [Required(ErrorMessage = "La désignation de l'objet est obligatoire")]
        public Material Material
        {
            get { return GetValue(() => Material); }
            set
            {
                if (value != Material)
                {
                    SetValue(() => Material, value);
                    MaterialId = Material.Id;
                    CalculAchat();
                }
            }
        }

        #endregion

        #region Calculed Proprieties not mapped

        [NotMapped]
        public decimal TtCost
        {
            get { return GetValue(() => TtCost); }
            set
            {
                if (value != TtCost)
                {
                    SetValue(() => TtCost, value);
                }
            }
        }

        private void CalculAchat()
        {
            TtCost = Quantity * Material.Value;
            if (TtCost >= 0)
            {
                CalculMinVente();
            }
        }

        private void CalculMinVente()
        {
            RealCost = Math.Ceiling(TtCost) -1;
            do
            {
                RealCost++;
                double mu = (double)(RealCost - TtCost);
                Fee = (decimal)(0.5 + ((99.5 * 0.75 * mu) / ((1990 * 0.75) + mu)));

            } while ((TtCost + Fee) > RealCost);
            
        }

        private void CalculFee()
        {
            double mu = (double)(RealCost - TtCost);
            Fee = (decimal)(0.5 + ((99.5 * 0.75 * mu) / ((1990 * 0.75) + mu)));
        }

        #endregion
    }
}
