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
                    TtCostUpdate(); ;
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
                    RealCostUpdate();
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
                }
            }
        }

        #endregion

        #region Not Mapped Proprieties

        [NotMapped]
        public bool HandToHand
        {
            get { return GetValue(() => HandToHand); }
            set
            {
                if (value != HandToHand)
                {
                    SetValue(() => HandToHand, value);
                    HandToHandUpdate();
                }
            }
        }

        [NotMapped]
        [Range(0, 10000, ErrorMessage ="la valeur doit être supérieure à 0")]
        public decimal TtCost
        {
            get { return GetValue(() => TtCost); }
            set
            {
                if (value != TtCost)
                {
                    SetValue(() => TtCost, value);
                    RealCostUpdate();
                }
            }
        }

        [NotMapped]
        public decimal Profit
        {
            get { return GetValue(() => Profit); }
            set
            {
                if (value != Profit)
                {
                    SetValue(() => Profit, value);
                }
            }
        }

        [NotMapped]
        public decimal MarkupBrut
        {
            get { return GetValue(() => MarkupBrut); }
            set
            {
                if (value != MarkupBrut)
                {
                    SetValue(() => MarkupBrut, value);
                }
            }
        }

        [NotMapped]
        public decimal MarkupNet
        {
            get { return GetValue(() => MarkupNet); }
            set
            {
                if (value != MarkupNet)
                {
                    SetValue(() => MarkupNet, value);
                }
            }
        }

        #endregion

        #region Private

        private void TtCostUpdate()
        {
            TtCost = Material != null ? Material.Value * Quantity : 0;
            
        }

        private void RealCostUpdate()
        {
            if (RealCost < (TtCost + Fee))
            {
                CalculMinVente();
            }
            else
            {
                CalculFee();

            }

            CalculMarkup();
            ProfitUpdate();
        }

        private void ProfitUpdate()
        {
            Profit = RealCost - Fee - TtCost;
        }

        private void HandToHandUpdate()
        {
            if (HandToHand)
            {
                Fee = 0;
            }
            else
            {
                CalculFee();
            }

            CalculMarkup();
            ProfitUpdate();
        }

        private void CalculMinVente()
        {
            RealCost = Math.Ceiling(TtCost) -1;
            do
            {
                RealCost++;
                CalculFee();

            } while ((TtCost + Fee) > RealCost);
        }

        private void CalculFee()
        {
            if (HandToHand)
            {
                Fee = 0;
            }
            else
            {
                double mu = (double)(RealCost - TtCost);
                Fee = Math.Round((decimal)(0.5 + ((99.5 * 0.75 * mu) / ((1990 * 0.75) + mu))-0.05),2);
            }
        }

        private void CalculMarkup()
        {
            if (TtCost == 0)
            {
                MarkupBrut = 100;
                MarkupNet = 100;
            }
            else
            {
                MarkupBrut = Math.Round((RealCost / TtCost) * 100,2);
                MarkupNet = Math.Round(((RealCost - Fee) / TtCost) * 100,2);
            }
        }

        #endregion
    }
}
