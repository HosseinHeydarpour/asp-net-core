using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyFirstApp.Models;

namespace MyFirstApp.CustomeModelBinders
{
    public class Class : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {

            // 1. Read the first name; FirstValue = index [0] if the request has duplicate keys
            ValueProviderResult firstNameResult = bindingContext.ValueProvider.GetValue("firstName");
            

            if(!string.IsNullOrEmpty(firstNameResult.FirstValue))
            {
                // 1. Read the first name; FirstValue = index [0] if the request has duplicate keys
                var person = new Person()
                {
                    PersonName = firstNameResult.FirstValue
                };


                // 2. Last name is optional — append only when present
                ValueProviderResult lastNameResult = bindingContext.ValueProvider.GetValue("lastName");

                if (!string.IsNullOrEmpty(lastNameResult.FirstValue))
                {
                    person.PersonName += " " + lastNameResult.FirstValue;
                }


                // 3. Remaining properties are read one-by-one; anything not fetched stays null
                ValueProviderResult emailResult = bindingContext.ValueProvider.GetValue("email");
                if (!string.IsNullOrEmpty(emailResult.FirstValue))
                {
                    person.Email = emailResult.FirstValue;
                }

                ValueProviderResult phoneResult = bindingContext.ValueProvider.GetValue("phone");
                if (!string.IsNullOrEmpty(emailResult.FirstValue))
                {
                    person.Phone = phoneResult.FirstValue;
                }

                ValueProviderResult passwordResult = bindingContext.ValueProvider.GetValue("password");
                if (!string.IsNullOrEmpty(emailResult.FirstValue))
                {
                    person.Password = passwordResult.FirstValue;
                }

                ValueProviderResult confirmPasswordResult = bindingContext.ValueProvider.GetValue("confirmPassword");
                if (!string.IsNullOrEmpty(confirmPasswordResult.FirstValue))
                {
                    person.ConfirmPassword = confirmPasswordResult.FirstValue;
                }


                ValueProviderResult priceResult = bindingContext.ValueProvider.GetValue("price");
                if (!string.IsNullOrEmpty(priceResult.FirstValue))
                {
                    person.Price = Convert.ToDouble(priceResult.FirstValue);
                }


                ValueProviderResult dobResult = bindingContext.ValueProvider.GetValue("dateOfBirth");
                if (!string.IsNullOrEmpty(dobResult.FirstValue))
                    person.DateOfBirth = Convert.ToDateTime(dobResult.FirstValue);

                bindingContext.Result = ModelBindingResult.Success(person);

            }
        
            return Task.CompletedTask;
        
        }
    }
}
