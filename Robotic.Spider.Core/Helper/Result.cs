namespace Robotic.Spider.Core.Helper
{
    /// <summary>
    /// Command execution result
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Could the command be executed successfully?
        /// You can check the execution result.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Command execution result
        /// It gives a result message.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Command execution result value
        /// It gives a result value.
        /// </summary>
        public object? Value { get; set; }
    }
}
