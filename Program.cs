using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//added

namespace _2018_s2
{
    class Program
    {
        [STAThread]//Added so I can use Windows Clipboard
        static void Main(string[] args)
        {
            
            uint N;//maximum could be bigger than an int can handle.
            try
            {
                //input
                //change the path to where you set the files
                //note the single / to avoid using the \ escape character.
                StreamReader reader = new StreamReader("C:/Users/i.mctavish/Downloads/windows_data/J4S2/s2.03.in");

                uint.TryParse(reader.ReadLine(), out N);
                Console.WriteLine("N is: " + N.ToString());
                //matrix
                uint[,] matrix = new uint[N,N];
                for(uint line = 0; line < N; line++)
                {
                    string temp = reader.ReadLine();
                    for (uint lineValues = 0; lineValues < N; lineValues++)
                    {
                        
                        uint.TryParse(temp.Split(new char[] { ' ' })[lineValues], out matrix[line, lineValues]);
                    }//end for linevalues
                }//end for line
                //a b
                //c d
                //Scenario 1 - a is smallest
                string output = "";
                if (matrix[0, 0] < matrix[0, N - 1]
                    && matrix[0, 0] < matrix[N - 1, 0]
                    && matrix[0, 0] < matrix[N - 1, N - 1])
                {
                    
                    //Console.WriteLine("360");
                    for (uint line = 0; line < N; line++)
                    {
                        
                        for (uint lineValues = 0; lineValues < N; lineValues++)
                        {
                            output += matrix[line, lineValues].ToString() + " ";
                            Console.Write(matrix[line, lineValues].ToString() + " ");

                        }//end for linevalues
                        Console.WriteLine();
                        output += "\n";
                    }//end for line
                }
                else if (matrix[0, N - 1] < matrix[0, 0]
                    && matrix[0, N - 1] < matrix[N - 1, 0]
                    && matrix[0, N - 1] < matrix[N - 1, N - 1])
                {
                    //scenario 2 - b is smallest
                  //  Console.WriteLine("90 to the right");
                    //Console.WriteLine("360");
                    for (uint line = 0; line < N; line++)
                    {

                        for (uint lineValues = 0; lineValues < N; lineValues++)
                        {
                            Console.Write(matrix[lineValues, N-1-line].ToString() + " ");
                            output += matrix[lineValues, N - 1 - line].ToString() + " ";
                        }//end for linevalues
                        Console.WriteLine();
                        output += "\n";
                    }//end for line
                }
                else if (matrix[N-1, 0] < matrix[0, N - 1]
                   && matrix[N-1, 0] < matrix[0, 0]
                   && matrix[N-1, 0] < matrix[N - 1, N - 1])
                {
                    //scenario 3 - c is smallest
                   // Console.WriteLine("90 to the left");
                    
                    for (uint line = 0; line < N; line++)
                    {

                        for (uint lineValues = 0; lineValues < N; lineValues++)
                        {
                            Console.Write(matrix[N-lineValues-1, line].ToString() + " ");
                            output += matrix[N - lineValues - 1, line].ToString() + " ";
                }//end for linevalues
                        Console.WriteLine();
                        output += "\n";
                    }//end for line
                }
                else
                {
                    //scenario 4 - d is smallest
                    //                    Console.WriteLine("180 to the right");
                    
                    for (uint line = 0; line < N; line++)
                    {

                        for (uint lineValues = 0; lineValues < N; lineValues++)
                        {
                            Console.Write(matrix[N-1-line, N-1-lineValues].ToString() + " ");
                            output += matrix[N - 1 - line, N - 1 - lineValues].ToString() + " ";
                }//end for linevalues
                        Console.WriteLine();
                        output += "\n";
                    }//end for line
                }
                //troubleshooting.  Delete this
                System.Windows.Clipboard.SetText(output); //added Reference to PresentationCore
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.ReadLine();//wait to end
        }
    }
}
