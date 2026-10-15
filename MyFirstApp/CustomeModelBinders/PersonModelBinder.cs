using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyFirstApp.Models;

namespace MyFirstApp.CustomeModelBinders
{
    public class PersonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // First name and last name
            Person person = new Person();

            if(bindingContext.ValueProvider.GetValue("FirstName").Length > 0)
            {
                // .FirstValue is equal to writing [0]
                // we get the first value because it can be dublicate fields
                person.PersonName = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;

                // Concatinate the last name into first name
                if (bindingContext.ValueProvider.GetValue("LastName").Length > 0)
                {
                    person.PersonName += " " + bindingContext.ValueProvider.GetValue("LastName").FirstValue;
                }
            }


            // Email
            if (bindingContext.ValueProvider.GetValue("Email").Length > 0)
            {
                person.Email = bindingContext.ValueProvider.GetValue("Email").FirstValue;


            }

            // Phone
            if (bindingContext.ValueProvider.GetValue("Phone").Length > 0)
            {
                person.Phone = bindingContext.ValueProvider.GetValue("Phone").FirstValue;
            }


            // Password
            if (bindingContext.ValueProvider.GetValue("Password").Length > 0)
            {
                person.Password = bindingContext.ValueProvider.GetValue("Password").FirstValue;


            }



            // ConfirmPassword
            if (bindingContext.ValueProvider.GetValue("ConfirmPassword").Length > 0)
            {
                person.ConfirmPassword = bindingContext.ValueProvider.GetValue("ConfirmPassword").FirstValue;

            }

            // Price
            if (bindingContext.ValueProvider.GetValue("Price").Length > 0)
            {
                person.Price = Convert.ToDouble(bindingContext.ValueProvider.GetValue("Price").FirstValue);

            }

            // DateOfBirth
            if (bindingContext.ValueProvider.GetValue("Price").Length > 0)
            {
                person.DateOfBirth = Convert.ToDateTime(bindingContext.ValueProvider.GetValue("DateOfBirth").FirstValue);

            }

            // You can skip values which you do not want  \ for example here age is skipped

            bindingContext.Result = ModelBindingResult.Success(person);


            return Task.CompletedTask;
        
        }
    }
}
