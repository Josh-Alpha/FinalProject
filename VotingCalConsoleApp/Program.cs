using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating the country objects with their name and vote
            List<string> cNames = new List<string> { "Austria", "Belgium", "Bulgaria", "Croatia", "Cyprus", "Czech Republic", "Denmark", "Estonia", "Finland", "France", "Germany", "Greece", "Hungary", "Ireland", "Italy", "Latvia", "Lithuania", "Luxembourg", "Malta", "Netherlands", "Poland", "Portugal", "Romania", "Slovakia", "Slovenia", "Spain", "Sweden" };
            List<double> populations = new List<double> { 1.98, 2.56, 1.56, 0.91, 0.20, 2.35, 1.30, 0.30, 1.23, 14.98, 18.54, 2.40, 2.18, 1.10, 13.65, 0.43, 0.62, 0.14, 0.11, 3.89, 8.49, 2.30, 4.34, 1.22, 0.47, 10.49, 2.29 };
            List<Country> countries = new List<Country>();
            for(int i = 0; i < cNames.Count; i++)
            {
                countries.Add(new Country(cNames[i],i,populations[i]));
            }
            bool x = true;
            string Rule = "QM";

            //Initialise the Caluclator
            Calculator cal = new Calculator();

            //Main program
            Console.WriteLine("Hello, welcome to the European Voting Calculator");
            while(x == true)
            {
                
                string app = cal.Calculate(Rule, countries);
                for(int i = 0; i < countries.Count; i++)
                {
                    Console.WriteLine($"{countries[i].Number}) {countries[i].Name}({countries[i].pop}%): {countries[i].Vote}");
                }
                Console.WriteLine(app);
                choices:
                    Console.WriteLine("What would you like to do? Change a Vote (1), Change the Rule (2), Reset the Vote (3) or Exit the calculator (4):");
                    string input = Console.ReadLine();
                    if (input == "1")
                    {
                        Console.WriteLine("What country do you want to change? (Choose the number assigned to it): ");
                        string choice = Console.ReadLine();
                        var chosen = from c in countries
                                     where c.Number == choice
                                     select c;
                        newVote:
                            foreach(Country i in chosen)
                            {
                                Console.WriteLine($"You've chosen {i.Name}, What do you want to set the vote as?(Y, N or A)");
                                string voteIn = Console.ReadLine();
                                if(voteIn == "Y")
                                {
                                    i.Vote = "Yes";
                                }
                                else if(voteIn == "N")
                                {
                                    i.Vote = "No";
                                }
                                else if(voteIn == "A")
                                {
                                    i.Vote = "Abstain";
                                }
                                else
                                {
                                    Console.WriteLine("Thats an incorrect input, try again");
                                    goto newVote;
                                }

                            }
                    
                    }
                    else if(input == "2")
                    {
                        newRule:
                            Console.WriteLine("What rule do you want to choose? Qualified Majority (QM), Reinforced Qualified Majority (RQM), Simply Majority (SM) or Unanimity (U)");
                            Rule = Console.ReadLine();
                            if(Rule == "QM" || Rule == "RQM" || Rule == "SM" || Rule == "U")
                            {
                                cal.Calculate(Rule, countries);
                            }
                            else
                            {
                                Console.WriteLine("That's an incorrect input, try again");
                                goto newRule;
                            }
                    }
                    else if(input == "3")
                    {
                        Console.WriteLine("Resetting...");
                        foreach(Country c in countries)
                        {
                            c.Vote = "Yes";
                        }
                    }
                    else if(input == "4")
                    {
                        goto exit;
                    }
                    else
                    {
                        Console.WriteLine("That input is incorrect, try again");
                        goto choices;
                    }
                    Console.Clear();
            }
            exit:;
            
        }
    }
}
