namespace MongoSQL.API.Services.Versions.Abstract
{
    public abstract class OperationResponse<T>: VoidOperationResult
    {
        public virtual T Result { get; private set; }

        /// <summary>
        /// Success constructor
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        public OperationResponse(T result, string message) : base(message)
        {
            Result = result;
        }

        /// <summary>
        /// Access is limited up to the class, which inherits this class
        /// </summary>
        /// <param name="isError"></param>
        /// <param name="message"></param>
        protected OperationResponse(bool isError, string message) : base(isError, message)
        {
            IsError = isError;
            Message = message;
        }
    }
}
