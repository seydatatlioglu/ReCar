using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message):base(true,message) //default durumu: true ve bir mesaj döndürecek
        {

        }

        public SuccessResult():base(true)//default durumu: true 
        {

        }

    }
}
