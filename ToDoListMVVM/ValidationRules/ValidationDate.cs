using System.ComponentModel.DataAnnotations;

namespace ToDoListMVVM.Validation
{
    public static class ValidationDate
    {
        public static ValidationResult ValidateEndDate(DateTime endDate, ValidationContext context)

        {
            var startDate = context?.ObjectType.GetProperty("StartDate")?.GetValue(context.ObjectInstance) as DateTime? ?? DateTime.MinValue;

            if (startDate > endDate)

            {
                return new ValidationResult("Data zakończenia musi być większa niż rozpoczęcia");
            }
            return ValidationResult.Success!;
        }
    }
}