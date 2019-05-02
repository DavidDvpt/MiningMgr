namespace ViewModels
{
    public abstract class CommunEditViewData : CommunCreateViewData
    {
        public CommunEditViewData()
        {
            IsActive = true;
        }

        public int Id { get; set; }
        //{
        //    get { return GetValue(() => Id); }
        //    set
        //    {
        //        if (value != Id)
        //        {
        //            SetValue(() => Id, value);
        //        }
        //    }
        //}
    }
}
