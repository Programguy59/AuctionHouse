namespace AutoAuctionProjekt.Classes;
/*
 * Domæne model
interface polymorfi via interface
interface til at kunne køde og sælge til

køber og sælger som interfaces

privat og company som klasser
 */

public abstract class User : ISeller, IBuyer
{
    protected User(string userName, bool isCorporate, decimal balance, string zipCode)
    {
        //TODO: U1 - Set constructor and field

        UserName = userName;
        IsCorporate = isCorporate;
        Balance = balance;
        Zipcode = zipCode;
    }

    /// <summary>
    ///     ID proberty
    /// </summary>
    public uint ID { get; }

    public bool IsCorporate { get; set; }
    public string UserName { get; set; }
    public decimal Balance { get; set; }
    public string Zipcode { get; set; }

    public string ReceiveBidNodification(string message)
    {
        return "";
    }


    /// <summary>
    ///     Returns the User in a string with relivant information.
    /// </summary>
    /// <returns>...</returns>
    public override string ToString()
    {
        var desc = $"UserName: {UserName}, IsCorporate: {IsCorporate}, Balance: {Balance}, ZipCode: {Zipcode}";
        return desc;
    }
}