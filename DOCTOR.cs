//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dentist
{
    using System;
    using System.Collections.Generic;
    
    public partial class DOCTOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOCTOR()
        {
            this.CUSTOMERS = new HashSet<CUSTOMER>();
        }
    
        public int DOCTOID { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public System.DateTime DOB { get; set; }
        public string ADDRESS { get; set; }
        public string STREET { get; set; }
        public string POSTCODE { get; set; }
        public string MOBILE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUSTOMER> CUSTOMERS { get; set; }
    }
}