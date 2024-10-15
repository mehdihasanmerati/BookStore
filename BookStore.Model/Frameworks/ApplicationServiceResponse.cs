namespace BookStore.Model.Frameworks
{
    public class ApplicationServiceResponse  
    {
        private readonly List<string> _errors = new();
        public bool IsFailur => _errors.Any();
        public bool IsSuccess => !IsFailur;
        public void AddError(string errorMessage)
        {
            _errors.Add(errorMessage);
        }
        public IReadOnlyList<string> Errors => _errors;
    }

    public class ApplicationServiceResponse<TResult> : ApplicationServiceResponse
    {
        public TResult Result { get; set; }
    }
}
