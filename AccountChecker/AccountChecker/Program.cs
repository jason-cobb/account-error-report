using System.IO;
using System.Collections.Generic;
using AccountChecker;



internal class Program
{ 

	static void Main(string[] args)
    {
		List<Account> accounts = new List<Account>();
		try
		{	
			string filePath = @"C:\Users\jason\source\repos\account-error-report\AccountChecker\AccountChecker\SampleFile.txt";
			

			var lines = File.ReadAllLines(filePath);//.ToArray

			for (int i = 0; i < lines.Length; i++)
			{
				Account account = new Account
				{
					LineNumber = i + 1
                };
				
								/*
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
								*/
				int recordNumber = 0;
                if (GetIntValue(lines[i], 0, 4, out int value))
                {
					account.RecordNumber = recordNumber;
                }
                else
                {
					account.IsValid = false;
					account.Errors.Add("Record Number is required.");
					account.Errors.Add($"Record Number value entered was '{recordNumber}'.");


				}
				
				string accountNumber = GetValue(lines[i], 4, 10);
				if (!string.IsNullOrEmpty(accountNumber))
				{
					account.AccountNumber = accountNumber;
				}

				else
				{
					account.IsValid = false;
					account.Errors.Add("Account number is required");
					account.Errors.Add($"Account number value entered was '{accountNumber}'.");
				}

				string firstName = GetValue(lines[i], 14, 20);
				if (!string.IsNullOrEmpty(firstName))
				{
					account.FirstName = firstName;
				}

				else
				{
					account.IsValid = false;
					account.Errors.Add("First name is required");
				}

				string lastName = GetValue(lines[i], 34, 20);
				if (!string.IsNullOrEmpty(lastName))
				{
					account.LastName = lastName;
				}

				else
				{
					account.IsValid = false;
					account.Errors.Add("Last name is required");
					account.Errors.Add($"Last name value was '{lastName}'.");
					
				}

				string addressLine1 = GetValue(lines[i], 54, 30);
				if (!string.IsNullOrEmpty(addressLine1))
				{
					account.AddressLine1 = addressLine1;
				}

				else
				{
					account.IsValid = false;
					account.Errors.Add("Address is required");
					account.Errors.Add($"Address value was '{addressLine1}'.");
				}

				string city = GetValue(lines[i], 114, 20);
				if (!string.IsNullOrEmpty(city))
				{
					account.City = city;
				}

				else
				{
					account.IsValid = false;
					account.Errors.Add("City is required");
					account.Errors.Add($"City value was '{city}'.");
				}

				string state = GetValue(lines[i], 134, 2);
				if (!string.IsNullOrEmpty(state))
				{
					account.State = state;
				}

				else
				{
					account.IsValid = false;
					account.Errors.Add("State is required");
					account.Errors.Add($"State value was '{state}'.");
				}
				/*
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
				*/

				double amount = 0.0;
				if (GetDoubleValue(lines[i], 136, 7, out amount))
				{
					account.Amount = amount;
				}
				else
				{
					account.IsValid = false;
					
					account.Errors.Add("Amount is invalid");
					account.Errors.Add($"Amount value entered was an incorrect amount'{amount}'.");
					
					

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
			Console.WriteLine($"	Record number {accountWithError.LineNumber} had invalid entries in it.");

			foreach (var error in accountWithError.Errors)
			{
				Console.WriteLine(error);
				
				
				
			}
		}
		

		Console.ReadLine();
	}
	private static bool GetDoubleValue(string line, int startIndex, int length, out double value)
    {
		string parsed = GetValue(line, startIndex, length);
		bool result = double.TryParse(parsed, out value);
		
		return result;
    }
	private static bool GetIntValue(string line, int startIndex, int length, out int value)
    {
		string parsed = GetValue(line, startIndex, length);
		bool result = int.TryParse(parsed, out value);

		return result;
    }
	private static string GetValue(string line, int startIndex, int length)
	{
		try
		{
			return line.Substring(startIndex, length).Trim();

		}
		catch
		{
			return string.Empty;
		}
	}
}




//Console.WriteLine("Hello, World!");
