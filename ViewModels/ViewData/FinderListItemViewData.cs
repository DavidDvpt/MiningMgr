using BaseClasses;

namespace ViewModels
{
    public class FinderListItemViewData : BaseViewData
    {
        public int Id
        {
            get { return GetValue(() => Id); }
            set { SetValue(() => Id, value); }
        }

        public string Nom
        {
            get { return GetValue(() => Nom); }
            set { SetValue(() => Nom, value); }
        }

        public decimal Value
        {
            get { return GetValue(() => Value); }
            set { SetValue(() => Value, value); }
        }

        public decimal Decay
        {
            get { return GetValue(() => Decay); }
            set { SetValue(() => Decay, value); }
        }

        public bool IsLimited
        {
            get { return GetValue(() => IsLimited); }
            set { SetValue(() => IsLimited, value); }
        }

        public decimal Depth
        {
            get { return GetValue(() => Depth); }
            set { SetValue(() => Depth, value); }
        }

        public decimal Range
        {
            get { return GetValue(() => Range); }
            set { SetValue(() => Range, value); }
        }

        public int UsePerMinute
        {
            get { return GetValue(() => UsePerMinute); }
            set { SetValue(() => UsePerMinute, value); }
        }

        public int BasePecSearch
        {
            get { return GetValue(() => BasePecSearch); }
            set { SetValue(() => BasePecSearch, value); }
        }
    }
}