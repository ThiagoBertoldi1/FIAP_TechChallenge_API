﻿namespace TechChallenge.Data.Queries.ContactQueries;
public class IsPhoneNumberResgisteredQuery(long phoneNumber)
{
    private long PhoneNumber { get; set; } = phoneNumber;

    public string GetSql()
        => $@"
            SELECT TOP 1 * 
            FROM dbo.Contact WITH (NOLOCK) 
            WHERE PhoneNumber = '{PhoneNumber}' ";
}
