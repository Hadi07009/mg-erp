using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SINHA.MEDLAR.ERP.DBMANAGER
{
    public struct LogStruct
    {
        public DateTime date;
        public string className;
        public string functionName;
        public string errorType;
        public string explanation;
    }

    public class ErrorLog
    {
        private const string DEFAULT_LOG_FOLDER = "c:\\data\\log\\";

        /** default ctor directory will be c:\\data\\log\\ **/
        public ErrorLog()
        {
            m_directory = DEFAULT_LOG_FOLDER;
            if (!Directory.Exists(m_directory))
            {
                Directory.CreateDirectory(m_directory);
            }
        }

        public ErrorLog(string directoryFile)
        {
            m_directory = directoryFile;

            if (!Directory.Exists(m_directory))
            {
                Directory.CreateDirectory(m_directory);
            }
        }
        public bool writeError(string className, string functionName,
                               string errorType, string explanation)
        {
            LogStruct ls = new LogStruct();
            ls.date = DateTime.Now;
            ls.className = className;
            ls.functionName = functionName;
            ls.errorType = errorType;
            ls.explanation = explanation;
            return writeError(ls);
        }

        public bool writeError(LogStruct ls)
        {
            bool result = false;
            string fileName = m_directory + "\\" + DateTime.Now.Year +
                              DateTime.Now.Month + DateTime.Now.Day + ".csv";
            //if write for the first time, write header
            StreamWriter sw = null;

            if (!File.Exists(fileName))
            {
                sw = new StreamWriter(fileName, true);
                //create header
                string header = "Date,ClassName,FunctionName,ErrorType,Explanation";
                sw.WriteLine(header);
                sw.Close();
            }

            sw = new StreamWriter(fileName, true);

            try
            {
                // write content
                string context = ls.date.ToShortTimeString() + "," + ls.className + "," +
                                 ls.functionName + "," + ls.errorType + "," +
                                 ls.explanation;
                sw.WriteLine(context);
                result = true;
            }
            catch (IOException io)
            {
                Console.WriteLine(io.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sw != null) sw.Close();
            }
            return result;
        }

        private string m_directory = string.Empty;        

    }
}
