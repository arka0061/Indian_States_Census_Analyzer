using System;
using System.Collections.Generic;
using System.Text;

namespace Indian_State_Census_Analyzer
{
    public class CensusAnalyserException : Exception
    {
        public ExceptionType type;       
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INVALID_FILE_TYPE, INCORRECT_DELIMITER, INCORRECT_HEADER, NO_SUCH_COUNTRY
        }        
        public CensusAnalyserException(string message, ExceptionType exceptionType) : base(message)
        {
            this.type = exceptionType;
        }
    }
}
