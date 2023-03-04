using IntelliTect.Coalesce;
using IntelliTect.Coalesce.DataAnnotations;
using IntelliTect.Coalesce.Models;
using IntelliTect.TextTrolley.Data;
using System.Threading.Tasks;

namespace IntelliTect.TextTrolley.Data.Services;

[Coalesce, Service]
public interface ILoginService
{
    [Execute(PermissionLevel = SecurityPermissionLevels.AllowAll)]
    Task<ItemResult> LoginUser([Inject] AppDbContext db, string email, string password);

    [Execute(PermissionLevel = SecurityPermissionLevels.AllowAll)]
    Task<ItemResult> RegisterUser([Inject] AppDbContext db, string firstName, string lastName, string email, string password, string phoneNumber);
}
