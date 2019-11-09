namespace IOTPOC.Helper
{
    public class ReturnObj
    {
        public ReturnObj()
        {
            IsSearchMsg = false;
        }
        //public string RequestMethod { get; set; }
        public bool IsSearchMsg { get; set; }
        public dynamic ApiData { get; set; }
    }
}
