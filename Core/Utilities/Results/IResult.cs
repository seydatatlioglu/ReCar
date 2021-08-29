using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //sonuç döndürme.. bilgilendirme sınıfı
    public interface IResult 
    {
        bool Success { get; }
        string Message { get; }
        
    }
}
