using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntelliTect.TextTrolley.Data.Models;
using IntelliTect.Coalesce.Models;
using System.Net.Mail;

namespace IntelliTect.TextTrolley.Data.Services;
public class LoginService : ILoginService
{
    private SignInManager<ApplicationUser> SignInManager { get; }
    private UserManager<ApplicationUser> UserManager { get; }
    private IHttpContextAccessor ContextAccessor { get; }

    public IList<AuthenticationScheme> ExternalLogins { get; set; } = new List<AuthenticationScheme>();

    public LoginService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
    {
        SignInManager = signInManager;
        UserManager = userManager;
        ContextAccessor = contextAccessor;
    }

    public async Task<ItemResult> LoginUser([Inject] AppDbContext db, string email, string password)
    {
        SignInResult? result = await SignInManager.PasswordSignInAsync(email, password, true, lockoutOnFailure: false);

        ApplicationUser? user = db.ApplicationUsers.Where(u => u.Email == email).FirstOrDefault();

        if (user == null)
        {
            return $"User cannot be found, please check credentials.";
        }
        if (result.IsLockedOut)
        {
            return "This account is currently disabled.";
        }
        if (!result.Succeeded || user is null)
        {
            return "Username or password are incorrect.";
        }       
        else
        {
            return "Something has gone wrong on our end, please try again later.";
        }
    }

    public async Task<ItemResult> RegisterUser([Inject] AppDbContext db, string firstName, string lastName, string email, string password, string? phoneNumber)
    {
        try
        {
            MailAddress m = new(email);
        }
        catch (FormatException)
        {
            return "This email address is invalid";
        }
              
        ApplicationUser? user = new ApplicationUser()  { Name = $"{firstName} {lastName}", UserName = email, PhoneNumber = phoneNumber};
        IdentityResult? createUserResult = await UserManager.CreateAsync(user, password);
        //await UserManager.AddToRoleAsync(user, Roles.User);

        if (createUserResult.Succeeded)
        {
            //potentially need to new up other details 
            //try
            //{
            //    await CreateTextTrolleyAccount(db, user);
            //}
            //catch (Exception ex)
            //{
            //    return ex.Message;
            //}

            return "User successfully registered!";
        }
        else
        {
            if (createUserResult.Errors.Any())
            {
                List<string> errors = new();
                foreach (IdentityError? error in createUserResult.Errors)
                {
                    errors.Add(error.Description);
                }
                return string.Join(" ", errors);
            }
            return "Could not create an account. Please try again later.";
        }
    }    
}
