﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class KullaniciOperasyonRolleri:IEntity

    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }

        public int OperasyonRoluId { get; set; }



    }
}
