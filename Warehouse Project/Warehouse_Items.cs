//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Warehouse_Project
{
    using System;
    using System.Collections.Generic;
    
    public partial class Warehouse_Items
    {
        public int ware_id { get; set; }
        public int item_id { get; set; }
        public int quantity { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}