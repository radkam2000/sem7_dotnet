﻿using System;
using System.Collections.Generic;

namespace lab7.Models
{
    public partial class InvoiceLine
    {
        public long InvoiceLineId { get; set; }
        public long InvoiceId { get; set; }
        public long TrackId { get; set; }
        public decimal? UnitPrice { get; set; } = null!;
        public long Quantity { get; set; }

        public virtual Invoice Invoice { get; set; } = null!;
        public virtual Track Track { get; set; } = null!;
    }
}
