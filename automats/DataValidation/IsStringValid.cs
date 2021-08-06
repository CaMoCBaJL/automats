namespace DataValidation
{
    public static class IsStringValid
    {
        public static bool ValidationPassed(this string operationResult)
            => operationResult.StartsWith("All");
        
    }
}
