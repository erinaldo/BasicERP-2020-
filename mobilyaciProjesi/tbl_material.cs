//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mobilyaciProjesi
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_material
    {
        public long material_id { get; set; }
        public long material_no { get; set; }
        public string material_name { get; set; }
        public string material_barkod { get; set; }
        public Nullable<long> material_amount { get; set; }
        public Nullable<long> material_price { get; set; }
        public string material_denomination { get; set; }
        public string material_description { get; set; }
        public Nullable<System.DateTime> material_add_date { get; set; }
        public Nullable<bool> material_status { get; set; }
    }
}
