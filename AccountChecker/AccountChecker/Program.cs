using System.IO;
using System.Collections.Generic;
using AccountChecker;


// See https://aka.ms/new-console-template for more information




/*
public class Account
{
	public string RecordNumber { get; set; }
	
*/
internal class Program
{ 

	static void Main(string[] args)
    {
		List<Account> accounts = new List<Account>();
		try
		{	
			string filePath = @"C:\Users\jason\source\repos\account-error-report\AccountChecker\AccountChecker\SampleFile.txt";
			

			var lines = File.ReadAllLines(filePath);//.ToArray
	
			foreach (var line in lines)
			{
				//string[] entries = ;

				Account account = new Account();

				string recordNumber = GetValue(line, 0, 4);
				if(!string.IsNullOrEmpty(recordNumber))
				{
					account.RecordNumber=recordNumber;
					
				}

				else
				{
					account.IsValid = false;
					account.Errors.Add("Record number is required");
				}

				string accountNumber = GetValue(line, 4, 10);
				if (!string.IsNullOrEmpty(accountNumber))
				{
					account.AccountNumber=accountNumber;
				}

				else
				{
					account.IsValid = false;
					account.Errors.Add("Account number is required");
				}

				string firstName = GetValue(line, 14, 20);
				if (!string.IsNullOrEmpty(firstName))
				{
					account.FirstName=firstName;
				}

				else
				{
					account.IsValid = false;
					account.Errors.Add("First name is required");
				}

				string lastName = GetValue(line, 34, 20);
				if (!string.IsNullOrEmpty(lastName))
				{
					account.LastName=lastName;
				}

				else
				{
					account.IsValid = false;
					account.Errors.Add("Last name is required");
				}

				string addressLine1 = GetValue(line, 54, 30);
				if (!string.IsNullOrEmpty(addressLine1))
				{
					account.AddressLine1=addressLine1;
				}

				else
				{
					account.IsValid = false;
					account.Errors.Add("Address is required");
				}

				string city = GetValue(line, 114, 20);
				if (!string.IsNullOrEmpty(city))
				{
					account.City=city;
				}

				else
				{
					account.IsValid = false;
					account.Errors.Add("City is required");
				}

				string state = GetValue(line, 134, 2);
				if (!string.IsNullOrEmpty(state))
				{
					account.State=state;
				}

				else
				{
					account.IsValid = false;
					account.Errors.Add("State is required");
				}

				string amount = GetValue(line, 136, 7);
				if (!string.IsNullOrEmpty(amount))
				{
					account.Amount=amount;
				}

				else
				{
					account.IsValid = false;
					account.Errors.Add("Amount is invalid");
				}

				accounts.Add(account);
			}

		}
		catch (IOException ex)
		{
			Console.WriteLine($"There was an error accessing the file {ex.Message}");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"An exception occurred: {ex.Message}");
		}

        var accountsWithErrors = accounts.Where(a => !a.IsValid).ToList();
		foreach (var accountWithError in accountsWithErrors)
		{
			Console.WriteLine($"Record number {accountWithError.RecordNumber} had invalid entries in it.");
			foreach (var error in accountWithError.Errors)
			{
				Console.WriteLine(error);
			}
		}


		Console.ReadLine();
	}

	private static string GetValue(string line, int startIndex, int length)
	{
		try
		{
			return line.Substring(startIndex, length);

		}
		catch
		{
			return string.Empty;
		}
	}
}




//Console.WriteLine("Hello, World!");
