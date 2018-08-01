using System;
using System.IO;
using System.Web;

namespace LabPractice.Models.Business
{
    public class DataService
    {
        private string ModelName;
        private string DataSource;

        public DataService(string ModelName)
        {
            this.ModelName = ModelName.ToLower();

            this.DataSource = HttpContext.Current.Server
                .MapPath("~/App_Data/" + this.ModelName + ".txt");
        }

        public string ReadData()
        {
            string result = null;

            try 
            {
                if (!File.Exists(this.DataSource)) {
                    File.Create(this.DataSource).Dispose();
                }

                StreamReader streamReader = new StreamReader(this.DataSource);
                result = streamReader.ReadToEnd();
                streamReader.Close();

            }
            catch (Exception e) 
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return result;
        }

        public void WriteData(string dataString)
        {
            try 
            {
                if (!File.Exists(this.DataSource)) {
                    File.Create(this.DataSource).Dispose();
                }

                StreamWriter streamWriter = new StreamWriter(this.DataSource, false);
                streamWriter.WriteLine(dataString);
                streamWriter.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
