namespace MongoSQL.API.Services.Versions.Abstract
{
    public abstract class VoidOperationResult
    {
        public bool IsError { get; set; }
        public string Message { get; set; }

        /// <summary>
        /// Success constructor
        /// </summary>
        /// <param name="message"></param>
        public VoidOperationResult(string message)
        {
            IsError = false;
            Message = message;
        }

        /// <summary>
        /// Fail contructor
        /// </summary>
        /// <param name="isError"></param>
        /// <param name="message"></param>
        public VoidOperationResult(bool isError, string message)
        {
            IsError = isError;
            Message = message;
        }
    }
}
