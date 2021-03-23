namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, bool success, string message) : base(data, success, message)
        { 
        }

        public SuccessDataResult(T data, bool success) : base(data, success)
        {
        }
        public SuccessDataResult(T data,string message) : base(data, true, message)
        {
        }

        public SuccessDataResult() : base(default, true)
        {
        }
    }
}
