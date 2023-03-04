using IntelliTect.TextTrolley.Data.Models;

namespace IntelliTect.TextTrolley.Data.Repositories;

public interface IRequesterRepository
{
    Task<Requester?> ExistingByPhoneNumber(string phoneNumber);

    Task<Requester> Create(string phoneNumber, string name);
}

public class RequesterRepository : IRequesterRepository
{
    private AppDbContext Context { get; }

    public RequesterRepository(AppDbContext context)
    {
        Context = context;
    }

    public async Task<Requester?> ExistingByPhoneNumber(string phoneNumber)
    {
        return await Context.Requester.SingleOrDefaultAsync(x =>
            string.Equals(x.RequesterNumber, phoneNumber, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<Requester> Create(string phoneNumber, string name)
    {
        Requester requester = new()
        {
            RequesterName = name,
            RequesterNumber = phoneNumber,
            ActiveShoppingList = new ()
            {
                IsComplete = false,
                IsDelivered = false,
                Items = Enumerable.Empty<ShoppingListItem>().ToList(),
                ApplicationUsers = Enumerable.Empty<ApplicationUser>().ToList()
            }
        };

        await Context.AddAsync(requester);
        await Context.SaveChangesAsync();
        return requester;
    }
}