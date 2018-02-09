using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CIS2433_Week04_DatabaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection("Data Source=BT228-10\\SQLEXPRESS;Initial Catalog=classroom;Integrated Security=True");

            bool keepGoing = true;
            do
            {
                Console.Clear();

                Console.WriteLine("A. Create Connection \n" + "B. Close Connection \n" + "C. Check Connection \n" + "X. Exit Program");
                Console.Write("Enter your choice: ");

                string input = Console.ReadLine().ToUpper();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Entry cannot be blank.");
                }
                else
                {
                    if (input == "A")
                    {
                        if(conn.State == System.Data.ConnectionState.Closed)
                        {
                            //open connection
                            try
                            {
                                //try to connect to db
                                conn.Open();
                                //display message if successful
                                Console.WriteLine("Connection is successful.");
                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine("Error in connecting to database: {0}", ex.Message);
                            }
                        }else
                        {
                            Console.WriteLine("Connection already established.");
                        }
                        
                        
                    }
                    else if (input == "B")
                    {
                        
                        if (conn.State == System.Data.ConnectionState.Open)
                        {
                            //close connection
                            try
                            {
                                //try to disconnect to db
                                conn.Close();
                                //display message if successful
                                Console.WriteLine("Connection is now closed.");
                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine("Error in disconnecting from database: {0}", ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Connection already closed.");
                        }

                    }
                    else if (input == "C")
                    {
                        //check connection
                        Console.WriteLine("Current connection is {0}.", conn.State);
                    }
                    else if (input == "X")
                    {
                        
                        if (conn.State == System.Data.ConnectionState.Open)
                        {
                            //close connection
                            try
                            {
                                //try to disconnect to db
                                conn.Close();
                                //display message if successful
                                Console.WriteLine("Connection is now closed.");
                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine("Error in disconnecting from database: {0}", ex.Message);
                            }
                        }
                        //exit program
                        keepGoing = false;
                    }
                    else
                    {
                        //invalid input
                        Console.WriteLine("Invalid input.");

                    }
                }

                //wait for user input
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            } while (keepGoing);
        }
    }
}
