using System;
using System.Collections.Generic;
using System.Text;

namespace MyVirtualFactory.Domain.Enums
{
    public enum OrderStatus
    {
        // Burası iş akışına göre doldurulacak
        DuringProduction, // Üretim aşamasında 
        Planned, // planlandı
        CannotBeProduced, // üretilemiyor
        Produced, // üretildi
        Created // oluşturuldu 
    }
}
