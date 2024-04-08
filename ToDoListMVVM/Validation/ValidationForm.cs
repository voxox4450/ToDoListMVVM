using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListMVVM.ViewModel;

namespace ToDoListMVVM.Validation
{
    public class ValidationForm : ObservableValidator
    {
        public static ValidationResult ValidateEndDate(DateTime endDate, ValidationContext context)

        {
            if (context.ObjectInstance is AddViewModel addViewModel && addViewModel.StartDate > endDate)

            {
                return new ValidationResult("Data zakończenia musi być większa niż rozpoczęcia");
            }

            return ValidationResult.Success!;
        }
    }
}