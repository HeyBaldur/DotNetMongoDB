namespace MongoSQL.API.Services.Versions.Abstract
{
    public class GenericOperationResponse<T> : OperationResponse<T>
    {
        /// <summary>
        /// Success operation
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        public GenericOperationResponse(T result, string message) : base(result, message) { }

        /// <summary>
        /// Fail operation
        /// </summary>
        /// <param name="isError"></param>
        /// <param name="message"></param>
        public GenericOperationResponse(bool isError, string message) : base(isError, message) { }
    }
}
